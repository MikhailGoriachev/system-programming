using HomeWork.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * b.	Потребитель вычисляет z1 и z2 по выражению: z1 = ((a + 2 * sqrt(2a)) - (a / sqrt(2 * a) + 2) + (2 / a - sqrt(2a))) * (sqrt(a) - sqrt(2) / a + 2)
                                                    z2 = 1 / (sqrt(a) + sqrt(2))
*/
namespace HomeWork.Models
{
    // Класс Потребитель
    public class Consumer
    {
        // количество вещественных чисел, которые нужно обработать
        private int _limit;

        public int Limit => _limit;


        // количество обработанных чисел
        private int _counter;

        public int Counter => _counter;


        // ссылка на хранилище
        private Store _store;


        // лямбда для вывода результата обработки числа
        public Action<string, string> ShowResult { get; set; }


        // лямбда для вывода информации о потребителе
        public Action<Consumer> ShowInfo { get; set; }


        // лямбда для вывода данных
        public Action<string> ShowData { get; set; }


        #region Конструктор

        // конструктор инициализирующий
        public Consumer(Store store, int limit, Action<string, string> showResult, Action<Consumer> showInfo, Action<string> showData)
        {
            // установка значений
            _store = store;
            _limit = limit;
            ShowResult = showResult;
            ShowInfo = showInfo;
            ShowData = showData;
        }

        #endregion

        #region Методы

        // запуск работы
        public void Run()
        {
            // обновление данных о потребителе
            ShowInfo.Invoke(this);

            while (_counter < _limit)
            {
                // получение данных
                double value = _store.Get();

                // увеличение счётчика
                _counter++;

                // обработка данных
                ShowResult.Invoke($"{GetZ1(value):n3}", $"{GetZ2(value):n3}");

                // обновление данных о потребителе
                ShowInfo.Invoke(this);

                // обновление о числе
                ShowData.Invoke($"{value:n3}");

                // имитация работы
                Thread.Sleep(Utils.GetRand(1, 7) * 100);
            }
        }

        // вычисление z1
        public double GetZ1(double a) => 
            ((a + 2) / (Math.Sqrt(2 * a)) - (a / (Math.Sqrt(2 * a) + 2)) + (2 /( a - Math.Sqrt(2 * a)))) * ((Math.Sqrt(a) - Math.Sqrt(2)) / (a + 2));


        // вычисление z2
        public double GetZ2(double a) => 1 / (Math.Sqrt(a) + Math.Sqrt(2));

        #endregion

    }
}
