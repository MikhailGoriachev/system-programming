using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;       // для использования утилит

namespace HomeWork.Application
{
    public partial class App
    {
        #region Задание 2. Вычисление квадратных уравнений

        /*
         * 2.	С использованием Parallel.ForEach вычислите и поместите результат в
         *      ConcurrencyDictionary для 12 квадратных уравнений.  
        */

        // Задание 2. Вычисление квадратных уравнений
        public void RunPoint2()
        {
            ShowNavBarMessage("Задание 2. Вычисление квадратных уравнений");

            Console.WriteLine("   Вычисление уравнений:\n");

            // вычиление и получение результатов вычислений
            var results = _controller.CalcRootsEquations();

            Console.WriteLine("\n   Результат вычислений:\n");

            // вывод результата
            results.ForEach(r => Console.WriteLine($"\tКвадратное уравнение: a = {r.a,7:f2} | b = {r.b,7:f2} | c = {r.c,7:f2} | " +
                $"Результат x1 = {(r.x1 == double.NaN ? "нет корня" : $"{r.x1,10:f2}")} | " +
                $"x2 = {(r.x2 == double.NaN ? "нет корня" : $"{r.x2,10:f2}")}"));
        }

        #endregion

    }
}
