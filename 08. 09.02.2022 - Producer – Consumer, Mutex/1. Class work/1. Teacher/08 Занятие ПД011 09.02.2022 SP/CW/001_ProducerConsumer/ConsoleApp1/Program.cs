using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();

            Producer producer = new Producer(store);
            Consumer consumer = new Consumer(store);

            Thread threadProducer = new Thread(producer.Run);
            Thread threadConsumer = new Thread(consumer.Run);

            threadConsumer.Start();
            threadProducer.Start();

            threadConsumer.Join();
            threadProducer.Join();
        }
    }
}
