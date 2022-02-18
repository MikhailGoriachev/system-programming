using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ExampleTask06
{
    class Program
    {
        // коллекция для многопоточного доступа
        private static ConcurrentDictionary<int, long> _factorials;

        static void Main(string[] args) {
            Console.Title = "Занятие 17.02.2022 - параллельное выполнение задач Task";
            
            /*
            // параллельный запуск нескольких различных задач 
            // Parallel.Invoke(params[] Task)
            // задаем имена методов - делегатов типа Action
            // или лямбда-выражения
            Parallel.Invoke(
                Display,
                () => {
                    Console.WriteLine($"Задача id = {Task.CurrentId} - старт");
                    // имитация обработки
                    Thread.Sleep(2_100);
                    Console.WriteLine($"Задача id = {Task.CurrentId} - стоп");
                },
                () => Factorial1(9),
                () => Factorial1(12)
            );
            */

            int from, to;
            ParallelLoopResult result;
            
            /*
            // параллельный запуск нескольких экземпляров одной задачи
            // параметр метода для этой задачи принимает значения от from до to (исключая значение to)
            // !!! т.е. в примере запускается несколько экземепляров Factorial с параметром от 1 до 6
            // ParallelLoopResult - тип возвращаемого из Parallel.For значения
            // Parallel.For() - блокирующий вызов!
            Console.WriteLine("\nParallel.For:");
            from = 1; to = 7;  // т.е. параметр по факту принимает значения от 1 до 6
            result = Parallel.For(from, to, Factorial1);
            Console.WriteLine($"\nФакториалы для диапазона значений вычислен успешно: {result.IsCompleted}\n");
            */

            /*
            // вычисление параллельно всех факториалов от 1 до 12
            // результат складываем в коллекцию - словарь (пары ключ -> значение)
            // типа ConcurrentDictionary - корректно работает в многопоточной среде
            // https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentdictionary-2.addorupdate?view=netframework-4.8
            _factorials = new ConcurrentDictionary<int, long>();
            from = 1;
            to = 12;  
            // Parallell.For() - блокирующий вызов
            result = Parallel.For(from, to, Factorial);
            Console.WriteLine($"\nФакториалы для диапазона значений вычислены успешно: {result.IsCompleted}");
            Console.WriteLine();

            // вывод словаря - коллекция пар ключ -> значение
            // item.Key   - аргумент факториала
            // item.Value - значение факториала
            foreach (var item in _factorials) {
                Console.WriteLine($"{item.Key, 2:N0}! = {item.Value:N0}");    
            }
            Console.WriteLine();
            */

            /*
            // Parallel.ForEach() - запуск задачи для каждого элемента коллекции (IEnumerable) 
            // ParallelLoopResult - тип возвращаемого из Parallel.ForEach значения 
            
            Console.WriteLine("\nParallel.ForEach:");
            result = Parallel.ForEach<int>(new List<int>() { 1, 3, 5, 8 }, Factorial1);
            Console.WriteLine($"\nФакториал для коллекции значений вычислен успешно: {result.IsCompleted}");
            Console.WriteLine();
            */

            
            // _factorials.Clear();
            _factorials = new ConcurrentDictionary<int, long>();
            result = Parallel.ForEach<int>(new List<int>() { 1, 3, 5, 8}, Factorial);
            Console.WriteLine($"\nФакториал для коллекции значений вычислен успешно: {result.IsCompleted}");
            foreach (var item in _factorials) {
                Console.WriteLine($"{item.Key:N0}! = {item.Value:N0}");    
            }
            Console.WriteLine("\n--------------------------------------------------------------\n");
            
            
            /*
            // Демонстрация метода объект.Break() для прерывания того потока из
            // набора параллельно выполняемых потоков в котором вызван объект Break()
            Console.WriteLine("\n\nParallel.For и завершение цикла при помощи Break()");
            result = Parallel.For(1, 12, Factorial2);
            if (!result.IsCompleted)
                Console.WriteLine($"Вызов Break() на итерации {result.LowestBreakIteration}");
            else
                Console.WriteLine("Parallel.For() выполнен полностью");
            Console.WriteLine();
            */

            /*
            Console.WriteLine("\nBreak и сохранение в коллекцию значений\n");
            // _factorials.Clear();
            _factorials = new ConcurrentDictionary<int, long>();
            result = Parallel.For(1, 12, Factorial3);
            if (!result.IsCompleted)
                Console.WriteLine($"Вызов Break() на итерации {result.LowestBreakIteration}");
            else
                Console.WriteLine("Parallel.For() выполнен полностью");
            foreach (var item in _factorials) {
                Console.WriteLine($"{item.Key:N0}! = {item.Value:N0}");
            }
            Console.WriteLine();
            */
            
            /*
            // Прерывание вычислений при работе с коллекцией аргументов
            // !!! даже если условия прерывания сработает на первом элементе, есть
            // !!! ненулевая вероятность выполнения нескольких потоков с другими
            // !!! элементами коллекции
            Console.WriteLine("\nParallel.ForEach:");
            result = Parallel.ForEach<int>(new List<int>() { 9, 5, 9, 5, 6, 4, 8 }, Factorial2);
            if (!result.IsCompleted)
                Console.WriteLine($"Вызов Break() на итерации {result.LowestBreakIteration}");
            else
                Console.WriteLine("Parallel.ForEach() выполнен полностью");
            Console.WriteLine();
            */

            Console.Write("\nНажмите любую клавишу для выхода. . .");
            Console.ReadKey();
        } // Main

        // метод для запуска в Invoke
        static void Display() {
            Console.WriteLine($"Display: id = {Task.CurrentId} - старт");
            Thread.Sleep(3000);
            Console.WriteLine($"Display: id = {Task.CurrentId} - стоп");
        } // Display

        // метод для запуска в Invoke, Parallel.For(), Parallel.ForEach()
        // параметр x - очередное значение, получаемое из For(), ForEach()
        static void Factorial1(int x) {
            Console.WriteLine($"Factorial1: id = {Task.CurrentId}, tid = {Thread.CurrentThread.ManagedThreadId}, аргумент {x}");
            int result = 1;

            for (int i = 1; i <= x; i++) {
                result *= i;
            } // for i
            
            // !!! только для имитации длительного процесса !!!
            // !!! в реальных задачах не использовать !!!
            Thread.Sleep(1800);
            Console.WriteLine($"Factorial1: id = {Task.CurrentId}, результат {x}! = {result}");
        } // Factorial1

        // Сохранение найденного факториала и аргумента x в 
        // словаре ConcurrentDictionary - специальная коллекция
        // для многопоточной работы
        private static void Factorial(int x) {
            // Console.WriteLine($"Factorial: id = {Task.CurrentId}, tid = {Thread.CurrentThread.ManagedThreadId}, аргумент {x}");
            long result = 1;
            
            for (int i = 1; i <= x; i++) {
                result *= i;
            }

            Thread.Sleep(1800);
            // Console.WriteLine($"Factorial: id = {Task.CurrentId}, стоп");

            // добавление в словарь
            // ключ, значение, метод добавления
            _factorials.AddOrUpdate(x, result, (k, v) => v);
        } // Factorial

        // метод для запуска в For() для демонстрации Break() 
        static void Factorial2(int x, ParallelLoopState pls) {
            Console.WriteLine($"Factorial2: id = {Task.CurrentId}, tid = {Thread.CurrentThread.ManagedThreadId}, аргумент {x}");

            // pls.Break() - прерывание работы очередного потока
            // когда параметр метода > 5, то прерываются соответствующие потоки
            if (x > 5) { pls.Break(); return; }

            int result = 1;
            for (int i = 1; i <= x; i++) {
                result *= i;
            }

            Console.WriteLine($"Factorial2: id = {Task.CurrentId}, результат {x}! = {result}");
        } // Factorial2

        // метод для запуска в For() для демонстрации Break() 
        static void Factorial3(int x, ParallelLoopState pls) {
            Console.WriteLine($"Factorial3: id = {Task.CurrentId}, tid = {Thread.CurrentThread.ManagedThreadId}, аргумент {x}");

            // pls.Break() - прерывание работы очередного потока
            // когда параметр метода > 8, то прерываются соответствующие потоки
            if (x > 8) { pls.Break(); return; }

            int result = 1;
            for (int i = 1; i <= x; i++) {
                result *= i;
            }

            Console.WriteLine($"Factorial3: id = {Task.CurrentId} - стоп");

            // добавление в словарь
            // ключ, значение, метод добавления
            _factorials.AddOrUpdate(x, result, (k, v) => v);
        } // Factorial3
    } // class Program
}
