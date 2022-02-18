using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Models
{
    // Класс Хранилище
    public class Store
    {
        // хранимое число
        private double? _data = null;


        // лямбда для вывода полученных данных
        public Action<string> ShowData { get; set; }

        #region Конструкторы

        // конструктор инициализирующий
        public Store(Action<string> showData)
        {
            // установка значений
            ShowData = showData;
        }

        #endregion

        #region Методы

        // получить данные
        public double Get()
        {
            // пока данных нет
            while (_data == null) { }

            // получить данные
            lock (this)
            {
                // сохранение данных
                double temp = (double)_data;

                // обнуление данных
                _data = null;

                // вывод данных
                ShowData.Invoke($"Данных нет");

                return temp;
            }
        }


        // загрузить данные
        public void Put(double data)
        {
            // пока есть данные
            while (_data != null) { }

            // загрузить данные
            lock (this)
            {
                _data = data;

                // вывод данных
                ShowData.Invoke($"{_data:n3}");
            }
        }

        #endregion
    }
}
