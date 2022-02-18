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
        public static string Table(this List<double> list, string header = "Коллекция")
        {
            StringBuilder sb = new StringBuilder();

            // шапка таблицы
            sb.Append(list.TableHead(header));

            // элементы таблицы
            sb.Append(list.TableElems());

            // подвал таблицы
            sb.Append(list.TableFooter());

            return sb.ToString();
        }

        // вывод шапки таблицы
        public static string TableHead(this List<double> list, string header = "Коллекция") =>
            $"     ╔═══════════════════════════════════════════════╦═══════════════════════════════╗\n" +
            $"     ║ Информация: {header,-33} ║      Количество: {list.Count,11}  ║\n" +
             "     ╠═══════╦═══════╦═══════╦═══════╦═══════╦═══════╬═══════╦═══════╦═══════╦═══════╣\n";

        //  таблицы
        public static string TableElems(this List<double> list)
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

            return sb.ToString();
        }

        //  таблицы
        public static string TableFooter(this List<double> list) =>
            "     ╚═══════╩═══════╩═══════╩═══════╩═══════╩═══════╩═══════╩═══════╩═══════╩═══════╝\n";


        #endregion

        #region Вывод списка ноутбуков в ремонте в виде таблицы

        // вывод списка вещественных чисел
        public static string Table(this List<NotebookModel> list)
        {
            StringBuilder sb = new StringBuilder();

            // шапка таблицы
            sb.Append(list.TableHead());

            // элементы таблицы
            list.ForEach(l => sb.Append(l.TableElem()));

            // подвал таблицы
            sb.Append(list.TableFooter());

            return sb.ToString();
        }

        // вывод шапки таблицы
        public static string TableHead(this List<NotebookModel> list) =>
            $"     ╔═════════════════╦══════════════════════╦═════════════════╦═══════╦════════════╦════════════╦═════════════════════════╦═══════════════════╗\n" +
            $"     ║  Наименование   ║        Модель        ║    Процессор    ║  ОЗУ  ║  Батарея   ║ Диагональ  ║      Неисправность      ║     Владелец      ║\n" +
             "     ╠═════════════════╬══════════════════════╬═════════════════╬═══════╬════════════╬════════════╬═════════════════════════╬═══════════════════╣\n";

        //  таблицы
        public static string TableElem(this NotebookModel model) =>
            $"     ║ {model.Name,-15} ║ {model.Model,-20} ║ {model.Processor,-15} ║ {model.Ram,5} ║ {model.Battery,10} ║ {model.Diagonal,10} ║ {model.Defect,-23} ║ {model.Owner,-17} ║\n";

        //  таблицы
        public static string TableFooter(this List<NotebookModel> list) =>
            "     ╚═════════════════╩══════════════════════╩═════════════════╩═══════╩════════════╩════════════╩═════════════════════════╩═══════════════════╝\n";


        #endregion

        #region Вывод частотного словаря в виде таблицы

        // вывод списка вещественных чисел
        public static string Table(this Dictionary<string, int> dictionary)
        {
            StringBuilder sb = new StringBuilder();

            // шапка таблицы
            sb.Append(dictionary.TableHead());

            // элементы таблицы
            sb.Append(dictionary.TableElems());

            // подвал таблицы
            sb.Append(dictionary.TableFooter());

            return sb.ToString();
        }

        // вывод шапки таблицы
        public static string TableHead(this Dictionary<string, int> dictionary) =>
            $"     ╔══════════════════════╦════════════╗\n" +
            $"     ║        Слово         ║ Количество ║\n" +
             "     ╠══════════════════════╬════════════╣\n";

        //  таблицы
        public static string TableElems(this Dictionary<string, int> dictionary)
        {
            StringBuilder sb = new StringBuilder();

            // проецирование
            dictionary.Select(d => $"     ║ {d.Key,-20} ║ {d.Value,10} ║").ToList().ForEach(s => sb.AppendLine(s));

            return sb.ToString();
        }


        //  таблицы
        public static string TableFooter(this Dictionary<string, int> dictionary) =>
            "     ╚══════════════════════╩════════════╝\n";


        #endregion

    }
}
