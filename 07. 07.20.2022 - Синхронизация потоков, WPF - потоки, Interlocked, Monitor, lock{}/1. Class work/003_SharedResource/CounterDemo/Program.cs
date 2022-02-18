using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CounterDemo
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 07.02.2022 - доступ к общему ресурсу из нескольких потоков";

            int n = 5;  // количество потоков
            Thread[] threads = new Thread[n];

            int m = 500;    // количество циклов доступа в потоке к общему ресурсу
            int delta = 10; // время имитации обработки, мс

            // создание и запуск потоков, обращающихся к общему ресурсу
            for (int i = 0; i < threads.Length; i++) {
                threads[i] = new Thread(() => {
                    for (int j = 0; j < m; j++) {
                        // обращение к общему ресурсу
                        ++Counter.Сount;
                        
                        /*
                            Примерно в этот код компилируется ++Counter.Сount:
                            1. загрузить Сount в аккумулятор EAX процессора
                            2. инкрементировать EAX
                            3. сохранить EAX в переменную Сount   
                        */ 
                        // Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: Сount = {Counter.Сount}");
                        
                        // имитация длительной обработки
                        Thread.Sleep(delta);
                    }// for j
                });

                threads[i].Start();
            } // for i

            Console.WriteLine($"\tПодождите примерно {2 * delta * m / 1000} сек.\n");

            // ожидать завершения потоков
            foreach (var t in threads) 
                t.Join();

            Console.WriteLine($"\n\n\tПолучили: {Counter.Сount:n0}. Ожидаемое значение: {n*m:n0}");
        } // Main
    } // class Program
}
