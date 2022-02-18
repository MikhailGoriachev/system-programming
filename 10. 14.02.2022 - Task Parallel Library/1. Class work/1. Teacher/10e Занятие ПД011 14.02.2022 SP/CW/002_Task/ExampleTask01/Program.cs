using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   // для Task - библиотека TPL - Task Parallel Library
using System.Threading;         // для Sleep()

namespace ExampleTask01
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 14.02.2022 - введение в TPL, Task Parallel Library";

        // Класс Task из System.Threading.Tasks - начиная с .NET 4.0
        // реализация TPL - Task Parallel Library - библиотека параллельного программирования
        // Task - класс для исполнения длительных операций в отдельном потоке
        // из пула потоков

        // аргумент конструктора объекта класса Task
        //     delegate void Action()
        //     delegate void Action(object obj)

        // Класс Task имеет ряд свойств, с помощью которых мы можем получить информацию об объекте.
        // Некоторые из них:
        // 
        // AsyncState: возвращает объект состояния задачи
        // CurrentId : возвращает идентификатор текущей задачи
        // Exception : возвращает объект исключения, возникшего при выполнении задачи
        // Status    : возвращает статус задачи
        //     Canceled: задача отменена
        //     Created: задача создана, но еще не запущена
        //     Faulted: в процессе работы задачи произошло исключение
        //     RanToCompletion: задача успешно завершена
        //     Running: задача запущена, но еще не завершена
        //     WaitingForActivation: задача ожидает активации и постановки в график выполнения
        //     WaitingForChildrenToComplete: задача завершена и теперь ожидает заврешения прикрепленных к ней дочерних задач
        //     WaitingToRun: задача поставлена в график выполнения, но еще не начала свое выполнение

            // Вывод ид потока и задачи для Main
            // при работе без запуска задачи статическое свойство ид задачи Task.CurrentId
            // равно null
            string str = (Task.CurrentId == null)? "не известен": $"{Task.CurrentId}";
            Console.WriteLine($"Main: Ид потока = {Thread.CurrentThread.ManagedThreadId}, ид задачи = {str}\n");
            
            Task task1 = new Task(Display);  // Display - запускаемый в задаче метод
            task1.Start();  // запуск задачи асинхронно, т.е. параллельно текущему потоку исполнения
            // task1.RunSynchronously();  // запуск задачи синхронно


            // запуск задачи - лямбда-выражение
            Task task2 = new Task(() => {
                Console.WriteLine(
                    "Начало работы метода из Лямбда-выражения. " +
                    $"ИД потока {Thread.CurrentThread.ManagedThreadId}, ИД задачи {Task.CurrentId}");

                // имитация работы метода
                Thread.Sleep(2_000);

                Console.WriteLine("\nЗавершение работы метода из Лямбда-выражения");
            });

            // синхронный запуск задачи
            // task2.RunSynchronously();
            // обычно задачи стартуют асинхронно
            task2.Start();


            // Альтернатива с потоком
            Thread thread = new Thread(Display);
            thread.Start();

            Console.WriteLine("\nВыполняется работа метода Main\n");
            
            // Вывод состояния задач task1, task2
            for (int i = 0; i < 10; i++) {
                Console.WriteLine($"\t\t| task1: {task1.Status} | task2: {task2.Status} |");
                Thread.Sleep(400);
            } // for i

            Task.WaitAll();     // ожидание завершения всех задач 
            // task1.Wait();    // ожидание завершения задачи task1 - Wait()
            // task2.Wait();    // ожидание завершения задачи task2 - Wait()
            thread.Join();      // ожидание завершения потока - Join()

            
            Console.WriteLine("\nВыполняется работа метода Main\n");

            // как и поток задачу невозможно запустить повторно, 
            // после завершения
            // Console.WriteLine("\n\nПовторный запуск задачи");
            // task1.Start();

            // еще один способ создания Task - воспользоваться фабрикой задач
            // :) Фабрика задач запускает задачу на базе одного из потоков из пула потоков :)

            task1 = Task.Factory.StartNew(Display);  // Display - запускаемый в задаче метод

            task2 = Task.Factory.StartNew(Display);  // Display - запускаемый в задаче метод
            Task.WaitAll();
            
            Console.Write("\n\nНажмите любую клавишу для выхода. . . ");
            Console.ReadKey();
        } // Main

        // метод, соответствующий делегату Action - void Action() 
        static void Display() {
            // если метод запускается не в задаче, то Task == null и вывода Task.CurrentId
            // не будет
            Console.WriteLine(
                "\nНачало работы метода Display. " +
                $"ИД потока {Thread.CurrentThread.ManagedThreadId}, ИД задачи {Task.CurrentId}");
            
            // имитация работы метода
            Thread.Sleep(2_000);

            Console.WriteLine("\nЗавершение работы метода Display");
        } // Display
    } // class Program
}
