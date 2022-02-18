using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ExampleTask04
{
    // типизированные задачи в TPL
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 17.02.2022 - типизированные задачи в TPL";
            /* 
             * Запуск специфицированного типом Тип Task
             * Task<Тип> имяЗадачи = new Task<Тип>(() => Метод(параметр));
             * тип возвращаемого Метод'ом значения - Тип
             * 
             * Тип Метод(другойТип параметр) { }
             * 
             * Получить значение, формируемое в Метод'е: 
             * свойство Result - имяЗадачи.Result -- свойство ожидает завершения задачи 
             *                   (блокирует текущий поток исполнения)
             * */

            
            // пример специализации значимым типом
            // DemoValueType();

            // пример специализации ссылочным типом
            DemoReferenceType();

            Console.Write("\nНажмите Enter для выхода...");
            Console.ReadKey();
        } // Main

        // Задача, закрытая значимым типом
        // Пример создания задачи с параметром - вызов в пустой
        // задаче метода с параметром
        private static void DemoValueType() {
            
            // первый запуск
            int t = 12;

            Task<long> task1 = new Task<long>(() => Factorial(t));
            task1.Start();

            // визуализация ожидания завершения task1 
            // имитация параллельной с Task работы основного потока исполнения
            WaitVisualization(task1);

            // !!! task1.Result Блокирует текущий поток исполнения !!!
            Console.WriteLine($"\nФакториал числа {t} равен {task1.Result}");


            int lo = 8, hi = 13;
            Task<long> task2 = new Task<long>(() => { 
                Thread.Sleep(3_000);
                return new Random().Next(lo, hi);
            });
            task2.Start();

            // визуализация ожидания завершения task1 
            // имитация параллельной с Task работы основного потока исполнения
            WaitVisualization(task2);

            // !!! task1.Result Блокирует текущий поток исполнения !!!
            Console.WriteLine($"\nСлучайное число: {task2.Result}");

            Console.WriteLine($"\n\nЗначимый тип long, факториалы чисел от {lo} до {hi}:\n");
            // второй и последующие запуски - с новым кодом, записанным
            // в переменную task1
            for (t = lo+1; t <= hi; t++) {
                // для повторного запуска задаем новый код,
                // захватываем новое значение переменной t
                task1 = new Task<long>(() => Factorial(t));
                task1.Start();

                // визуализация ожидания завершения task1 - моделирование
                // обработки, не нуждающейся в результате задачи
                WaitVisualization(task1);

                // моделирование обработки, нуждающейсяя в результате задачи
                // присвоим результат переменной и выведем переменную
                long f = task1.Result;    // !!! Блокирует текущий поток исполнения !!!

                Console.WriteLine($"\nФакториал числа {t} равен {f}");
            } // for t
            
        } // DemoValueType


        // пример специализации ссылочным типом
        private static void DemoReferenceType() {
            // Пример специализации ссылочным типом (блочное лямбда-выражение, далее будет упрощено)
            Console.WriteLine("\n\nСсылочный тип Book:\n");
            Task<Book> task2 = new Task<Book>(() => {
                Console.WriteLine("Готовим Вашу книгу...");
                Thread.Sleep(3_000);
                return new Book { Title = "Война и мир", Author = "Л.Н. Толстой", Price = 358 };
            });
            task2.Start();  // запуск задачи
            Console.WriteLine("Запрос книги");
            WaitVisualization(task2);
            // task2.Wait();   // блокируем текущий поток, ожидание завершения задачи

            // блокировка до завершения задачи и получение результата задачи
            Book b = task2.Result;

            // повторное обращение к свойству Result допустимо, т.е. то, что в return метода задачи
            // попадает в свойство Result
            Console.WriteLine($"\n\n{b}\n\nПовторное обращение к свойству Result:\n{task2.Result}\n");

            // пример упрощения синтаксиса - линейное лямбда-выражение вместо блочного
            // лямбда-выражения (спасибо ReSharper) 
            task2 = new Task<Book>(
                () => new Book { Title = "C# на примерах", Author = "М.Э. Абрамян", Price = 110 }
            );
            task2.Start();

            // получить результат - значение, возвращаемое методом задачи
            Console.WriteLine($"\nСоздана еще одна книга...\n{task2.Result}\n");
            Console.WriteLine($"\nЕсли Вы не поняли, то эта книга для Вас:\n{task2.Result}\n");

        } // DemoReferenceType

        // вспомогательный, сервисный метод
        private static void WaitVisualization<T>(Task<T> task) {
            // пустой "прогресс-бар"
            Console.Write("\n░░░░░░░░░░░░░░░░░░░░\r");

            Console.CursorVisible = false;
            while (!task.IsCompleted) {
                // заполнение "прогресс-бара"
                Console.Write("▓▓");
                Thread.Sleep(300);
            } // while
            Console.WriteLine();

            Console.CursorVisible = true;
        } // WaitVisualization


        // Метод, который вызывается специализированной задачей Task<long>
        // 6! = 1 * 2 * 3 * 4 * 5 * 6
        static long Factorial(int x) {
            long factorial = 1;

            // имитация длительной обработки
            Thread.Sleep(3_000);

            for (long i = 1; i <= x; i++) {
                factorial *= i;
            } // for i

            return factorial;
        } // Factorial
    } // class Program
 
}
