using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary.Utilities
{
    // Класс Утилиты
    public static class Utils
    {
        #region Утилиты

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


        // наименование устройства
        public static string[] nameTablet = new[]
        {
            "Офисный",
            "Универсальный",
            "Игровой",
            "Ультрабук",
            "Нетбук",
            "Трансформер"
        };

        // получить наименование устройства
        public static string GetNameTablet() => nameTablet[GetRand(0, nameTablet.Length)];


        // модель
        public static string[] model = new[]
        {
            "ASUS TUF",
            "ASUS VivoBook 15",
            "ASUS ZenBook 14",
            "Asus ExpertBook B1",
            "ASUS ROG Strix",
            "Dell Vostro",
            "Dell Latitude",
            "HP Pavilion",
            "HP Envy",
            "HP 250 G8",
            "HP Laptop",
        };

        // получить тип процессора
        public static string GetModel() => model[GetRand(0, model.Length)];


        // тип процессора
        public static string[] processor = new[]
        {
            "AMD Ryzen 3",
            "AMD Ryzen 5",
            "AMD Ryzen 7",
            "AMD Ryzen 9",
            "Intel Core i3",
            "Intel Core i5",
            "Intel Core i7",
            "Intel Core i9",
        };

        // получить тип процессора
        public static string GetProcessor() => processor[GetRand(0, processor.Length)];


        // объем оперативной памяти
        public static int[] ram = new[]
        {
            4,
            8,
            12,
            16,
            32
        };

        // получить объем оперативной памяти
        public static int GetRam() => ram[GetRand(0, ram.Length)];


        // диагональ экрана
        public static double[] diagonal = new[]
        {
            13d,
            14d,
            15d,
            15.6d,
            16d,
            17d
        };

        // получить диагональ экрана
        public static double GetDiagonal() => diagonal[GetRand(0, diagonal.Length)];


        // описание неисправности
        public static string[] defects = new[]
        {
            "Ноутбук не включается",
            "Разбита матрица",
            "Поломка клавиатуры",
            "Ноутбук выключается",
            "Проблема с изображением"
        };

        // получить описание неисправности
        public static string GetDefect() => defects[GetRand(0, defects.Length)];


        // коллекция персон
        public static string[] persons = new[]{
            "Юрковский М. М.",
            "Якубовская Д. П.",
            "Шапиро Ф. Ф.",
            "Вожжаев С. Д.",
            "Хроменко И. В.",
            "Пелых М. У.",
            "Лапотникова Т. О.",
            "Огородников С. И.",
            "Яйло Е. Н.",
            "Лосева И. С.",
            "Михайлович А. В.",
            "Тарапата М. И.",
            "Трубихин Э. М.",
            "Чмыхало О. Т.",
            "Князьков С. С.",
            "Потемкина Н. П.",
            "Гритченко С. Р.",
            "Селиванов А. М.",
            "Царькова Л. И.",
            "Яструб В. Д.",
            "Мелашенко А. А.",
            "Пономаренко В. Д.",
            "Хавалджи Л. А.",
            "Пархоменко И. В.",
            "Демидова А. А.",
            "Лысенко Е. Е.",
            "Федосенко О. В.",
            "Богатырева Е. А.",
            "Иванова В. С.",
            "Ильюшин С. Ю."
        };

        // получить данные персоны
        public static string GetPerson() => persons[GetRand(0, persons.Length)];

        #endregion

    }
}
