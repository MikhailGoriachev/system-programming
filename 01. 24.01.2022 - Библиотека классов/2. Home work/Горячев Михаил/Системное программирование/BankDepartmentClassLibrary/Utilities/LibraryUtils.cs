using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDepartmentClassLibrary.Utilities
{
    // Класс Утилиты
    public class LibraryUtils
    {
        // объект для генерации случайных значений
        public static Random rand = new Random();


        // генерация вещественного числа (min, max]
        public static double GetRand(double min, double max)
        {
            // если диапазон не корректен
            if (min.CompareTo(max) > 0 || max.CompareTo(min) < 0)
                throw new Exception("Utils.GetRand(double min, double max): минимум не может быть больше максимума");

            // число
            double num;

            // генерация числа
            do
            {
                num = rand.Next((int)min, (int)max - 1) + rand.NextDouble();
            } while (num.CompareTo(min) < 0 || num.CompareTo(max) > 0);

            return num;
        }


        // генерация целого числа (min, max]
        public static int GetRand(int min, int max)
        {
            // если диапазон не корректен
            if (min.CompareTo(max) > 0 || max.CompareTo(min) < 0)
                throw new Exception("Utils.GetRand(int min, int max): минимум не может быть больше максимума");

            return rand.Next(min, max);
        }


        // получить номер счёта 
        public static string GetPayNumber(int n = 20)
        {
            StringBuilder number = new StringBuilder();

            for (int i = 0; i < n; i++)
                number.Append($"{GetRand(0, 10)}");

            return number.ToString();
        }

    }
}