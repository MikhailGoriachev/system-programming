using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        private static Random _rand = new Random();
        const int ThreadLimit = 20;

        static void Main(string[] args) {
            Console.Title = "Заняте 14.04.2022 - пул потоков";

            // пул потоков -- Thread Pool
            //     пул подключений к БД
            //     пул подключений к серверам сети

            // ThreadPoolInfo();

            // запуск потоков в пуле потоков
            // ThreadPoolRunDemo();

            // вариант синхронизации потоков при помощи системного события
            // с т.н. ручным сбросом
            // ManualResetEventDemo();

            // вариант синхронизации потоков при помощи системного события
            // с т.н. автосбросом
            AutoResetEventDemo();
            Console.ReadKey();
        } // Main


        // информация по пулу потоков
        private static void ThreadPoolInfo() {
            ThreadPool.GetMinThreads(out var minCalc, out var minInputOutput);
            Console.WriteLine($"\nминимальное количество потоков:\nрабочих      {minCalc}\nввода/вывода {minInputOutput}");

            ThreadPool.GetMaxThreads(out var maxCalc, out var maxInputOutput);
            Console.WriteLine($"\nмаксимальное количество потоков:\nрабочих      {maxCalc}\nввода/вывода {maxInputOutput}");

            // установим минимальное количество рабочих потоков
            ThreadPool.SetMinThreads(3, minInputOutput);
            ThreadPool.GetMinThreads(out minCalc, out minInputOutput);
            Console.WriteLine($"\nновое минимальное количество потоков:\nрабочих      {minCalc}\nввода/вывода {minInputOutput}");
        } // ThreadPoolInfo


        // Демонстрация использования пула потоков
        private static void ThreadPoolRunDemo() {
            Console.WriteLine();

            // ставим в очередь запросы на выполнение потока WorkingElement
            // в зависимости от минимального количества потоков в пуле 
            // колчество работающих потоков меняется  
            for (int i = 0; i < ThreadLimit; i++) {
                ThreadPool.QueueUserWorkItem(WorkingElement, i+10);
                // new Thread(WorkingElement).Start(_rand.Next(1, 11));
            } // for i

            for (int i = 0; i < 10; i++) {
                double u = Math.PI + i;
                Console.WriteLine($"\t\t\t\t\tu = {u}");
                Thread.Sleep(1000);
            } // for i

            Console.Title = "Нажмите клавишу <Enter>, пожалуйста";
            Console.ReadKey();
            Console.Title = "Спасибо за сотрудничество";
        } // ThreadPoolRunDemo
        

        // Демо системного события с ручным сбросом - нессколько потоков могут "проскочить"
        // в критическую секцию
        private static void ManualResetEventDemo() {
            Console.Title = "";
            Console.WriteLine("\nСобытие с ручным сбросом\n");
            ManualResetEvent mre = new ManualResetEvent(true);

            // выполним несколько циклов работы
            for (int k = 0; k < 10; ++k) {

                // запуск группы потоков, имитация доступа к общему ресурсу
                // (т.е. треубуется синхронизация потоков)
                for (int i = 0; i < ThreadLimit; i++) {
                    ThreadPool.QueueUserWorkItem(Method, mre);
                } // for i
                Thread.Sleep(2400);
                Console.WriteLine();
                
                // разрешаем повторное использование события / критической секции
                mre.Set();
            } // for k

            Console.Title = "Нажмите клавишу <Enter>, пожалуйста";
            Console.ReadKey();
            Console.Title = "Спасибо за сотрудничество";
        } // ManualResetEventDemo


        // демо системного события с автоматическим сбросом
        // AutoResetEvent - ведет себя как мьютекс, в критическую секцию проходит
        // только один поток
        private static void AutoResetEventDemo() {
            Console.Title = "";
            Console.WriteLine("\nСобытие с автоматическим сбросом\n");
            AutoResetEvent are = new AutoResetEvent(true);

            // выполним несколько циклов работы
            for (int k = 0; k < 10; ++k) {

                // запуск группы потоков, имитация доступа к общему ресурсу
                // (т.е. треубуется синхронизация потоков)
                for (int i = 0; i < ThreadLimit; i++) {
                    ThreadPool.QueueUserWorkItem(Method, are);
                    
                    // альтернативное решение на классе Thread
                    // new Thread(Method).Start(are);
                } // for i
                Thread.Sleep(2400);
                Console.WriteLine();
                
                // разрешаем повторное использование события / критической секции
                are.Set();
            } // for k

            Console.Title = "Нажмите клавишу <Enter>, пожалуйста";
            Console.ReadKey();
            Console.Title = "Спасибо за сотрудничество";
        } // AutoResetEventDemo


        // поток, запускаемый в пуле потоков
        private static void WorkingElement(object state) {
            Console.WriteLine($"id {Thread.CurrentThread.ManagedThreadId, 2}, state {state, 2}");
            Thread.Sleep(_rand.Next(800, 1601));
        } // WorkingElement

        // вспомогательный метод для работы с системным событием
        private static void Method(object obj) {
            EventWaitHandle ev = obj as EventWaitHandle;

            // !!! ev.WaitOne() - блокирующий вызов !!!
            if (ev.WaitOne(10)) {  // блокировка ограничена на 10 мс
                // лучше сначала сбрасывать событие, затем выполнять обработку по заданию
                // ev.Reset();  // сбросил событие 
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId, 2} проскочил");
                // ev.Reset();  // сбросил событие 
            } else {
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId, 2} опоздал");
            } // if
        } // Method

    } // class Program
}
