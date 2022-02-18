using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

using TaskLibrary.Models;           // модели
using TaskLibrary.Utilities;        // утилиты

/*
 * Задача 1. Разработайте библиотеку классов для выполнения обработок:
 * a)	создание файла случайных вещественных чисел (не более 20 чисел), 
 *      создается при первом запуске, при последующих запусках – перемешивание 
 *      данных в файле. Сортировка файла по убыванию и сохранение файла
 * b)	создание коллекции заявок на ремонт ноутбуков (наименование устройства,
 *      модель, тип процессора, объем оперативной памяти, емкость накопителя, 
 *      диагональ экрана, описание неисправности, фамилия и инициалы владельца),
 *      сериализация этой коллекции при первом запуске; десериализация, 
 *      перемешивание и сериализация при последующих запусках. Формат файла 
 *      данных – JSON
 * c)	обработка текстового файла – подсчет (без учета регистра) частоты слов,
 *      результаты выводите в словарь (пары «слово – количество»)
 *      
 * Разработайте консольное приложение и приложение Windows Forms, выполняющее
 * эти обработки. В приложении Windows Forms словарь выводите в DataGridView, 
 * файлы для обработки задавайте стандартным диалогом. В консольном приложении 
 * имена файлов должны быть заданы литеральными константами (хардкод).
*/

namespace TaskLibrary.Controllers
{
    // Класс Контроллер обработки по заданию 1
    public class Task1Controller
    {
        // имя бинарного файла для пункта A
        public string BinFileName { get; set; }


        // имя файла данных для пукнта B
        public string SaveFileNotebooks { get; set; }


        // имя текстового файла для пукнта C
        public string TextFileName { get; set; }


        // коллекция ремонтируемых ноутбуков 
        private List<NotebookModel> _notebooks;

        public List<NotebookModel> Notebooks
        {
            get => _notebooks;
            set => _notebooks = value;
        }


        #region Конструкторы

        // конструктор по умолчанию
        public Task1Controller() : this(@".\App_Data\numbers.bin", @".\App_Data\notebooks.json",
                                        @".\App_Data\words.txt", new List<NotebookModel>().GetNotebooks())
        { }


        // конструктор инициализирующий
        public Task1Controller(string binFileName, string saveFileNotebooks, string textFileName, List<NotebookModel> notebooks)
        {
            // установка значений
            BinFileName = binFileName;
            SaveFileNotebooks = saveFileNotebooks;
            TextFileName = textFileName;
            _notebooks = notebooks;

            // стартовая загрузка 
            StartLoad();
        }

        #endregion

        #region Методы

        #region Загрузка/сохранение данных

        // стартовая загрузка (проверяет наличие папки "App_Data" и файлов, если их нет, то создаёт их)
        public void StartLoad()
        {
            // информация о папке и файле
            DirectoryInfo directory = new DirectoryInfo("./App_Data");
            FileInfo file1 = new FileInfo("./App_Data/numbers.bin");
            FileInfo file2 = new FileInfo("./App_Data/notebooks.json");
            FileInfo file3 = new FileInfo("./App_Data/words.txt");


            // если нет папки "App_Data"
            if (!directory.Exists)
                directory.Create();

            // создание и заполнение файла numbers.bin
            if (!file1.Exists)
                // заполнение файла данных
                FillNumbersFile(20);

            // перемешивание 
            else
                ShuffleNumbersFile();


            // создание и заполнение файла notebooks.json
            if (!file2.Exists)
                // сохранение файла данных
                SaveNotebooks();

            // перемешивание и загрузка
            else
                ShuffleNotebooks();

            // создание и заполнение файла words.txt
            if (!file3.Exists)
            {
                // создание файла
                using (file1.Create()) ;

                // сохранение файла данных
                FillWordsFile();
            }
        }


        // заполнение бинарного файла числами
        public void FillNumbersFile(int n = 10)
        {
            using (FileStream fs = File.Create(BinFileName))
            {
                // бинарный форматтер
                BinaryWriter bw = new BinaryWriter(fs);

                // заполнение файла
                Enumerable.Repeat(0d, n)
                          .Select(e => Utils.GetRand(-9d, 10d))
                          .ToList()
                          .ForEach(e => bw.Write(e));
            }
        }

        // заполнение файла с ноутбуками
        public void FillNotebooks(int n = 10)
        {
            // генерация
            _notebooks = new List<NotebookModel>().GetNotebooks(n);

            // сохранение в файл
            SaveNotebooks();
        }

        // создание текстового файла со словами
        public void FillWordsFile()
        {
            // текст для файла
            string text = "Прежде всего, глубокий уровень погружения предопределяет высокую востребованность распределения \n" +
                "внутренних резервов и ресурсов. Для современного мира понимание сути ресурсосберегающих технологий способствует\n" +
                " повышению качества кластеризации усилий. Но реплицированные с зарубежных источников, современные исследования\n" +
                " набирают популярность среди определенных слоев населения, а значит, должны быть смешаны с не уникальными данными\n" +
                " до степени совершенной неузнаваемости, из-за чего возрастает их статус бесполезности.";

            // запись текста
            File.WriteAllText(TextFileName, text);
        }


        // сохранение данных о ноутбуках в файл
        public void SaveNotebooks()
        {
            using (Stream st = new FileStream(SaveFileNotebooks, FileMode.Create))
            {
                // сериализатор
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<NotebookModel>));

                // запись данных
                serializer.WriteObject(st, _notebooks);
            }
        }


        // перемешивание бинарного файла с числами
        public void ShuffleNumbersFile()
        {
            using (FileStream fs = File.Open(BinFileName, FileMode.Open))
            {
                // форматтер для чтения
                BinaryReader br = new BinaryReader(fs);

                // форматтер для записи
                BinaryWriter bw = new BinaryWriter(fs);

                // количество записей в файле
                int n = (int)(new FileInfo(BinFileName).Length / sizeof(double));

                // перемешивание
                for (int i = 0; i < n; i++)
                    Swap(fs, br, bw, i, Utils.GetRand(0, n));
            }
        }


        // перемешивание записей ноутбуков
        public void ShuffleNotebooks()
        {
            // размер коллекции
            int count = _notebooks.Count;

            // перемешивание
            for (int i = 0, k = Utils.GetRand(0, count); i < count; i++, k = Utils.GetRand(0, count))
                (_notebooks[i], _notebooks[k]) = (_notebooks[k], _notebooks[i]);

            // сохранение в файл
            SaveNotebooks();
        }


        // загрузка данных из файла с числами
        public List<double> LoadNumbers()
        {
            // числа
            List<double> numbers = new List<double>();

            // чтение из файла
            using (FileStream fs = File.OpenRead(BinFileName))
            {
                // форматтер для чтения
                BinaryReader br = new BinaryReader(fs);

                // считывание из файла
                while (br.BaseStream.Position < br.BaseStream.Length)
                    numbers.Add(br.ReadDouble());
            }

            return numbers;
        }


        // загрузка данных о ноутбуках из файла
        public void LoadNotebooks()
        {
            using (Stream st = new FileStream(SaveFileNotebooks, FileMode.Open))
            {
                // сериализатор
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<NotebookModel>));

                // чтение данных
                _notebooks = serializer.ReadObject(st) as List<NotebookModel>;
            }
        }


        // загрузка данных из текстового файла
        public string LoadText() => File.ReadAllText(TextFileName);


        #endregion

        #region Пункт A (Числа)

        // перемещение чисел в файле по индексу
        public void Swap(FileStream fs, BinaryReader br, BinaryWriter bw, int i, int k)
        {
            // установка позиции i-го элемента
            fs.Seek(i * sizeof(double), SeekOrigin.Begin);

            // чтение значения i
            double iValue = br.ReadDouble();

            // установка позиции k-го элемента
            fs.Seek(k * sizeof(double), SeekOrigin.Begin);

            // чтение значение k
            double kValue = br.ReadDouble();

            // установка позиции i-го элемента
            fs.Seek(i * sizeof(double), SeekOrigin.Begin);

            // запись k элемента
            bw.Write(kValue);

            // установка позиции k-го элемента
            fs.Seek(k * sizeof(double), SeekOrigin.Begin);

            // запись i элемента
            bw.Write(iValue);
        }


        // получение значения в файле по индексу
        private double GetValue(FileStream fs, BinaryReader br, int i)
        {
            // установка позиции в файле 
            fs.Seek(i * sizeof(double), SeekOrigin.Begin);

            // чтение значения
            return br.ReadDouble();
        }


        // запись значения в файле по индексу
        private void SetValue(FileStream fs, BinaryWriter bw, int i, double value)
        {
            // установка позиции в файле 
            fs.Seek(i * sizeof(double), SeekOrigin.Begin);

            // установка значения
            bw.Write(value);
        }


        // сортировка бинарного файла по убыванию
        public void SortNumbersDesc()
        {
            // количество записей в файле
            int n = (int)(new FileInfo(BinFileName).Length / sizeof(double));

            // сортировка вставками
            using (FileStream fs = File.Open(BinFileName, FileMode.Open))
            {
                // форматтер для чтения
                BinaryReader br = new BinaryReader(fs);

                // форматтер для записи
                BinaryWriter bw = new BinaryWriter(fs);

                for (var i = 1; i < n; i++)
                {
                    double key = GetValue(fs, br, i);
                    var j = i;
                    while ((j >= 1) && (GetValue(fs, br, j - 1) < key))
                    {
                        Swap(fs, br, bw, j - 1, j);
                        j--;
                    }

                    SetValue(fs, bw, j, key);
                }
            }
        }

        #endregion


        #region Пункт C (Частостный словарь слов)

        // создание частотного словаря слов из файла
        public SortedDictionary<string, int> GetFrequencyDictionary()
        {
            // словарь
            SortedDictionary<string, int> dictonary = new SortedDictionary<string, int>();

            // разделение текста на слова
            List<string> words = LoadText().Split(" -–.,!;:\n\t".ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(w => w.ToLower()).ToList();

            // подсчитывание слов
            while (words.Count != 0)
            {
                // текущее слово
                string word = words[0];

                // добавление слова и значения в словарь
                dictonary[word] = words.Count(w => w == word);

                // удаление слова из коллекции
                words.RemoveAll(r => r == word);
            }

            return dictonary;
        }

        #endregion

        #endregion
    }
}
