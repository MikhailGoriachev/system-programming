using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;     

using BankDepartmentClassLibrary.Utilities;     // утилиты библиотеки
using BankDepartmentClassLibrary.Models;        // модели

/*
 * Задача 1. Библиотека классов. Разработать библиотеку классов, протестировать
 * ее на скалярных объектах, коллекциях объектов в двух типах приложений: 
 * консольном приложении, приложении Windows Forms.
 * 
 * Разработать библиотеку классов, содержащую классы Order, BankDepartment. 
 * Класс с именем Order должен содержать следующие поля:
 *      •	расчетный счет плательщика;
 *      •	расчетный счет получателя;
 *      •	текущая сумма на счету плательщика (в рублях)
 *      •	текущая сумма на счету получателя (в рублях)
 *      •	сумма платежа
 * Класс с именем BankDepartment (название отделения, коллекцией объектов 
 * Order), реализует для коллекции Order доступ по индексу, добавление, 
 * удаление объекта Order, сериализация в файл формата XML, десериализация из 
 * файла в формате XML.
 * 
 * Запросы приложения:
 *      1.	Платежи заданного плательщика, упорядочивание по получателю
 *      2.	Платежи заданному получателю, упорядочивание по убыванию суммы
 *      3.	Платежи с заданным диапазоном перечисляемой суммы
*/


namespace BankDepartmentClassLibrary.Controllers
{
    // Класс Контроллер обработки по заданию
    public class TaskController
    {
        // отделение банка 
        private BankDepartmentModel _bankDepartment;

        public BankDepartmentModel BankDepartment
        {
            get => _bankDepartment;
            set => _bankDepartment = value;
        }


        // название файла для сохранения
        public string SaveFile { get; set; } = "./App_data/Orders.xml";


        // количество элементов в коллекции 
        public int Count => _bankDepartment.Orders.Count;

        #region Конструкторы и индексатор

        // конструктор по умолчанию
        public TaskController() : this(new BankDepartmentModel($"Отделение №{LibraryUtils.GetRand(1, 50)}",
                                       new List<Order>().GetOrders())) { }


        // конструктор инициализирующий
        public TaskController(BankDepartmentModel bankDepartment)
        {
            // установка значений
            _bankDepartment = bankDepartment;

            // начальная загрузка 
            StartLoad();
        }


        #endregion

        #region Методы


        #region Загрузка/сохранение данных


        // стартовая загрузка (проверяет наличие папки "App_Data" и файла "periodicals.json",
        // если их нет, то создаёт их)
        public void StartLoad()
        {
            // информация о папке и файле
            DirectoryInfo directory = new DirectoryInfo("./App_Data");
            FileInfo file = new FileInfo("./App_Data/Orders.xml");

            // если нет папки "App_Data"
            if (!directory.Exists)
                directory.Create();

            // если нет файла "periodicals.json"
            if (!file.Exists)
            {
                // создание файла
                using (file.Create()) ;

                // сохранение данных
                SerializableXml();
            }

            // загрузка данных из файла
            DeserializableXml();
        }


        // сериализация в формате XML
        public void SerializableXml()
        {
            using (FileStream fs = File.Create(SaveFile))
            {
                _bankDepartment.SerializableXml(fs);
            }
        }


        // десериализация в формате XML
        public void DeserializableXml()
        {
            using (FileStream fs = File.OpenRead(SaveFile))
            {
                _bankDepartment = BankDepartmentModel.DeserializableXml(fs);
            }
        }


        #endregion


        // иницаилазция 
        public void Init()
        {
            // установка новых данных
            BankDepartment = new BankDepartmentModel($"Отделение №{LibraryUtils.GetRand(1, 50)}",
                             new List<Order>().GetOrders());

            // сохранение в файл
            SerializableXml();
        }

        // добавление платежа
        public void Add(Order order) { _bankDepartment.Add(order); SerializableXml(); }


        // добавление коллекции платежей
        public void AddRange() { _bankDepartment.Orders.AddRange(new List<Order>().GetOrders()); 
                                 SerializableXml(); }


        // удаление платежа
        public void Remove(Order order) { _bankDepartment.Remove(order); SerializableXml(); }


        // удаление платежа по индексу
        public void RemoveAt(int index) { _bankDepartment.RemoveAt(index); SerializableXml(); }


        // очистка списка
        public void Clear() { _bankDepartment.Orders.Clear(); SerializableXml(); }


        #region Запросы 

        // 1.	Платежи заданного плательщика, упорядочивание по получателю
        public List<Order> Query1(string sender) =>
            _bankDepartment.Orders.Where(o => o.SenderAccount == sender).ToList();


        // 2.	Платежи заданному получателю, упорядочивание по убыванию суммы
        public List<Order> Query2(string receiver) => 
            _bankDepartment.Orders.Where(o => o.ReceiverAccount == receiver).ToList();


        // 3.	Платежи с заданным диапазоном перечисляемой суммы
        public List<Order> Query3(int lo, int hi) => 
            _bankDepartment.Orders.Where(o => o.AmountPayment >= lo && o.AmountPayment <= hi).ToList();


        #endregion

        #endregion
    }
}
