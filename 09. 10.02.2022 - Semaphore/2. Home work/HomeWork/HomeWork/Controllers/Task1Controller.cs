using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using HomeWork.Models.Task1;        // модели
using HomeWork.Utilities;           // утилиты

/*
 * Задача 1. Разработайте приложение WPF по следующему заданию – реализация
 * паттерна Производитель – Потребитель, для синхронизации использовать 
 * мьютексы:
 * 
 * a.	Есть текстовый файл, содержащий вещественные числа, записанные по 
 *      одному в строке. В файле может быть от 12 до 18 чисел.
 * 
 * b.	Один поток записывает в файл данные и ожидает, пока второй поток 
 *      их прочитает и обработает. Поток извещает другой поток о завершении
 *      записи каждого числа. Поток завершает работу, когда количество чисел 
 *      в файле станет больше 64
 *      
 * c.	Второй поток ожидает, пока данные будут записаны в файл, читает файл
 *      и выводит числа в две строки – в первую строку в исходном порядке 
 *      следования, во вторую строку нечетные (нечетная целая часть) в конце
 *      строки. Поток извещает другой поток о завершении чтения. Поток 
 *      завершает работу, когда количество прочитанных и обработанных чисел 
 *      станет больше 64.
*/

namespace HomeWork.Controllers
{
    // Класс Контроллер обработки по заданию 1
    public class Task1Controller
    {
        // лимит чисел в файле по заданию
        public const int LimitNumbers = 64;


        // производитель чисел
        private ProducerNumbers _producer;

        public ProducerNumbers Producer
        {
            get => _producer;
            set => _producer = value;
        }


        // потребитель чисел
        private ConsumerNumbers _consumer;

        public ConsumerNumbers Consumer
        {
            get => _consumer;
            set => _consumer = value;
        }


        // хранилище данных
        private StoreNumbers _store;

        public StoreNumbers Store
        {
            get => _store;
            set => _store = value;
        }


        // лямбда для вывода обработанных чисел
        public Action<List<double>, List<double>> ShowListNumbers { get; set; }


        // лямбда для вывода записанного числа
        public Action<double> ShowNumber { get; set; }


        // вывод статуса данных в хранилище
        public Action<bool> ShowStatusData { get; set; }


        // название текстового файла для работы с числами
        public string FileName { get; set; }

        #region Конструкторы

        // конструктор инициализирующий
        public Task1Controller(string fileName, Action<List<double>, List<double>> showListNumbers, Action<double> showNumber, Action<bool> showStatusData)
        {
            // установка значений
            ShowListNumbers = showListNumbers;
            ShowNumber      = showNumber;
            ShowStatusData  = showStatusData;
            FileName        = fileName;

            // инициализация объектов
            _store = new StoreNumbers(new Mutex(false, "Task1MutexObject"), FileName, ShowStatusData, LimitNumbers);
            _producer = new ProducerNumbers(_store, ShowNumber);
            _consumer = new ConsumerNumbers(_store, ShowListNumbers);

            // инициализация файла с числами
            StartLoad();
        }

        #endregion

        #region Методы

        // стартовая загрузка (проверяет наличие папки "App_Data" и файлов, если их нет, то создаёт их)
        public void StartLoad()
        {
            // информация о папке и файле
            DirectoryInfo directory = new DirectoryInfo("./App_Data");

            // если нет папки "App_Data"
            if (!directory.Exists)
                directory.Create();

            // создание и заполнение файла numbers.txt
            FillNumbersFile(Utils.GetRand(12, 18));
        }


        // запуск обработки по заданию
        public void Run()
        {
            // запуск потоков
            new Thread(_producer.Run).Start();
            new Thread(_consumer.Run).Start();
        }


        // заполнение файла случайными вещественными числами
        public void FillNumbersFile(int n)
        {
            using (StreamWriter fs = new StreamWriter(File.Create(FileName)))
            {
                // генерация и запись чисел в файл
                Enumerable.Repeat(0, n)
                          .Select(i => Utils.GetRand(10d, 90d))
                          .ToList()
                          .ForEach(i => fs.WriteLine(i));
            }
        }


        // сброс данных для начала обработки
        public void Reset()
        {
            // инициализация объектов
            _store = new StoreNumbers(new Mutex(false, "Task1MutexObject"), FileName, ShowStatusData, LimitNumbers);
            _producer = new ProducerNumbers(_store, ShowNumber);
            _consumer = new ConsumerNumbers(_store, ShowListNumbers);

            // инициализация файла с числами
            StartLoad();
        }

        #endregion
    }
}
