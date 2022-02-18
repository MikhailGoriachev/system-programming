// Объкты системы для синхронизации
//     мьютекс  mutex
//     семафор  semaphore
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SynchronisationSystemOjects
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 09.02.2022 - синхронизация потоков объектами ядра";

            DemoMutex();

            // DemoSemaphore();
        } // Main


        // пример использования критической секции (КС) - класс Mutex
        private static void DemoMutex() {
            TwoNumbers.Number1 = TwoNumbers.Number2 = 0;

            // создание мьютекс
            // !! уникальное имя !!
            Mutex mutex = new Mutex(false, "SynchronisationSystemOjects_MUTEX");

            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 5; i++) {
                // потоки для обработки пары чисел
                // !! "Быстро, но грязно" - в ДЗ не применять !!
                threads.Add(new Thread(() => {
                    for (int j = 0; j < 100; j++) {

                        // правильнее - защищать КС try-finally, гарантирующим
                        // выход из КС
                        // try - finally показывает критическую секцию 
                        try {
                            mutex.WaitOne(); // поставить блокировку - захватить ресурс TwoNumbers
                            TwoNumbers.Number1++;
                            if (TwoNumbers.Number1 % 2 == 0)
                                TwoNumbers.Number2++;
                        } finally {
                            mutex.ReleaseMutex();  // снять блокировку - освободить ресурс TwoNumbers 
                        } // try-finally

                        // имитация обработки в потоке
                        Thread.Sleep(30);
                        
                        if (j % 100 == 0) Console.Write("%");
                    } // for
                    Console.Write("~");
                }));
            } // for i

            // Пуск потоков
            threads.ForEach(t => t.Start());

            // ожидать завершения потоков
            threads.ForEach(t => t.Join());

            Console.WriteLine($"\nDemoMutex: Получили: {TwoNumbers.Number1} {TwoNumbers.Number2}");
        } // DemoMutex


        
    } // class Program
}
