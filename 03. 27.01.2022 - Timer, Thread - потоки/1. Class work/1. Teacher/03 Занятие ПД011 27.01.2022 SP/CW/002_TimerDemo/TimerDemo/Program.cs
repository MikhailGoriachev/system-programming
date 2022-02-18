using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;       // для класса Timer
using System.Threading.Tasks; // для TPL -- Task Parallel Library

namespace TimerDemo
{
    class Program
    {
        private static int _counter = 10;

        static void Main(string[] args) {
            Console.Title = $"Занятие 27.01.2022 - класс Timer, Id потока приложения {Thread.CurrentThread.ManagedThreadId}";
            Console.ForegroundColor = ConsoleColor.Black;

            // создать таймер, назначить обработчик события таймера - метод 
            // с сигнатурой TimerCallback
            // Timer timer = new Timer(TimerMethod);

            
            // Светофор в стиле "быстро, но грязно"
            int counter = 1;
            Timer timer = new Timer(o => {
                ConsoleColor bg;
                switch (counter % 3) {
                    case 1:
                        bg = ConsoleColor.Red;
                        break;
                    case 2:
                        bg = ConsoleColor.Yellow;
                        break;
                    default:
                        bg = ConsoleColor.Green;
                        break;
                } // switch

                ++counter;
                Console.BackgroundColor = bg;
                Console.Clear();

                string msg = $"Id потока таймера {Thread.CurrentThread.ManagedThreadId}";
                Console.SetCursorPosition((Console.WindowWidth - msg.Length) / 2, Console.WindowHeight / 2);
                Console.Write(msg);
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
            });
            
            // запуск с задержкой 1000 мс, затем период запуска 2000 мс
            timer.Change(1000, 2000);
            
            /*
            // демонстрация параллельной работы основного потока исполнения
            // и потока таймера
            for (int i = 0; i <= 2500; i++) {
                // Thread.CurrentThread.ManagedThreadId - идентификатор потока
                Console.Title = $"Цикл {i}. Id текущего потока {Thread.CurrentThread.ManagedThreadId}";
                Thread.Sleep(100);
            } // for i
            */
            Console.ReadKey();
        } // Main


        // метод с сигнатурой TimerCallback - будет периодически вызываться таймером
        // выполняется в отдельном потоке исполнения
        private static void TimerMethod(object obj) {
            // вывод строки по центру окна консоли
            string msg = $"Я от таймера - {_counter,2}. Id потока таймера {Thread.CurrentThread.ManagedThreadId}";
            Console.SetCursorPosition((Console.WindowWidth - msg.Length)/2, Console.WindowHeight/2);
            Console.Write(msg);
            Console.SetCursorPosition(0, Console.WindowHeight-1);

            // завершение работы таймера - вызов Dispose() в методе таймера
            if (_counter-- == 0) {
                (obj as Timer)?.Dispose();
                msg = "                     Таймер остановлен                              ";
                Console.SetCursorPosition((Console.WindowWidth - msg.Length)/2, Console.WindowHeight/2);
                Console.Write(msg);
                Console.SetCursorPosition(0, Console.WindowHeight-1);
            } // if
        } // TimerMethod
    } // class Program
}
