using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BankDepartmentClassLibrary.Models;    // модели

using static BankDepartmentConsole.Application.App.Utils;       // утилиты

namespace BankDepartmentConsole.Models
{
    // Класс Расширяющие методы
    public static class ExtendedMethods
    {
        #region Вывод платежей в виде таблицы

        // вывода списка платежей в виде таблицы
        public static void ShowTable(this List<Order> orders, string header)
        {
            // вывод шапки таблицы
            orders.ShowHead(header);

            // вывод элементов
            orders.ShowElements();

            // вывод подвала таблицы
            orders.ShowFooter();
        }


        // вывод шапки таблицы
        public static void ShowHead(this List<Order> orders, string header)
        {
            WriteColorXY("     ╔════════════════════════════════════════════════════════════════════════════════════════════════════════╗\n", textColor:ConsoleColor.Magenta);
            WriteColorXY("     ║                                                                                                        ║", textColor:ConsoleColor.Magenta);
            WriteColorXY("Подразделение банка: ", 7, textColor:ConsoleColor.DarkYellow);
            WriteColorXY($"{header}", textColor:ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColorXY("     ╠════╦══════════════════════╦══════════════════════╦═════════════════╦═════════════════╦═════════════════╣\n", textColor:ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                      ║                      ║                 ║                 ║                 ║", textColor:ConsoleColor.Magenta);
            WriteColorXY("N",               7, textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Счет плательщика",     12, textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Счет получателя",    35, textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Баланс плат.",   58, textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Баланс получ.",  76, textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Сумма платежа",  94, textColor:ConsoleColor.DarkYellow);

            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╬══════════════════════╬═════════════════╬═════════════════╬═════════════════╣\n", textColor: ConsoleColor.Magenta);


        }


        // вывод элементов таблицы
        public static void ShowElements(this List<Order> orders)
        {
            // номер элемента
            int n = 1;

            // вывод элементов
            orders.ForEach(o => o.ShowElem(n++));
        }


        // вывод элемента в таблицу
        public static void ShowElem(this Order order, int number)
        {
            WriteColorXY("     ║    ║                      ║                      ║                 ║                 ║                 ║", textColor:ConsoleColor.Magenta);
            WriteColorXY($"{number,2}",                      7, textColor:ConsoleColor.DarkGray);
            WriteColorXY($"{order.SenderAccount}",          12, textColor:ConsoleColor.Cyan);
            WriteColorXY($"{order.ReceiverAccount}",        35, textColor:ConsoleColor.Cyan);
            WriteColorXY($"{order.SenderAmount,15:n0}",     58, textColor:ConsoleColor.Green);
            WriteColorXY($"{order.ReceiverAmount,15:n0}",   76, textColor:ConsoleColor.Green);
            WriteColorXY($"{order.AmountPayment,15:n0}",    94, textColor:ConsoleColor.Green);
            Console.WriteLine();
        }


        // вывод подвала таблицы
        public static void ShowFooter(this List<Order> orders) =>
            WriteColorXY("     ╚════╩══════════════════════╩══════════════════════╩═════════════════╩═════════════════╩═════════════════╝\n", textColor: ConsoleColor.Magenta);

        #endregion
    }
}
