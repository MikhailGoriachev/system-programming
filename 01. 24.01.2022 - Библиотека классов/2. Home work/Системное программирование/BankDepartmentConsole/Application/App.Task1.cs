using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static BankDepartmentConsole.Application.App.Utils;       // для использования утилит

using BankDepartmentConsole.Models;             // модели
using BankDepartmentClassLibrary.Utilities;     // утилиты
using BankDepartmentClassLibrary.Models;        // модели библиотеки

namespace BankDepartmentConsole.Application
{
    public partial class App
    {
        #region Задание 1. Отделение банка

        /*
         * Задание 1. Условие задания
         */

        // Задание 1. Отделение банка
        public void Task1()
        {
            #region Меню

            // пункты меню 
            string[] points =
            {
                "1. Формирование данных",
                "2. Вывод всех платежей",
                "3. Запрос 1",
                "4. Запрос 2",
                "5. Запрос 3",
                "6. Добавить запись",
                "7. Удалить запись",
                "8. Сериализация в формате XML",
                "9. Десериализация в формате XML",
            };

            // нажатая клавиша
            ConsoleKey num;

            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                int x = 5, y = Console.CursorTop + 3;

                // заголовок
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 1. Отделение банка"}", ConsoleColor.Blue);

                y += 2;

                // вывод пунктов меню
                Array.ForEach(points, item => WriteColorXY(item, x, y++));

                // вывод пункта выхода из приложения
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                num = Console.ReadKey().Key;

                try
                {

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

                        // 1. Формирование данных
                        case ConsoleKey.NumPad1:
                            goto case ConsoleKey.D1;
                        case ConsoleKey.D1:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Вывод всех платежей
                        case ConsoleKey.NumPad2:
                            goto case ConsoleKey.D2;
                        case ConsoleKey.D2:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Запрос 1
                        case ConsoleKey.NumPad3:
                            goto case ConsoleKey.D3;
                        case ConsoleKey.D3:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Запрос 2
                        case ConsoleKey.NumPad4:
                            goto case ConsoleKey.D4;
                        case ConsoleKey.D4:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Запрос 3
                        case ConsoleKey.NumPad5:
                            goto case ConsoleKey.D5;
                        case ConsoleKey.D5:
                            Console.Clear();
                            // запуск задания 
                            Point5();
                            break;

                        // 6. Добавить запись
                        case ConsoleKey.NumPad6:
                            goto case ConsoleKey.D6;
                        case ConsoleKey.D6:
                            Console.Clear();
                            // запуск задания 
                            Point6();
                            break;

                        // 7. Удалить запись
                        case ConsoleKey.NumPad7:
                            goto case ConsoleKey.D7;
                        case ConsoleKey.D7:
                            Console.Clear();
                            // запуск задания 
                            Point7();
                            break;

                        // 8. Сериализация в формате XML
                        case ConsoleKey.NumPad8:
                            goto case ConsoleKey.D8;
                        case ConsoleKey.D8:
                            Console.Clear();
                            // запуск задания 
                            Point8();
                            break;

                        // 9. Десериализация в формате XML
                        case ConsoleKey.NumPad9:
                            goto case ConsoleKey.D9;
                        case ConsoleKey.D9:
                            Console.Clear();
                            // запуск задания 
                            Point9();
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
                } // try

                // стандартное исключение
                catch (Exception ex)
                {
                    Console.Clear();

                    // вывод сообщения об ошибке 
                    WriteColor(ex.Message, ConsoleColor.Red);
                    Console.WriteLine();
                    WriteColor(ex.StackTrace, ConsoleColor.Red);
                    Console.WriteLine();
                } // catch

                // обязательная часть
                finally
                {
                    // если пункт меню 0
                    if (num != ConsoleKey.D0 && num != ConsoleKey.NumPad0 && num != ConsoleKey.Escape)
                    {
                        // ввод клавиши для продолжения 
                        WriteColor("\n\n\tНажмите на [Enter] для продолжения...", ConsoleColor.Cyan);
                        Console.CursorVisible = false;
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                        Console.CursorVisible = true;
                    }
                } // finally
            } // while

            #endregion

            #region 1. Формирование данных

            // 1. Формирование данных
            void Point1()
            {
                ShowNavBarMessage("1. Формирование данных");

                // установка значений
                _controller.Init();

                // вывод платежей
                _controller.BankDepartment.Orders.ShowTable($"{_controller.BankDepartment.Name}");
            }

            #endregion

            #region 2. Вывод всех платежей

            // 2. Вывод всех платежей
            void Point2()
            {
                ShowNavBarMessage("2. Вывод всех платежей");

                // вывод платежей
                _controller.BankDepartment.Orders.ShowTable($"{_controller.BankDepartment.Name}");
            }

            #endregion

            #region 3. Запрос 1

            // 3. Запрос 1
            void Point3()
            {
                ShowNavBarMessage("3. Запрос 1");

                // номер счёта 
                string sender = _controller.BankDepartment.Orders.ToArray()[LibraryUtils.GetRand(0, _controller.Count)].SenderAccount;

                ShowInfoLines("Запрос 1", new[] { "Платежи заданного плательщика, упорядочивание по получателю", 
                                                  "",
                                                  $"Номер заданного плательщика: {sender}",
                });

                // вывод платежей
                _controller.Query1(sender).ShowTable($"{_controller.BankDepartment.Name}");
            }

            #endregion

            #region 4. Запрос 2

            // 4. Запрос 2
            void Point4()
            {
                ShowNavBarMessage("4. Запрос 2");

                // номер счёта 
                string receirver = _controller.BankDepartment.Orders.ToArray()[LibraryUtils.GetRand(0, _controller.Count)].ReceiverAccount;

                ShowInfoLines("Запрос 2", new[] { "Платежи заданному получателю, упорядочивание по убыванию суммы",
                                                  "",
                                                  $"Номер заданного получателя: {receirver}",
                });

                // вывод платежей
                _controller.Query2(receirver).ShowTable($"{_controller.BankDepartment.Name}");
            }

            #endregion

            #region 5. Запрос 3

            // 5. Запрос 3
            void Point5()
            {
                ShowNavBarMessage("5. Запрос 3");

                // диапазон значений 
                int lo = LibraryUtils.GetRand(10, 20) * 1_000, hi = lo + 40_000;

                ShowInfoLines("Запрос 3", new[] { "Платежи с заданным диапазоном перечисляемой суммы",
                                                  "",
                                                  $"Заданный диапазон суммы: {lo} - {hi}",
                });

                // вывод платежей
                _controller.Query3(lo, hi).ShowTable($"{_controller.BankDepartment.Name}");
            }

            #endregion

            #region 6. Добавить запись

            // 6. Добавить запись
            void Point6()
            {
                ShowNavBarMessage("6. Добавить запись");

                // добавление платежа
                _controller.Add(Order.GetOrder());

                ShowInfoLine($"Номер добавленной записи: {_controller.Count}");
                            
                // вывод платежей
                _controller.BankDepartment.Orders.ShowTable($"{_controller.BankDepartment.Name}");
            }

            #endregion

            #region 7. Удалить запись

            // 7. Удалить запись
            void Point7()
            {
                ShowNavBarMessage("7. Удалить запись");

                // если список пуст
                if (_controller.Count == 0) {
                    ShowInfoLine("Список платежей пуст, удаление невозможно!");
                    return;
                }    

                // номер записи для удаления
                int n = rand.Next(0, _controller.Count);

                // вывод платежей
                _controller.BankDepartment.Orders.ShowTable($"{_controller.BankDepartment.Name}");

                ShowInfoLine($"Номер удаляемой записи: {n + 1}");

                // удаление записи
                _controller.RemoveAt(n);

                // вывод платежей
                _controller.BankDepartment.Orders.ShowTable($"{_controller.BankDepartment.Name}");
            }

            #endregion

            #region 8. Сериализация в формате XML

            // 8. Сериализация в формате XML
            void Point8()
            {
                ShowNavBarMessage("8. Сериализация в формате XML");

                // сериализация
                _controller.SerializableXml();

                ShowInfoLine($"Данные сериализованы в файл. Путь к файлу: {_controller.SaveFile}");

                // вывод платежей
                _controller.BankDepartment.Orders.ShowTable($"{_controller.BankDepartment.Name}");
            }

            #endregion

            #region 9. Десериализация в формате XML

            // 9. Десериализация в формате XML
            void Point9()
            {
                ShowNavBarMessage("9. Десериализация в формате XML");

                // десериализация
                _controller.DeserializableXml();
                ShowInfoLine($"Данные десериализованы из файла. Путь к файлу: {_controller.SaveFile}");

                // вывод платежей
                _controller.BankDepartment.Orders.ShowTable($"{_controller.BankDepartment.Name}");
            }

            #endregion
        }

        #endregion
    }
}
