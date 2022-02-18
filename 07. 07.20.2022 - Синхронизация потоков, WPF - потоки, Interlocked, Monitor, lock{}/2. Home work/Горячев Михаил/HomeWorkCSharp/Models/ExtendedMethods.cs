using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskLibrary.Models;       // модели

namespace HomeWorkCSharp.Models
{
    public static class ExtendedMethods
    {
        #region Вывод списка вещественных чисел в виде таблицы

        // вывод списка вещественных чисел
        public static void ShowTable(this List<double> list, string header = "Коллекция")
        {
            StringBuilder sb = new StringBuilder();

            // шапка таблицы
            list.ShowTableHead(header);

            // элементы таблицы
            list.ShowTableElems();

            // подвал таблицы
            list.ShowTableFooter();
        }

        // вывод шапки таблицы
        public static void ShowTableHead(this List<double> list, string header = "Коллекция") => Console.WriteLine(
            $"     ╔═══════════════════════════════════════════════╦═══════════════════════════════╗\n" +
            $"     ║ Информация: {header,-33} ║      Количество: {list.Count,11}  ║\n" +
             "     ╠═══════╦═══════╦═══════╦═══════╦═══════╦═══════╬═══════╦═══════╦═══════╦═══════╣");

        // вывод элемента в таблицу
        public static void ShowTableElems(this List<double> list)
        {
            StringBuilder sb = new StringBuilder();

            // количество строк
            int row = list.Count / 10;
            row = row == 0 ? 1 : row;

            for (int i = 0, k = 0; i < row; i++)
            {
                if (i > 0)
                    sb.AppendLine("     ╠═══════╬═══════╬═══════╬═══════╬═══════╬═══════╬═══════╬═══════╬═══════╬═══════╣");

                sb.Append("     ║");

                for (int j = 0; j < 10 && k < list.Count; k++, j++)
                {
                    sb.Append($" {list[k],5:n2} ║");
                }

                sb.AppendLine();
            }

            Console.Write(sb);
        }

        // вывод подвала таблицы
        public static void ShowTableFooter(this List<double> list) => Console.WriteLine(
            "     ╚═══════╩═══════╩═══════╩═══════╩═══════╩═══════╩═══════╩═══════╩═══════╩═══════╝");


        #endregion

        #region Вывод списка ноутбуков в ремонте в виде таблицы

        // вывод списка вещественных чисел
        public static void ShowTable(this List<NotebookModel> list)
        {
            // шапка таблицы
            list.ShowTableHead();

            // элементы таблицы
            list.ForEach(l => l.ShowTableElem());

            // подвал таблицы
            list.ShowTableFooter();
        }

        // вывод шапки таблицы
        public static void ShowTableHead(this List<NotebookModel> list) => Console.WriteLine(
            $"     ╔═════════════════╦══════════════════════╦═════════════════╦═══════╦════════════╦════════════╦═════════════════════════╦═══════════════════╦════════════╗\n" +
            $"     ║  Наименование   ║        Модель        ║    Процессор    ║  ОЗУ  ║  Батарея   ║ Диагональ  ║      Неисправность      ║     Владелец      ║ Стоимость  ║\n" +
             "     ╠═════════════════╬══════════════════════╬═════════════════╬═══════╬════════════╬════════════╬═════════════════════════╬═══════════════════╬════════════╣");

        // вывод элемента в таблицу
        public static void ShowTableElem(this NotebookModel model) => Console.WriteLine(
            $"     ║ {model.Name,-15} ║ {model.Model,-20} ║ {model.Processor,-15} ║ {model.Ram,5} ║ {model.Battery,10} ║ {model.Diagonal,10} ║ {model.Defect,-23} ║ {model.Owner,-17} ║ {model.Price,10} ║");

        // вывод подвала таблицы
        public static void ShowTableFooter(this List<NotebookModel> list) => Console.WriteLine(
            "     ╚═════════════════╩══════════════════════╩═════════════════╩═══════╩════════════╩════════════╩═════════════════════════╩═══════════════════╩════════════╝");


        #endregion

        #region Вывод частотного словаря в виде таблицы

        // вывод списка вещественных чисел
        public static void ShowTable(this SortedDictionary<string, int> dictionary)
        {
            // шапка таблицы
            dictionary.ShowTableHead();

            // элементы таблицы
            dictionary.ShowTableElems();

            // подвал таблицы
            dictionary.ShowTableFooter();
        }

        // вывод шапки таблицы
        public static void ShowTableHead(this SortedDictionary<string, int> dictionary) => Console.WriteLine(
            $"     ╔══════════════════════╦════════════╗\n" +
            $"     ║        Слово         ║ Количество ║\n" +
             "     ╠══════════════════════╬════════════╣");

        // вывод элементов в таблицу
        public static void ShowTableElems(this SortedDictionary<string, int> dictionary) =>
            dictionary.Select(d => $"     ║ {d.Key,-20} ║ {d.Value,10} ║")
                      .ToList()
                      .ForEach(d => Console.WriteLine(d));


        // вывод подвала таблицы
        public static void ShowTableFooter(this SortedDictionary<string, int> dictionary) => Console.WriteLine(
            "     ╚══════════════════════╩════════════╝");


        #endregion

    }
}
