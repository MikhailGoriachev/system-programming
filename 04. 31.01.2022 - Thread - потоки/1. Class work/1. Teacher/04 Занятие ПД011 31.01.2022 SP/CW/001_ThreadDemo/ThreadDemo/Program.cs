using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ThreadDemo
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 31.01.2022 - Пример работы с потоками исполнения";
            Console.WriteLine($"Main: id потока равен {Thread.CurrentThread.ManagedThreadId}");


            // поток исполнения на базе статического метода без параметров
            Thread thread1 = new Thread(Method1);
            thread1.Name = "Method1";


            // поток исполнения на базе статического метода с параметром
            Thread thread2 = new Thread(Method2);
            thread2.Name = "Method2";
            thread2.Priority = ThreadPriority.Highest;
            // thread2.IsBackground = true;
            

            // создание потока из лямбда-выражения - стиль "быстро, но грязно"
            Thread thread4 = new Thread(() => {
                // свойство Thread.CurrentThread - ссылка на текущий поток 
                Thread self = Thread.CurrentThread;
                Console.WriteLine($"{self.Name}: старт потока");

                for (int i = 0; i < 10; i++) {
                    Console.WriteLine($"\t\t\t{self.Name}/{self.ManagedThreadId}: {i,2}");
                    Thread.Sleep(100);
                } // for i
            
                Console.WriteLine($"{self.Name}: завершен");
            });
            thread4.Name = "Method4";
            

            // пример использования метода класса в качестве делегата потока
            // т.е. поток исполнения на базе метода клааса
            ThreadExample obj = new ThreadExample();
            Thread thread3 = new Thread(obj.Method3);
            thread3.Name = "Method3";
            // thread3.IsBackground = true;

            Thread main = Thread.CurrentThread;
            main.Priority = ThreadPriority.Normal;
            main.Name = "Main";

            // Запуск потоков на исполнение
            thread1.Start();
            thread2.Start(8);

            // thread3.Start((object)10);
            thread3.Start(10);
            thread4.Start();

            // какие-то действия, выполняемые в главном потоке выполнения
            for (int i = 0; i < 10; i++) {
                Console.WriteLine($"{main.Name}/{Thread.CurrentThread.ManagedThreadId}: цикл {i}");
                // if (i == 1) {
                //     if (thread2.ThreadState != ThreadState.Suspended)
                //         thread2.Suspend();
                // } // if
                Thread.Sleep(100);
                // if (i == 7) {
                //     if (thread2.ThreadState == ThreadState.Suspended)
                //         thread2.Resume();
                // } // if
            } // for i

            // ожидаем завершения потоков
            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            Console.WriteLine($"{main.Name}: завершен\n");

            // демонстрация повторного запуска потока, можно только создать
            // новый поток, повторный запуск того же потока не предусмотрен
            thread1 = new Thread(Method1);
            thread1.Name = "Method1-repl";
            thread1.Start();
            thread1.Join();
            

            Console.WriteLine("*** конец работы ***");
            // Console.ReadKey();
        } // Main

        // Метод потока - вариант без параметров
        private static void Method1() {
            // свойство Thread.CurrentThread - ссылка на текущий поток 
            Thread self = Thread.CurrentThread;
            Console.WriteLine($"{self.Name}: старт потока");

            for (int i = 0; i < 10; i++) {
                Console.WriteLine($"\t\t\t\t\t{self.Name}/{self.ManagedThreadId}: {i, 2}");
                
                // имитация длительной обработки
                Thread.Sleep(100); 
            } // for i

            Console.WriteLine($"{self.Name}: завершен");
        } // Method1


        // Метод потока - вариант c параметром
        // количество табуляций перед выводом
        private static void Method2(object obj) {
            // свойство Thread.CurrentThread - ссылка на текущий поток 
            Thread self = Thread.CurrentThread;
            Console.WriteLine($"{self.Name}: старт потока");

            try {
                int n = (int)obj;
                for (int i = 0; i < 15; i++) {
                    // выводим n табуляций 
                    for (int j = 0; j < n; j++) Console.Write('\t');
                    Console.WriteLine($"{self.Name}/{self.ManagedThreadId}: {i,2}");
                    Thread.Sleep(100);
                } // for i
            } finally {
                Console.WriteLine($"{self.Name}: завершен");
            } // try-catch

        } // Method2

    } // class Program
}
