using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.Utilities;   

/*
 * a.	Производитель генерирует n вещественных случайных чисел (от 10 до 50)
 *      с диапазоном значений от -10 до 20. 
 */
namespace HomeWork.Models
{
    // Класс Производитель
    public class Producer
    {
        // количество вещественных чисел, которые нужно сгенерировать
        private int _limit;

        public int Limit => _limit;


        // количество сгенерированных чисел
        private int _counter;

        public int Counter => _counter;


        // ссылка на хранилище
        private Store _store;


        // лямбда для вывода сгенерированного числа
        public Action<string> ShowNumber { get; set; }


        // лямбда для вывода информации о производителе
        public Action<Producer> ShowInfo { get; set; }


        #region Конструктор

        // конструктор инициализирующий
        public Producer(Store store, int limit, Action<string> showNumber, Action<Producer> showInfo)
        {
            // установка значений
            _store = store;
            _limit = limit;
            ShowNumber = showNumber;
            ShowInfo   = showInfo;
        }

        #endregion

        #region Методы

        // запуск работы
        public void Run()
        {
            // обновление данных о производителе
            ShowInfo.Invoke(this);

            while (_counter < _limit)
            {
                // генерация данных
                double value = Utils.GetRand(5d, 15d); 
                
                // загрузка данных
                _store.Put(value);

                // увеличение счётчика
                _counter++;

                // обработка данных
                ShowNumber.Invoke($"{value:n3}");

                // обновление данных о производителе
                ShowInfo.Invoke(this);

                // имитация работы
                Thread.Sleep(Utils.GetRand(1, 7) * 100);
            }
        }

        #endregion
    }
}
