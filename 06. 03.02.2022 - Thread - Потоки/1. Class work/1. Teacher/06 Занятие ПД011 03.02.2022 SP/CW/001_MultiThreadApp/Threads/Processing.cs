using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

namespace Threads
{
    // • Поток 1.
    //   Формировать 2 целочисленных массива случайных чисел, из них
    //   создать коллекцию элементов, входящих как в первый, так и во
    //   второй массивы, выводить в консоль результаты работы
    //
    // • Поток 2.
    //   Вывести в консоль строки из текстового файла, содержащие цифры
    //
    // • Поток 3.
    //   В двоичном файле вещественных чисел поменять местами первый 
    //   минимальный и последний максимальный элементы файла, выводить 
    //   в консоль результаты работы
    public class Processing
    {
        // данные для потоков

        // массивы для обработки
        public int[] Array1 { get; set; }
        public int[] Array2 { get; set; }

        // массив - результат обработки
        private int[] _results;
        public int[] Results => _results;

        // имя текстового файла
        public string TextFileName { get; set; }

        // имя бинарного файла
        private string _binFileName;
        public string BinFileName { 
            get => _binFileName;

            // при задании имени файла проверяем наличие файла и создаем файл при его отсутствии
            set {
                _binFileName = value;

                if (!File.Exists(_binFileName)) {
                    var data = Enumerable
                        .Repeat(0, Utils.GetRandom(8, 15))
                        .Select(x => Utils.GetRandom(-10d, 20d))
                        .ToList();

                    using (BinaryWriter bwr = new BinaryWriter(File.Create(_binFileName)))
                        data.ForEach(datum => bwr.Write(datum));
                } // if
            } // set
        } // BinFileName

        // ссылка на форму, в которой размещены элементы управления,
        // в которые будем выводить результаты работы
        private Form _form;
        public Form Form
        {
            get => _form;
            set => _form = value;
        }


        // контролы для вывода из потоков в форму
        public TextBox UserControl1 { get; set; }
        public TextBox UserControl2 { get; set; }
        public TextBox UserControl3 { get; set; }


        // метод для потока 1
        // создать коллекцию элементов,входящих как в первый, так и во
        // второй массивы, выводить в консоль результаты работы
        public void Process1_Console() {
            // обработка по заданию
            _results = Array1.Intersect(Array2).ToArray();

            // вывод в консоль
            OutputToConsole();
        } // Process1_Console

        // обработкапо заанию 1 для Windows Forms
        public void Process1() {
            // обработка по заданию
            _results = Array1.Intersect(Array2).ToArray();

            // вывод в консоль
            OutputToTextBox();
        } // Process1_Console


        // примитивная реализация непрерываемого вывода в консоль
        private void OutputToConsole() {
            StringBuilder sb = new StringBuilder("\tПоток1:\n");

            // Вывод массива в строку
            void OutArray(int[] array, string title) {
                sb.Append(title);
                foreach (var item in array) {
                    sb.Append($"{item,5}");
                }

                sb.AppendLine();
            } // OutArray

            OutArray(Array1, "\tМассив1  : ");
            OutArray(Array2, "\tМассив2  : ");
            OutArray(_results, "\tРезультат: ");

            // Console.WriteLine(sb);
            Console.WriteLine(sb.ToString());
        } // OutputToStrigBuilder


        // вывод результатов работы в TextBox, для приложения Windos forms
        private void OutputToTextBox() {

            StringBuilder sb = new StringBuilder("Поток1:\r\n");

            // Вывод массива в строку
            void OutArray(int[] array, string title) {
                sb.Append(title);
                foreach (var item in array) {
                    sb.Append($"{item,5}");
                }

                sb.Append("\r\n");
            } // OutArray

            OutArray(Array1, "Массив1  : ");
            OutArray(Array2, "Массив2  : ");
            OutArray(_results, "Результат: ");

            if (UserControl1.InvokeRequired)
                _form.BeginInvoke((Action)(() => UserControl1.Text = sb.ToString()));
            else
                UserControl1.Text = sb.ToString();
        } // OutputToTextBox

        // --------------------------------------------------------------

        // метод для потока 2
        // Вывести в консоль строки из текстового файла, содержащие цифры
        public void Process2_Console() {
            // обработка по заданию
            List<string> strings = File.ReadLines(TextFileName).ToList();
            StringBuilder sb = OutputToStrigBuilder(strings, $"\n\n\tПоток 2: файл \"{TextFileName}\":\n");

            // проверить есть ли цифры в строках
            List<string> digitContains = strings
                .Where(line => line.Any(char.IsDigit))
                .ToList();

            // вывод в консоль
            sb.Append(OutputToStrigBuilder(digitContains, $"\n\tПоток 2: строки файла \"{TextFileName}\", содержащие цифры:\n"));
            Console.WriteLine(sb);
        } // Process2_Console


        // метод для потока 2, используется в приложении Windows Forms
        // Вывести в TextBox строки из текстового файла, содержащие цифры
        public void Process2() {
            // обработка по заданию
            List<string> strings = File.ReadLines(TextFileName).ToList();
            StringBuilder sb = OutputToStrigBuilder(strings, $"\r\nПоток 2: файл \"{TextFileName}\":\r\n");

            // проверить есть ли цифры в строках
            List<string> digitContains = strings
                .Where(line => line.Any(char.IsDigit))
                .ToList();

            // вывод в TextBox
            sb.Append(OutputToStrigBuilder(digitContains, $"\r\nПоток 2: строки файла \"{TextFileName}\", содержащие цифры:\r\n"));

            if (UserControl2.InvokeRequired)
                _form.BeginInvoke((Action)(() => UserControl2.Text = sb.ToString()));
            else
                UserControl2.Text = sb.ToString();
        } // Process2

        // вывод списка строк в консоль
        private StringBuilder OutputToStrigBuilder(List<string> list, string title) {
            // сформировать вывод в StringBuilder'е
            StringBuilder sb = new StringBuilder(title);
            list.ForEach(item => sb.Append($"{item}\r\n"));

            // собсвенно вывод
            return sb;
        } // OutputToStrigBuilder

        // --------------------------------------------------------------

        // метод для потока 3
        public void Process3_Console()
        {
            // чтение из файла в коллекцию
            List<double> data = new List<double>();
            using (BinaryReader brd = new BinaryReader(File.OpenRead(_binFileName))) {
                while(brd.BaseStream.Position < brd.BaseStream.Length) 
                    data.Add(brd.ReadDouble());
            } // using
            StringBuilder sb = OutputToStrigBuilder(data, $"\n\n\tПоток 3: файл \"{_binFileName}\":\n\t");

            // минимвльный элемент
            double min = data.Min();
            double max = data.Max();

            // индекс первого минимального
            int firstMin = data.IndexOf(min);

            // индекс последнего максимального
            int lastMax = data.LastIndexOf(max);

            // меняем местами эти элементы
            (data[firstMin], data[lastMax]) = (data[lastMax], data[firstMin]);

            // запись в файл
            using (BinaryWriter bwr = new BinaryWriter(File.Create(_binFileName)))
                data.ForEach(datum => bwr.Write(datum));
            sb.Append(OutputToStrigBuilder(data, $"\n\n\tПоток 3: первый мин. и послдений макс. обменены \"{_binFileName}\":\n\t"));
            
            // вывод в консоль
            Console.WriteLine(sb);
        } // Process3_Console


        // метод для потока 3 - используется в приложении Windows Forms
        public void Process3() {
            // чтение из файла в коллекцию
            List<double> data = new List<double>();
            using (BinaryReader brd = new BinaryReader(File.OpenRead(_binFileName))) {
                while(brd.BaseStream.Position < brd.BaseStream.Length) 
                    data.Add(brd.ReadDouble());
            } // using
            StringBuilder sb = OutputToStrigBuilder(data, $"\r\nПоток 3: файл \"{_binFileName}\":\r\n");

            // минимвльный элемент
            double min = data.Min();
            double max = data.Max();

            // индекс первого минимального
            int firstMin = data.IndexOf(min);

            // индекс последнего максимального
            int lastMax = data.LastIndexOf(max);

            // меняем местами эти элементы
            (data[firstMin], data[lastMax]) = (data[lastMax], data[firstMin]);

            // запись в файл
            using (BinaryWriter bwr = new BinaryWriter(File.Create(_binFileName)))
                data.ForEach(datum => bwr.Write(datum));
            sb.Append(OutputToStrigBuilder(data, $"\r\nПоток 3: первый мин. и послдений макс. обменены \"{_binFileName}\":\r\n"));

            if (UserControl3.InvokeRequired)
                _form.BeginInvoke((Action)(() => UserControl3.Text = sb.ToString()));
            else
                UserControl3.Text = sb.ToString();
        } // Process3

        // вывод коллекции в StringBuilder
        private StringBuilder OutputToStrigBuilder(List<double> data, string title) {
            StringBuilder sb = new StringBuilder(title);

            foreach (var d in data) {
                sb.Append($"{d,7:f3}");
            }

            sb.AppendLine();
            return sb;
        }

    } // class Processing
}
