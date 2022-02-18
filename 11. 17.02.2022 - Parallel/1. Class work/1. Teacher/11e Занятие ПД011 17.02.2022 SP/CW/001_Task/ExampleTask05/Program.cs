using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ExampleTask05
{
    class Program
    {
        // Задачи продолжения - задачи, запускаемые по завершнии указанных задач
        static void Main(string[] args) {
            Console.Title = "Занятие 17.02.2022 - задачи продолжения в TPL";
            Console.WriteLine("\nРаботает метод Main...");
            
            // Example1();
            // Console.WriteLine("\n\nРаботает метод Main...\n");
            
            Example2();
            Console.WriteLine("\nРаботает метод Main...");

            Thread.Sleep(1500);
            
            Console.Write("\nНажмите Enter для выхода...");
            Console.ReadKey();
        } // Main

        // Задача продолжения - continuation task - вызывается по окончании 
        // текущей задачи
        // Сигнатура метода, используемого в задаче продолжения
        // void ИмяМетода(Task имя)
        // при вызове передается ссылка на предыдущую задачу
        static void Example1() {
            Console.WriteLine("\nРаботает метод Example1...");

            // создание task1
            Task task1 = new Task(() => {
                int threadId = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"task1: Id задачи {Task.CurrentId} - старт. threadId = {threadId}");
                
                // имитация обработки
                Thread.Sleep(1_000);
                
                Console.WriteLine($"task1: Id задачи {Task.CurrentId} - стоп. threadId = {threadId}");
            });

            // создание task2 - задачи продолжения для task1
            // task2 запускается по завершении task1
            // task2 выполняет метод Display
            Task task2 = task1.ContinueWith(Display);

            // еще одна задача продолжения, продолжти задачу 2
            Task task3 = task2.ContinueWith((t) => {
                Console.WriteLine($"Task3: ид предыдущей задачи {t.Id}, поток {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
                Console.WriteLine($"Task3: стоп");
            });

            // запуск task1 приведет к запуску task2 по окончании работы task1
            Console.WriteLine("Старт task1");

            // запуск task1 - цепочки задач
            task1.Start();

            Console.WriteLine("Работает метод Example1...");

            // ждем окончания третьей задачи !!! т.к. task3 завершает цепочку задач !!!
            task3.Wait();
            // Task.WaitAll();
        } // Example1

        // задача продолжения должна иметь сигнатуру
        // void Имя(Task параметр)
        // параметр - ид предыдущей задачи
        static void Display(Task t) {
            // ид текущего потока выполнения
            int threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine($"Display: Id задачи {Task.CurrentId}, старт. Id предыдущей задачи: {t.Id}. Ид потока {threadId}");
            // имитация обработки
            Thread.Sleep(3_000);
            Console.WriteLine($"Display: Id задачи {Task.CurrentId}, стоп. Id предыдущей задачи: {t.Id}. Ид потока {threadId}");
        } // Display

        /// <summary>
        /// Цепочка методов продолжения
        /// </summary>
        static void Example2() {
            Console.WriteLine("\nРаботает метод Example2...\n" +
                              "ex1 -> ex2 -> ex4\n" +
                              "    -> ex3\n\n");

            // локальный метод
            int Method() {
                Console.WriteLine($"ex1. Id задачи: {Task.CurrentId} - старт");
                Console.WriteLine($"ex1. Id задачи: {Task.CurrentId} - стоп");
                return 42;
            } // Method

            // типизированная задача - только что познакомились
            Task<int> ex1 = new Task<int>(Method);

            int Display(Task<int> t) {
                Console.WriteLine($"ex2. Id задачи: {Task.CurrentId}. Предыдущая задача {t.Id} - старт");
                Console.WriteLine($"ex2. Получено из предыдущей задачи {t.Result}");
                Console.WriteLine($"ex2. Id задачи: {Task.CurrentId}. Предыдущая задача {t.Id} - стоп");
                return 24;
            } // Display

            // задача продолжения
            Task<int> ex2 = ex1.ContinueWith(Display);

            // !!! Для одной задачи возможно указать > 1 задачи продолжения !!!
            // эта задача - анонимная, тип параметра t указывать не надо
            // он вычисляется из контекста
            // ex3 - неявное создание задачи :)
            ex1.ContinueWith(t => {
                Console.WriteLine($"ex3. Id задачи: {Task.CurrentId}. Предыдущая задача {t.Id} - старт");
                Thread.Sleep(5_000);
                Console.WriteLine($"ex3. Id задачи: {Task.CurrentId}. Предыдущая задача {t.Id} - стоп");
            });

            // тип параметра t указывать не надо - он вычисляется из контекста
            // !! задача продожения не типизирована, а ex2 - типизирована !!
            Task ex4 = ex2.ContinueWith(t => {
                Console.WriteLine($"ex4. Id задачи: {Task.CurrentId}. Предыдущая задача {t.Id} - старт");
                Thread.Sleep(3_000);
                Console.WriteLine($"ex4. Id задачи: {Task.CurrentId}. Предыдущая задача {t.Id} - стоп");
            });

            // старт цепочки задач
            ex1.Start();

            // для индикации работы выводим статус задачи ex4
            Console.WriteLine("Работает метод Example2...");
            while (!ex4.IsCompleted) {
                Console.WriteLine($"Example2: статус ex4  {ex4.Status}");
                Thread.Sleep(200);
            }
            // Task.WaitAll();
            ex4.Wait();
            Console.WriteLine($"Example2: статус ex4  {ex4.Status}");

            Console.WriteLine($"Example2 завершен | значение из ex1 = {ex1.Result}, ex2 = {ex2.Result}\n");
        } // Example2
       
    } // class Program
}
