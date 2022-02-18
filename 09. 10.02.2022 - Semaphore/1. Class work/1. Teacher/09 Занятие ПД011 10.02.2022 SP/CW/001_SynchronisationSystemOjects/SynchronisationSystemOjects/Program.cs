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
            Console.Title = "Занятие 10.02.2022 - синхронизация потоков объектами ядра";

            // DemoSemaphore();

            PhilosopherDinner();
        } // Main


        // пример использования критической секции (КС) - класс Semaphore
        private static void DemoSemaphore() {
            TwoNumbers.Number1 = TwoNumbers.Number2 = 0;
            
            // параметры конструктора
            // первый параметр: начальное значение счетчика свободных ресурсов
            // второй параметр: количество ресурсов
            // особый случай: когда первый и второй параметры == 1 --> мьютекс
            Semaphore semaphore = new Semaphore(1, 1, "SynchronisationSystemOjects_SEMAPHORE");

            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 5; i++) {
                // потоки для обработки пары чисел
                // !! "Быстро, но грязно" - в ДЗ не применять !!
                threads.Add(new Thread(() => {
                    for (int j = 0; j < 100; j++) {

                        // правильнее - защищать КС try-finally, гарантирующим
                        // выход из КС
                        try {
                            // декремент счетчика свободных ресурсов
                            semaphore.WaitOne(); // поставить блокировку (захватить ресурс TwoNumbers)
                            TwoNumbers.Number1++;
                            if (TwoNumbers.Number1 % 2 == 0)
                                TwoNumbers.Number2++;
                        } finally {
                            // инкремент счетчика свободных ресурсов
                            semaphore.Release(); // снять блокировку (освободить ресурс TwoNumbers) 
                        } // try-finally

                        Thread.Sleep(30);
                        if (j % 1000 == 0) Console.Write("$");
                    }
                    Console.Write("@");
                }));
            } // for i

            // Пуск потоков
            threads.ForEach(t => t.Start());

            // ожидать завершения потоков
            threads.ForEach(t => t.Join());

            Console.WriteLine($"\nDemoSemaphore: Получили: {TwoNumbers.Number1:n0} и {TwoNumbers.Number2:n0}");
        } // DemoMutex


        // пример на семафор -- задача об обедающих философах
        // Необходимо накормить обедом из трех блюд N философов,
        // если за столом есть M посадочных мест, где M < N
        // поведение философа
        //    если есть место за столом он садится и ест очередное блюдо
        //    затем гуляет по саду (ожидает)
        private static void PhilosopherDinner() {
            Console.WriteLine("\nОбед философов начинается\n");

            // 2 свободных  места за столом, всего тоже 2 места 
            Semaphore semaphore = new Semaphore(2, 2, "PhilosopherDinner_SEMAPHOR");
            List<Philosopher> philosophers = new List<Philosopher>() {
                new Philosopher(semaphore, "Аристотель"),
                new Philosopher(semaphore, "Платон"),
                new Philosopher(semaphore, "Кант"),
                new Philosopher(semaphore, "Парменид"),
                new Philosopher(semaphore, "Вейнингер")
            };

            List<Thread> philosopersThreads = new List<Thread>(); 
            philosophers.ForEach(p => philosopersThreads.Add(new Thread(p.Behavor)));

            philosopersThreads.ForEach(t => t.Start());
            philosopersThreads.ForEach(t => t.Join());

            Console.WriteLine("\nОбед философов завершен");
        } // PhilosopherDinner
    } // class Program
}
