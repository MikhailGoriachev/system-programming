using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using HomeWork.Models.Task2;        // модели
using HomeWork.Utilities;           // утилиты

/*
 * Задача 2. Для развития навыков программирования многопоточных приложений
 * с синхронизацией потоков напишите приложение WPF по следующему заданию.
 * 
 * В порту 3 причала, каждый из которых может принимать один корабль для 
 * разгрузки или погрузки, если операция возможна (корабли образуют очередь 
 * для погрузки, очередь для разгрузки). Каждый корабль имеет емкость 4 
 * контейнера, разгружается и загружается по одному контейнеру за операцию. 
 * 
 * Промоделировать работу порта на 15 кораблях, начальная загрузка кораблей
 * – случайная, от пустого до полной загрузки.
 * 
 * Если на корабле есть контейнеры, корабль сначала разгружается, затем 
 * загружается – всегда выполняется полная загрузка (4 контейнера). 
 * 
 * Разгрузка корабля возможна, только если в порту не более 40 контейнеров.
 * Погрузка корабля возможна, пока в порту есть хотя бы один контейнер.
*/

namespace HomeWork.Controllers
{
    // Класс Контроллер обработки по заданию 2
    public class Task2Controller : DependencyObject
    {
        // количество кораблей
        public const int CountShips = 15;

        // порт
        private PortModel _port;

        public PortModel Port
        {
            get => _port;
            set => _port = value;
        }


        // коллекция кораблей
        private List<Ship> _ships;

        public List<Ship> Ships
        {
            get => _ships;
            set => _ships = value;
        }


        // лямбда для вывода информации о порту
        public Action<PortModel> ShowPortInfo;


        // лямбда для вывода информации о корабле
        public Action<Ship> ShowShipInfo;

        #region Конструкторы

        // конструктор инициализирующий
        public Task2Controller(Action<PortModel> showPortInfo, Action<Ship> showShipInfo)
        {
            // установка значений
            ShowPortInfo = showPortInfo;
            ShowShipInfo = showShipInfo;

            // инициализация объектов
            _port = new PortModel(ShowPortInfo);
            _ships = new List<Ship>();

            // инициализация списка кораблей
            for (int i = 0; i < CountShips; i++)
                // добавление корабля
                _ships.Add(new Ship(Utils.GetRand(0, 5), _port, ShowShipInfo));
        }

        #endregion

        #region Методы

        // запуск обработки по заданию
        public void Run() => _ships.ForEach(s => new Thread(s.Run).Start());


        // сброс данных для повторного запуска
        public void Reset()
        {
            // инициализация объектов
            _port = new PortModel(ShowPortInfo);
            _ships = new List<Ship>();
            // инициализация списка кораблей
            for (int i = 0; i < CountShips; i++)
                // добавление корабля
                _ships.Add(new Ship(Utils.GetRand(0, 5), _port, ShowShipInfo));
        }

        #endregion
    }
}
