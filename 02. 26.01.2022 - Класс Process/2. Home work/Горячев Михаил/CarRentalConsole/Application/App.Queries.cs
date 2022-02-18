using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using CarRentalConsole.Models;      // модели

using static CarRentalConsole.Application.App.Utils;       // для использования утилит

namespace CarRentalConsole.Application
{
    public partial class App
    {

        #region 1. Факты проката по заданному номеру автомобиля

        // 1. Факты проката по заданному номеру автомобиля
        public void Point1()
        {
            ShowNavBarMessage("1. Факты проката по заданному номеру автомобиля");

            // параметр запроса
            string param = _controller.GetPlate();

            // вывод параметра
            ShowInfoLine($"Выбранная госномер: {param}");

            // вывод запроса
            _controller.Query1(_controller.GetPlate()).ShowTable();

        }

        #endregion

        #region 2. Факты проката по с заданной моделью автомобиля

        // 2. Факты проката по с заданной моделью автомобиля
        public void Point2()
        {
            ShowNavBarMessage("2. Факты проката по с заданной моделью автомобиля");

            // параметр запроса
            string param = _controller.GetBrand();

            // вывод параметра
            ShowInfoLine($"Выбранная модель: {param}");

            // вывод запроса
            _controller.Query2(param).ShowTable();
        }

        #endregion

        #region 3. Клиенты по заданной серии серии и номеру паспорту

        // 3. Клиенты по заданной серии серии и номеру паспорту
        public void Point3()
        {
            ShowNavBarMessage("3. Клиенты по заданной серии серии и номеру паспорту");

            // параметр запроса
            string param = _controller.GetPassport();

            // вывод параметра
            ShowInfoLine($"Выбранный номер и серия паспорта: {param}");

            // вывод запроса
            _controller.Query3(param).ShowTable();
        }

        #endregion

        #region 4. Все факты проката со стоимостью проката. Сортировка по полю Дата проката

        // 4. Все факты проката со стоимостью проката. Сортировка по полю Дата проката
        public void Point4()
        {
            ShowNavBarMessage("4. Все факты проката со стоимостью проката. Сортировка по полю Дата проката");

            // вывод запроса
            _controller.Query4().ShowTable();
        }

        #endregion

        #region 5. Количество фактов проката и суммарное количество дней проката для каждого клиента

        // 5. Количество фактов проката и суммарное количество дней проката для каждого клиента
        public void Point5()
        {
            ShowNavBarMessage("5. Количество фактов проката и суммарное количество дней проката для каждого клиента");

            // вывод запроса
            _controller.Query5().ShowTable();
        }

        #endregion

        #region 6. Количество фактов проката, сумма, суммарная длительность прокатов для каждого автомобиля

        // 6. Количество фактов проката, сумма, суммарная длительность прокатов для каждого автомобиля
        public void Point6()
        {
            ShowNavBarMessage("6. Количество фактов проката, сумма, суммарная длительность прокатов для каждого автомобиля");

            // вывод запроса
            _controller.Query6().ShowTable();
        }

        #endregion

    }
}
