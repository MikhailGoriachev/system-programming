using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProducerConsumer
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 09.02.2022 - синхронизация потоков, паттерн Consumer/Producer, Производитель/Потребитель";

            // взаимодействие потоков - варианция на тему синхронизации потоков
            // Producer - Производитель
            // Consumer - Потребитель
            // Store    - Общий ресурс  
            Store store = new Store();

            Producer producer = new Producer(store);
            Consumer consumer = new Consumer(store);

            Thread threadProducer = new Thread(producer.Run);
            Thread threadConsumer = new Thread(consumer.Run);

            // порядок запуска потоков не имеет значения
            threadConsumer.Start();  // старт потребителя
            threadProducer.Start();  // старт производителя

            // ждать завершения потоков
            threadProducer.Join();
            threadConsumer.Join();
        } // Main
    }
}
