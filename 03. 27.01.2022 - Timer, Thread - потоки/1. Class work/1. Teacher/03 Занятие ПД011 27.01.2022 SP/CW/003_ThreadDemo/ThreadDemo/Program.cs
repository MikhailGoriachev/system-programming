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
            Console.Title = "Занятие 27.01.2021 - Пример работы с потоками исполнения";
            Console.WriteLine($"Main: id потока равен {Thread.CurrentThread.ManagedThreadId}");

            // создание блока управления потоком
            
            Thread thread0 = new Thread(
                () =>
                {
                    Console.WriteLine($"Привет! Id = {Thread.CurrentThread.ManagedThreadId}, поток стартовал");
                    Thread.Sleep(2_000);
                    Console.WriteLine($"Пока! Id = {Thread.CurrentThread.ManagedThreadId}, поток финишировал");
                });
            thread0.Name = "Lambda";
            thread0.Priority = ThreadPriority.AboveNormal;

            // фоновый режим - завершение потока при завершении главного потока
            // thread0.IsBackground = true; // перевести поток в фоновый режим
            
            thread0.Start(); // запуск потока
            
            Thread thread1 = new Thread(Method1);
            thread1.Name = "Method1";
            thread1.Start();
            
            // !!!! вызывать только тогда, когда ДЕЙСТВИТЕЛЬНО НАДО ожидать
            // !!!! иначе нет параллельной работы 
            thread1.Join();  // текущий поток ожидает завершения thread1
            

            Console.WriteLine("Main: *** конец работы ***");
            // Console.ReadKey();
        } // Main


        // Метод потока - вариант без параметров
        private static void Method1() {
            // свойство Thread.CurrentThread - ссылка на текущий поток 
            Thread self = Thread.CurrentThread;
            Console.WriteLine($"\t\t\t\t{self.Name}/Id = {self.ManagedThreadId}: старт");

            for (int i = 0; i < 10; i++) {
                Console.WriteLine($"\t\t\t\t{self.Name}/Id = {self.ManagedThreadId}: {i, 2}");
                
                // имитация длительной обработки
                Thread.Sleep(100); 
            } // for i

            Console.WriteLine($"\t\t\t\t{self.Name}/Id = {self.ManagedThreadId}: стоп");
        } // Method1

    } // class Program
}
