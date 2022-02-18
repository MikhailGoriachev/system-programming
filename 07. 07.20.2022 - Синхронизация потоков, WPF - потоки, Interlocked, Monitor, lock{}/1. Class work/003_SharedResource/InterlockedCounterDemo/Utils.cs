using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterlockedCounterDemo
{
    static class Utils
    {
        // объект для получения случайных чисел
        public static readonly Random Random = new Random(Environment.TickCount);

        // вывести строку в заданную позицию
        public static void WritePos(int left, int top, string str) {
            Console.SetCursorPosition(left, top);
            Console.Write(str);
        } // WritePos

        // пример краткой формы записи метода
        public static void SetPos(int left, int top) =>
            Console.SetCursorPosition(left, top);
        
        // Вычисление наибольшего общего делителя
        public static int Gcd(int a, int b) {
            return b == 0 ? a : Gcd(b, a % b);
        } // Gcd

        // Получение случайного числа
        // краткая форма записи метода - это не лямбда выражение
        public static int GetRand(int lo, int hi) => Random.Next(lo, hi + 1);
        public static double GetRand(double lo, double hi) => lo + (hi - lo)*Random.NextDouble();

    } // class Utils

}
