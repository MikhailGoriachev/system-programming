using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Threads;

namespace ProcessingConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Processing processings = new Processing {
                Array1 = new []{ 1, 12,  3, 42, 10, 11},
                Array2 = new[] {11, 12, 32, 10, 7, -1},
                TextFileName = "Thread2Data.txt",
                BinFileName = "Thread3Data.bin"
            };

            // создание и запуск потока
            List<Thread> threads = new List<Thread>(new [] {
                new Thread(processings.Process1_Console),
                new Thread(processings.Process2_Console),
                new Thread(processings.Process3_Console),
            });

            // запуск потоков на парвллельное исполнение
            threads.ForEach(t => t.Start());

            // ожидание завершения потоков
            threads.ForEach(t => t.Join());
        } // Main
    } // class Program
}
