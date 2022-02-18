using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;       // для использования утилит

/*
 * 1.	При помощи класса Parallel вычислить параллельно: корни квадратного 
 *      уравнения, 42е число Фибоначчи (не рекурсивно), объем усеченного конуса.
 * 
 * 2.	С использованием Parallel.ForEach вычислите и поместите результат в
 *      ConcurrencyDictionary для 12 квадратных уравнений.  
*/

namespace HomeWork.Application
{

    public partial class App
    {

        #region Меню заданий 

        // меню заданий
        public void Menu()
        {
            // пункты меню 
            string[] points =
            {
                "Задание 1. Работа с помощью класса Parallel",
                "Задание 2. Вычисление квадратных уравнений"
            };

            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                // координаты курсора
                int x = 5, y = Console.CursorTop + 3;

                // заголовок
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Главное меню"}", ConsoleColor.Blue);

                y += 2;

                // вывод пунктов меню
                Array.ForEach(points, item => WriteColorXY(item, x, y++));

                // вывод пункта выхода из приложения
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                ConsoleKey num = Console.ReadKey().Key;

                // отчистка консоли
                Console.Clear();

                // обработка ввода 
                switch (num)
                {
                    // выход
                    case ConsoleKey.NumPad0:
                        goto case ConsoleKey.D0;
                    case ConsoleKey.Escape:
                        goto case ConsoleKey.D0;
                    case ConsoleKey.D0:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, y + 5);
                        return;

                    // Задание 1. Работа с помощью класса Parallel
                    case ConsoleKey.NumPad1:
                        goto case ConsoleKey.D1;
                    case ConsoleKey.D1:
                        // запуск задания 
                        RunPoint1();
                        break;

                    // Задание 2. Вычисление квадратных уравнений
                    case ConsoleKey.NumPad2:
                        goto case ConsoleKey.D2;
                    case ConsoleKey.D2:
                        // запуск задания 
                        RunPoint2();
                        break;

                    // если номер задания невалиден
                    default:

                        // установка цвета
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;

                        // позиционирование курсора
                        Console.SetCursorPosition(x, y); Console.WriteLine("         Номер задания невалиден!         ");

                        // выключение курсора
                        Console.CursorVisible = false;

                        // задержка времени
                        Thread.Sleep(1000);

                        // возвращение цвета
                        Console.ResetColor();

                        // включение курсора
                        Console.CursorVisible = true;

                        break;
                } // switch

                // если пункт меню 0
                if (num != ConsoleKey.D0 && num != ConsoleKey.NumPad0 && num != ConsoleKey.Escape)
                {
                    // ввод клавиши для продолжения 
                    WriteColor("\n\n\tНажмите на [Enter] для продолжения...", ConsoleColor.Cyan);
                    Console.CursorVisible = false;
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                    Console.CursorVisible = true;
                }
            }
        } // Menu

        #endregion

    }
}
