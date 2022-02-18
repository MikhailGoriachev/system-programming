using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarRentalLibrary.Models.ViewModels;                  // модели

using static CarRentalConsole.Application.App.Utils;       // для использования утилит

namespace CarRentalConsole.Models
{
    // Класс Расширяющие методы
    public static class ExtenededMethods
    {
        #region Вывод таблицы Клиенты

        // вывод клиентов в таблицу
        public static void ShowTable(this List<ClientViewModel> models)
        {
            // вывод шапки таблицы
            models[0].ShowHead();

            // вывод элементов
            models.ForEach(m => m.ShowElem());

            // вывод подвала таблицы
            models[0].ShowFooter();
        }


        // вывод заголовка таблицы 
        static public void ShowHead(this ClientViewModel c)
        {
            WriteColorXY(" ╔════╦══════════════════════╦══════════════════════╦══════════════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY(" ║    ║                      ║                      ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("ID",           3, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Фамилия",      8, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Имя",         31, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Отчество",    54, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Паспорт",     77, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY(" ╠════╬══════════════════════╬══════════════════════╬══════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);

        } // ShowHead


        // вывод элемента таблицы вывода книг с расшифровкой полей
        public static void ShowElem(this ClientViewModel c)
        {
            WriteColorXY(" ║    ║                      ║                      ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{c.Id,2}",        3, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{c.Surname}",     8, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{c.Name}",       31, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{c.Patronymic}", 54, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{c.Passport}",   77, textColor: ConsoleColor.Green);
            Console.WriteLine();
        } // ShowElementsBooks


        // вывод элемента таблицы вывода книг с расшифровкой полей
        static public void ShowFooter(this ClientViewModel c) =>
            WriteColorXY(" ╚════╩══════════════════════╩══════════════════════╩══════════════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion


        #region Вывод таблицы Факты проката

        // вывод таблицы Факты проката
        public static void ShowTable(this List<RentalViewModel> models)
        {
            // вывод шапки таблицы
            models[0].ShowHead();

            // вывод элементов
            models.ForEach(m => m.ShowElem());

            // вывод подвала таблицы
            models[0].ShowFooter();
        }


        // вывод заголовка таблицы 
        public static void ShowHead(this RentalViewModel r)
        {
            WriteColorXY(" ╔════╦══════════════════════╦══════════════════════╦════════════╦════════════╦════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY(" ║    ║                      ║                      ║            ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Клиент",        8, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("ID",            3, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Модель",       31, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Цвет",         54, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Госномер",     67, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Стоимость",    80, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Дата",         93, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Длитель.",    106, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY(" ╠════╬══════════════════════╬══════════════════════╬════════════╬════════════╬════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);

        } // ShowHead


        // вывод элемента таблицы вывода книг с расшифровкой полей
        public static void ShowElem(this RentalViewModel r)
        {
            WriteColorXY(" ║    ║                      ║                      ║            ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{r.Id,2}",             3, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{r.Client}",           8, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{r.Brand}",           31, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{r.Color}",           54, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{r.Plate}",           67, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{r.DateStart:d}",     80, textColor: ConsoleColor.Green);
            WriteColorXY($"{r.Rental,10:n0}",    93, textColor: ConsoleColor.Green);
            WriteColorXY($"{r.Duration,10}",    106, textColor: ConsoleColor.Green);
            Console.WriteLine();
        } // ShowElements


        // вывод элемента таблицы вывода книг с расшифровкой полей
        static public void ShowFooter(this RentalViewModel r) =>
            WriteColorXY(" ╚════╩══════════════════════╩══════════════════════╩════════════╩════════════╩════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion


        #region Вывод результата запроса 4 в таблицу

        // вывод таблицы Факты проката
        public static void ShowTable(this List<Query4ViewModel> models)
        {
            // вывод шапки таблицы
            models[0].ShowHead();

            // вывод элементов
            models.ForEach(m => m.ShowElem());

            // вывод подвала таблицы
            models[0].ShowFooter();
        }

        // вывод заголовка таблицы 
        public static void ShowHead(this Query4ViewModel m)
        {
            WriteColorXY(" ╔════╦════════════╦════════════╦══════════════════════╦════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY(" ║    ║            ║            ║                      ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("ID",           3, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Дата",         8, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Госномер",    21, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Модель",      34, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Стоимость",   57, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Длитель.",    70, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Сумма",       83, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY(" ╠════╬════════════╬════════════╬══════════════════════╬════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
        } // ShowHead


        // вывод элемента таблицы вывода книг с расшифровкой полей
        public static void ShowElem(this Query4ViewModel m)
        {
            WriteColorXY(" ║    ║            ║            ║                      ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{m.Id,2}",             3, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{m.DateStart:d}",      8, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{m.Plate}",           21, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{m.Brand}",           34, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{m.Rental,10:n0}",    57, textColor: ConsoleColor.Green);
            WriteColorXY($"{m.Duration,10:n0}",  70, textColor: ConsoleColor.Green);
            WriteColorXY($"{m.SumPrice,10:n0}",  83, textColor: ConsoleColor.Green);
            Console.WriteLine();
        } // ShowElementsBooks


        // вывод элемента таблицы вывода книг с расшифровкой полей
        public static void ShowFooter(this Query4ViewModel m) =>
            WriteColorXY(" ╚════╩════════════╩════════════╩══════════════════════╩════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion


        #region Вывод результата запроса 5 в таблицу

        // вывод таблицы Факты проката
        public static void ShowTable(this List<Query5ViewModel> models)
        {
            // вывод шапки таблицы
            models[0].ShowHead();

            // вывод элементов
            models.ForEach(m => m.ShowElem());

            // вывод подвала таблицы
            models[0].ShowFooter();
        }

        // вывод заголовка таблицы 
        public static void ShowHead(this Query5ViewModel m)
        {
            WriteColorXY(" ╔════╦══════════════════════╦══════════════════════╦══════════════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY(" ║    ║                      ║                      ║                      ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("ID",           3, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Фамилия",      8, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Имя",         31, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Отчество",    54, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Прокаты",     77, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Длитель.",    90, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY(" ╠════╬══════════════════════╬══════════════════════╬══════════════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
        } // ShowHead


        // вывод элемента таблицы вывода книг с расшифровкой полей
        public static void ShowElem(this Query5ViewModel m)
        {
            WriteColorXY(" ║    ║                      ║                      ║                      ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{m.Id,2}",                3, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{m.Surname}",             8, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{m.Name}",               31, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{m.Patronymic}",         54, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{m.CountRentals,10:n0}", 77, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{m.SumDuration,10:n0}",  90, textColor: ConsoleColor.Green);
            Console.WriteLine();
        } // ShowElementsBooks


        // вывод элемента таблицы вывода книг с расшифровкой полей
        public static void ShowFooter(this Query5ViewModel m) =>
            WriteColorXY(" ╚════╩══════════════════════╩══════════════════════╩══════════════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion


        #region Вывод результата запроса 6 в таблицу

        // вывод результата запроса 6 в таблицу
        public static void ShowTable(this List<Query6ViewModel> models)
        {
            // вывод шапки таблицы
            models[0].ShowHead();

            // вывод элементов
            models.ForEach(m => m.ShowElem());

            // вывод подвала таблицы
            models[0].ShowFooter();
        }

        // вывод заголовка таблицы 
        public static void ShowHead(this Query6ViewModel m)
        {
            WriteColorXY(" ╔════╦══════════════════════╦════════════╦════════════╦════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY(" ║    ║                      ║            ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("ID",           3, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Модель",       8, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Госномер",    31, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Стоимость",   44, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Количество",  57, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Сумма",       70, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Длитель.",    83, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY(" ╠════╬══════════════════════╬════════════╬════════════╬════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);

        } // ShowHead


        // вывод элемента таблицы вывода книг с расшифровкой полей
        public static void ShowElem(this Query6ViewModel m)
        {
            WriteColorXY(" ║    ║                      ║            ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{m.Id,2}",                3, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{m.Brand}",               8, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{m.Plate}",              31, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{m.Rental,10:n0}",       44, textColor: ConsoleColor.Green);
            WriteColorXY($"{m.CountRentals,10:n0}", 57, textColor: ConsoleColor.Green);
            WriteColorXY($"{m.SumRentals,10:n0}",   70, textColor: ConsoleColor.Green);
            WriteColorXY($"{m.SumDuration,10:n0}",  83, textColor: ConsoleColor.Green);
            Console.WriteLine();
        } // ShowElements


        // вывод элемента таблицы вывода книг с расшифровкой полей
        public static void ShowFooter(this Query6ViewModel m) =>
            WriteColorXY(" ╚════╩══════════════════════╩════════════╩════════════╩════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion
    }
}