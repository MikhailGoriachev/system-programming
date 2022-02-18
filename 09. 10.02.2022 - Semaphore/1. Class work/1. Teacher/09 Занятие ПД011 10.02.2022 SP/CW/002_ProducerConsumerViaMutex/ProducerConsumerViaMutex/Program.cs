using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProducerConsumerViaMutex
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 10.02.2022 - реализация паттерна " +
                            "Потребитель - Производитель при помощи мьютекса";

            // взаимодействие потоков - синхронизация потоков
            // Producer - Производитель
            // Consumer - Потребитель
            // Store    - Общий ресурс
            // Mutex    - создаем в единственном экземпляре 
            Mutex mutex = new Mutex(false, "ProducerConsumerViaMutex_MUTEX");
            Store store = new Store(mutex);

            Thread producer = new Thread(new Producer(store).Run);
            Thread consumer = new Thread(new Consumer(store).Run);

            consumer.Start();  // старт потребителя
            producer.Start();  // старт производителя

            // ждать завершения потоков
            producer.Join();
            consumer.Join();
        } // Main
    } // class Program
}
