using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TaskLibrary.Controllers;      // контроллеры
using TaskLibrary.Models;           // модели
using HomeWorkCSharp.Models;        // модели

using static HomeWorkCSharp.Application.App.Utils;       // для использования утилит

/*
 * 
 * Задача 1. Разработайте библиотеку классов для выполнения обработок:
 * a)	создание файла случайных вещественных чисел (не более 20 чисел), 
 *      создается при первом запуске, при последующих запусках – перемешивание 
 *      данных в файле. Сортировка файла по убыванию и сохранение файла
 * b)	создание коллекции заявок на ремонт ноутбуков (наименование устройства,
 *      модель, тип процессора, объем оперативной памяти, емкость накопителя, 
 *      диагональ экрана, описание неисправности, фамилия и инициалы владельца),
 *      сериализация этой коллекции при первом запуске; десериализация, 
 *      перемешивание и сериализация при последующих запусках. Формат файла 
 *      данных – JSON
 * c)	обработка текстового файла – подсчет (без учета регистра) частоты слов,
 *      результаты выводите в словарь (пары «слово – количество»)
 *      
 * Разработайте консольное приложение и приложение Windows Forms, выполняющее
 * эти обработки. В приложении Windows Forms словарь выводите в DataGridView, 
 * файлы для обработки задавайте стандартным диалогом. В консольном приложении 
 * имена файлов должны быть заданы литеральными константами (хардкод).
*/

namespace HomeWorkCSharp.Application
{
    public partial class App
    {
        // контроллер обработки по заданию
        private Task1Controller _controller;

        public Task1Controller Controller
        {
            get => _controller;
            set => _controller = value;
        }

        #region Конструкторы

        // конструктор по умолчанию
        public App() : this(new Task1Controller()) { }


        // конструктор инициализирующий
        public App(Task1Controller task1Controller)
        {
            _controller = task1Controller;
        }

        #endregion


        #region Методы

        // запуск обработки по заданию
        public void Run()
        {
            // потоки
            Thread point1 = new Thread(Point1);
            Thread point2 = new Thread(Point2);
            Thread point3 = new Thread(Point3);

            // запуск потоков
            point1.Start();
            point2.Start();
            point3.Start();

            // ожидание завершения потоков
            point1.Join();
            point2.Join();
            point3.Join();
        }

        // пункт 1
        public void Point1()
        {
            StringBuilder sb = new StringBuilder("\n\tПоток 1:\n");

            // таблица элементов до сортировки
            sb.AppendLine(_controller.LoadNumbers().Table("Коллекция до сортировки"));

            // сортировка
            _controller.SortNumbersDesc();

            // таблицы элементов после сортировки
            sb.AppendLine(_controller.LoadNumbers().Table("Коллекция после сортировки"));

            // вывод таблиц
            Console.WriteLine(sb);
        }

        // пункт 2
        public void Point2()
        {
            StringBuilder sb = new StringBuilder("\n\tПоток 2:\n");

            // загрузка ноутбуков для ремонта
            _controller.LoadNotebooks();

            Console.WriteLine(sb.Append(_controller.Notebooks.Table()));
        }

        // пункт 3
        public void Point3()
        {
            StringBuilder sb = new StringBuilder("\n\tПоток 3:\n");

            Console.WriteLine(sb.Append(_controller.GetFrequencyDictionary().Table()));
        }

        #endregion

    }
}
