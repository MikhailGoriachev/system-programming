using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;        // утилиты
using System.Threading;


/*
 * Задание 1. В консольном приложении, с использованием TPL реализуйте следующие задачи.
 * 1.	При помощи класса Parallel вычислить параллельно: корни квадратного уравнения, 
 *      42е число Фибоначчи (не рекурсивно), объем усеченного конуса.
 * 2.	С использованием Parallel.ForEach вычислите и поместите результат в 
 *      ConcurrencyDictionary для 12 квадратных уравнений.  
*/


namespace HomeWork.Controllers
{
    // Класс Контроллер обработки по заданию
    public class TaskController
    {
        // коллекция для результатов вычисления 12 квадратных уравнений
        private ConcurrentQueue<(double, double)> _results;

        public ConcurrentQueue<(double, double)> Results
        {
            get => _results; 
            set => _results = value;
        }
        public ConcurrentQueue<(double, double)> ConcurrentQueue { get; }


        #region Конструкторы

        // конструктор по умолчанию
        public TaskController() : this(new ConcurrentQueue<(double, double)>()) { }


        // конструктор инициализирующий
        public TaskController(ConcurrentQueue<(double, double)> results)
        {
            // установка значений
            _results = results;
        }

        #endregion

        #region Методы

        #region Задание 1. Работа с помощью класса Parallel 

        // 1. Вычисление корней квадратного уравнения
        // Источник: https://skysmart.ru/articles/mathematic/kak-reshat-kvadratnye-uravneniya
        public (double, double) CalcRootsEquation((double a, double b, double c) val)
        {
            // вычисление дискриминанта D = b2−4ac
            double d = (val.b * val.b) - 4 * val.a * val.c;

            // если дискриминант отрицательный, зафиксировать, что действительных корней нет;
            if (d < 0)
                return (double.NaN, double.NaN);

            // если дискриминант равен нулю, вычислить единственный корень уравнения по формуле х = −b / 2a;
            else if (d == 0)
                return (-val.b / 2 * val.a, double.NaN);

            // если дискриминант положительный, найти два действительных корня квадратного уравнения по формуле корней
            else
            {
                // квадрат дискриминанта
                double sqrtD = Math.Sqrt(d);

                return ((-val.b - sqrtD) / (2 * val.a), (-val.b + sqrtD) / (2 * val.a));
            }
        }


        // 2. Вычисление числа Фибоначчи (42-го по умолчанию для задания)
        public int CalcFibonacciNumber(int n = 42)
        {
            // первое и второе числа
            int n1 = 1, n2 = 1;

            // текущее число
            int cur = 0;

            // вычисление
            for (int i = 0; i < n; i++)
            {
                // текущее число
                cur = n1 + n2;

                // установка значений для следующей итерации
                n1 = n2;
                n2 = cur;
            }

            return cur;
        }


        // 3. Вычисление объема усеченного конуса
        // Источник: https://allcalc.ru/node/40
        public double CalcVolumeConoid(double rTop, double rBottom, double height) =>
            (Math.PI * height * (rBottom * rBottom + rBottom * rTop + rTop * rTop)) / 3d;

        #endregion

        #region Задание 2. Вычисление квадратных уравнений

        // 1. Вычисление 12 квадратных уравнений
        public List<(double a, double b, double c, double x1, double x2)> CalcRootsEquations(int n = 12)
        {
            // создание очереди результатов
            _results = new ConcurrentQueue<(double, double)>();

            // список квадратных уравнений
            List<(double a, double b, double c)> equations = Enumerable.Repeat(0, n)
                                                                       .Select(e => (GetDouble(-20, 13), GetDouble(3, 13), GetDouble(3, 13)))
                                                                       .ToList();

            // параллельное вычисление квадратных уравнений
            Parallel.ForEach(equations, (e) =>
            {
                // вывод сообщения
                Console.WriteLine($"\tВычисление уравнения! Id задачи: {Task.CurrentId, 2} | Id потока: {Thread.CurrentThread.ManagedThreadId, 2}");

                // добавление результата в очередь
                _results.Enqueue(CalcRootsEquation(e));

                // задержка для демонстрации
                Thread.Sleep(400);
            });

            // коллекция для проецирования
            List<(double a, double b, double c, double x1, double x2)> list = new List<(double a, double b, double c, double x1, double x2)>();

            // получение результатов
            List<(double x1, double x2)> results = _results.ToList();

            // проецирование результирующей коллекции
            for (int i = 0; i < results.Count; i++)
                list.Add((equations[i].a, equations[i].b, equations[i].c, results[i].x1, results[i].x2));

            // получение коллекции
            return list;
        }

        #endregion

        #endregion

    }
}
