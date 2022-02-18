using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;

namespace InterlockedCounterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Занятие 07.02.2022 - доступ к общему ресурсу из нескольких потоков";

            // Атомарная операция - непрерываемая операция
            // cli                       -- запрет обработки прерываний
            // операция процессора 1     +  начало атомарной операции
            // ...
            // операция процессора N     #  конец атомарной операции
            // sti                       -- разрешение обработки прерываний
            Demo1();

            // случай неприменимости атомарной операции
            // Console.WriteLine();
            // Demo2();

            // критическая секция с использованием Monitor
            // Console.WriteLine();
            // Demo3();

            // критическая секция с использованием lock
            // Console.WriteLine();
            // Demo4();

            // Решение проблемы цветного вывода в консоль в многопотчоном приложении
            // Console.WriteLine();
            // Demo5();
        } // Main

        // Атомарная операция
        private static void Demo1() {
            int n = 5;
            int m = 500;
            Thread[] threads = new Thread[n];

            for (int i = 0; i < threads.Length; i++) {
                threads[i] = new Thread(() => {
                    for (int j = 0; j < m; j++) {
                        // атомарная операция
                        Interlocked.Increment(ref Counter.Сount);
                        // Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId, 2}: {Counter.Сount}");
                        Thread.Sleep(10);
                    } // for j
                });
                threads[i].Start();
            } // for i

            // ожидать завершения потока
            foreach (var t in threads) {
                t.Join();
            }

            Console.WriteLine($"\nDemo1: Получили: {Counter.Сount:n0}. Ожидаемое значение: {n*m:n0}");
        } // Demo1

        // пример неприменимости Interlocked, т.е. атомарной операции
        // Ожидаемый вывод: n и n/2
        private static void Demo2()
        {
            int n = 5;    // число потоков
            int m = 500;  // количество повторений в каждом потоке

            Thread[] threads = new Thread[n];

            for (int i = 0; i < threads.Length; i++) {
                threads[i] = new Thread(() => {
                    for (int j = 0; j < m; j++) {
                        // ============================== начало составной операции
                        // атомарная операция 
                        Interlocked.Increment(ref TwoNumbers.Number1);

                        // проблема - операция сравнения не атомарная => некоторые 
                        // четные числа теряются
                        if (TwoNumbers.Number1 % 2 == 0)
                            Interlocked.Increment(ref TwoNumbers.Number2);
                        // ============================== конец составной операции

                        Thread.Sleep(10);
                        // Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId, 2}: number1 = {TwoNumbers.number1, 2} number2 = {TwoNumbers.number2, 2}");
                    } // for j
                });
                threads[i].Start();
            } // for i

            // ожидать завершения потока
            foreach (var t in threads) {
                t.Join();
            }

            Console.WriteLine($"\nDemo2: Получили: {TwoNumbers.Number1} {TwoNumbers.Number2}");
        } // Demo2


        // пример использования критической секции (КС) с использованием Monitor
        // Monitor - класс .Net, очень быстрый 
        private static void Demo3() {
            int n = 5;    // количество потков
            int m = 500;  // количество повторений в каждом потоке

            TwoNumbers.Number1 = TwoNumbers.Number2 = 0;

            Thread[] threads = new Thread[n];
            for (int i = 0; i < threads.Length; i++) {
                threads[i] = new Thread(() => {
                    for (int j = 0; j < m; j++) {
                        
                        // правильнее - защищать КС try-finally, гарантирующим
                        // выход из КС
                        try {
                            // начало критической секции ===============================================
                            Monitor.Enter(typeof(TwoNumbers)); 
                            TwoNumbers.Number1++;
                            if (TwoNumbers.Number1 % 2 == 0)
                                TwoNumbers.Number2++;
                            // Monitor.Exit(typeof(TwoNumbers));
                        } finally {
                            // конец критической секции - гарантированное ==============================
                            // освобождение монитора
                            Monitor.Exit(typeof(TwoNumbers));  
                        } // try-finally

                        Thread.Sleep(10);

                    } // for j
                    Console.Write("=");
                });
                threads[i].Start();
            } // for i

            // ожидать завершения потока
            foreach (var t in threads)
                t.Join();

            Console.WriteLine($"\nDemo3: Получили: {TwoNumbers.Number1} {TwoNumbers.Number2}");
        } // Demo3

        // пример использования критической секции (КС) - оператор lock
        // т.е. lock - "синтаксический сахар" для Monitor
        private static void Demo4() {
            TwoNumbers.Number1 = TwoNumbers.Number2 = 0;

            int n = 5;
            Thread[] threads = new Thread[n];
            int m = 500;
            for (int i = 0; i < threads.Length; i++) {
                threads[i] = new Thread(() => {
                    for (int j = 0; j < m; j++) {

                        // упрощение синтаксиса
                        // !!! не должно быть длительной обработки !!!
                        lock(typeof(TwoNumbers)) {  // вход в КС
                            TwoNumbers.Number1++;
                            if (TwoNumbers.Number1 % 2 == 0)
                                TwoNumbers.Number2++;
                        } // lock - выход из КС

                        Thread.Sleep(10);
                    } // for j
                    Console.Write("~");
                });
                threads[i].Start();
            } // for i

            // ожидать завершения потока
            foreach (var t in threads) {
                t.Join();
            }

            Console.WriteLine($"\nDemo4: Получили: {TwoNumbers.Number1:N0} и второй счетчик {TwoNumbers.Number2:N0}");
        } // Demo4


        // решение проблемы многопоточного вывода в консоль
        // на примере цвета
        private static void Demo5() {
            Thread thread1, thread2;

            thread1 = new Thread(() => {
                while (true) {
                    // получить случайное число
                    // если четное - выводим зеленым цветом, иначе не выводим
                    
                    int t = Utils.GetRand(100, 999);
                    if ((t & 1) == 0) {
                        // критическая секция
                        lock (typeof(Console)) {
                            ConsoleColor oldColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{t, 7} ");
                            Console.ForegroundColor = oldColor;
                        } // lock
                    } // if

                    // Thread.Sleep(30);
                }
            });

            thread2 = new Thread(() => {
                while (true) {
                    // получить случайное число
                    // если не четное - выводим желтым цветом, иначе не выводим
                    int t = Utils.GetRand(10, 99);
                    if ((t & 1) != 0) {
                        // критическая секция
                        lock (typeof(Console)) {
                            ConsoleColor oldColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{t, 7} ");
                            Console.ForegroundColor = oldColor;
                        } // lock
                    } // if

                    // Thread.Sleep(30);
                }
            });

            thread1.Start();
            thread2.Start();

            while (true) {
                // в главной функции нет никакой обработки - просто ожидаем выхода

                // читаем клавишу, не выводим "эхо" при нажатии на клавишу
                ConsoleKeyInfo key = Console.ReadKey(false);
                if (key.Key == ConsoleKey.F10) break;
            } // while

            thread1.Abort();
            thread2.Abort();
            Console.ResetColor();
        }
    } // class Program
}
