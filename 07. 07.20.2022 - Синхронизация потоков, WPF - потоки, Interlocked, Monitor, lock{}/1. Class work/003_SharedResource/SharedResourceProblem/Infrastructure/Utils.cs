﻿using System;
using System.Collections.Generic;
using System.Text;


namespace SharedResourceProblem.Infrastructure
{
    // вспомогательные методы и объекты - статический класс, т.е. класс,
    // содержащий только статические члены и методы
    public static class Utils
    {

        // объект для получения случайных чисел
        public static readonly Random Random = new Random(Environment.TickCount);

        // Получение случайного числа
        // краткая форма записи метода - это не лямбда выражение
        public static int GetRandom(int lo, int hi) => Random.Next(lo, hi + 1);

        public static double GetRandom(double lo, double hi) {
            double t = lo + (hi - lo) * Random.NextDouble();
            return Math.Abs(t) < 1.9 ? 0 : t;
        }

        // формирование случайных целых чисел в заданном диапазоне (lo, hi),
        // исключая указанное параметром exclude число
        public static int GetRandomExclude(int lo, int hi, int exclude) {
            int number = 0;
            do
                number = Random.Next(lo, hi);
            while (number == exclude);

            return number;
        } // GetRandomExclude

    } // class Utils
}