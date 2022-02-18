using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

/* 
 * Поля класса Отдел банка:
 *      - название отделения
 *      - коллекцией объектов Order
 */

namespace BankDepartmentClassLibrary.Models
{
    // Класс Отдел банка
    [Serializable]
    public class BankDepartmentModel
    {
        // название отделения
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }


        // коллекцией объектов Order
        private List<Order> _orders;

        public List<Order> Orders
        {
            get => _orders;
            set => _orders = value;
        }


        #region Конструкторы и индексаторы

        // конструктор по умолчанию
        public BankDepartmentModel() : this("Отделение №1", new List<Order>()) { }


        // конструктор инициализирующий
        public BankDepartmentModel(string name, List<Order> orders)
        {
            // установка значений
            _name = name;
            _orders = orders;
        }


        // индексатор по коллекции платежей
        public Order this[int index]
        {
            get => _orders[index];
            set => _orders[index] = value;
        }

        #endregion

        #region Методы

        // добавление платежа
        public void Add(Order order) => _orders.Add(order);


        // удаление платежа
        public void Remove(Order order) => _orders.Remove(order);


        // удаление платежа по индексу
        public void RemoveAt(int index) => _orders.RemoveAt(index);


        // сериализация в формате XML
        public void SerializableXml(FileStream fs)
        {
            // форматтер
            XmlSerializer formatter = new XmlSerializer(typeof(BankDepartmentModel));

            // сериализация 
            formatter.Serialize(fs, this);
        }


        // десериализация в формате XML
        public static BankDepartmentModel DeserializableXml(FileStream fs)
        {
            // форматтер
            XmlSerializer formatter = new XmlSerializer(typeof(BankDepartmentModel));

            // десериализация 
            return formatter.Deserialize(fs) as BankDepartmentModel;
        }


        #endregion
    }
}
