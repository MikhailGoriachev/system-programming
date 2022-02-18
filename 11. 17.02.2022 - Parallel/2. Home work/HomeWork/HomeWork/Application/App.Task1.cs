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
        #region Задание 1. Работа с помощью класса Parallel

        /*
         * 1.	При помощи класса Parallel вычислить параллельно: корни квадратного 
         *      уравнения, 42е число Фибоначчи (не рекурсивно), объем усеченного конуса.
         */

        // Задание 1. Работа с помощью класса Parallel
        public void RunPoint1()
        {
            ShowNavBarMessage("Задание 1. Работа с помощью класса Parallel");

            // запуск обработок
            Parallel.Invoke(
                    () => CalcAndShowQuadraticEquation((GetDouble(-20, 13), GetDouble(3, 13), GetDouble(3, 13))),
                    () => Console.WriteLine($"\tВычисление 42-го числа Фибоначчи. Результат: {_controller.CalcFibonacciNumber():n0}\n"),
                    () => CalcAndShowConoid()
                );

        }

        #region 1. Вычисление корней квадратного уравнения

        // 1. Вычисление корней квадратного уравнения
        public void CalcAndShowQuadraticEquation((double a, double b, double c) val)
        {
            // результат обработки
            (double x1, double x2) result = _controller.CalcRootsEquation(val);

            // вывод результата
            Console.WriteLine($"\tКвадратное уравнение: a = {val.a:f2}, b = {val.b:f2}, c = {val.c:f2}. Результат x1 = {(result.x1 == double.NaN ? "нет корня" : $"{result.x1:f2}")}, " +
                $"x2 = {(result.x2 == double.NaN ? "нет корня" : $"{result.x2:f2}")}\n");
        }

        #endregion

        #region 3. Вычисление объема усеченного конуса

        // 3. Вычисление объема усеченного конуса
        public void CalcAndShowConoid()
        {
            // данные конуса
            double rTop = GetDouble(1, 5), rBottom = GetDouble(5, 10), height = GetDouble(3, 13);

            // вычисление результата
            double result = _controller.CalcVolumeConoid(rTop, rBottom, height);

            // вывод результата
            Console.WriteLine($"\tВычисление объема усеченного конуса: r1 = {rBottom:f2}, r2 = {rTop:f2}, h = {height:f2}. Результат V = {result:f2}\n");
        }

        #endregion


        #endregion
    }
}
