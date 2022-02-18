using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleTask02
{
    class Program 
    {
        // Пул потоков - набор уже готовых управляющих блоков потоков
        // .NET ими пользуется для экономии времени и памяти
        // Гораздо быстрее взять готовый элемент пула, чем создать новый,
        // собственный элемент
         
        // Размещение в массиве Task, экземпляры Task пользуются одними и теми же
        // потоками из пула потоков
        // т.е. одними и теми же управляющими элементами ОС для потоков
        static void Main(string[] args) {
            Console.Title = "Занятие 14.02.2022 - работа с пулом потоков в TPL";

            // первый массив потоков
            Thread[] threads = new Thread[5];

            // Обратите внимание - паттерн Фабрика
            for (int i = 0; i < threads.Length; i++) {
                // создание и запуск потока
                threads[i] = new Thread(Display);
                threads[i].Start();
            } // for i
            
            // второй массив задач, задачи работают быстрее, наглядно видно использование пула 
			// потоков - для работы 30и задач может быть использовано только N < 30 потоков из пула 
			// (N управляющих элементов из коллекции управляющих блоков потоков)
            Task[] tasks2 = new Task[30];
            for (int i = 0; i < tasks2.Length; i++) {
                // задача (метод, выполняющийся в отдельном потоке) формируется
                // лямбда-выражением
                tasks2[i] = Task.Factory.StartNew(() => {
                    int id = Thread.CurrentThread.ManagedThreadId;
                    Console.WriteLine(
                        $"Задача {Task.CurrentId, 2}: Лямбда-выражение как делегат - старт {id, 2}");
                    Thread.Sleep(2000);
                    Console.WriteLine($"Pool   {Task.CurrentId, 2}: Лямбда-выражение как делегат - стоп  {id, 2}");
                });
            } // for i

            Console.WriteLine("Выполняется работа метода Main");

            // ожидание завершения всех задач массива задач
            foreach (var thread in threads) {
                thread.Join();
            }
            Task.WaitAll(tasks2);

            Console.Write("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        } // Main

        // этот метод выполняется в отдельном потоке при создании и запуске Task 
        // соответствует делегату Action
        static void Display() {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            // Task.CurrentId - свойство, ИД потока из пула потоков приложенияв
            Console.WriteLine($"Задача {Task.CurrentId, 2}: Начало работы метода Display, threadId = {threadId, 2}");
            Thread.Sleep(3_000);
            Console.WriteLine($"Задача {Task.CurrentId, 2}: Завершение работы метода Display, threadId = {threadId, 2}");
        } // Display
    } // class Program
}