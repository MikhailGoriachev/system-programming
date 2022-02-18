using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

namespace HomeWork.Models.Task2
{
    // Класс Корабль
    public class Ship
    {
        private static int _nextId = 1;

        // идентификатор корабля
        public int Id { get; private set; }


        // емкость корабля
        private const int _capacity = 4;

        public int Capacity => _capacity;


        // загружено контейнеров
        private int _count;

        public int Count => _count;


        // текущий статус корабля
        private ShipState _state;

        public ShipState State
        {
            get => _state;
            private set {

                // если текущее состояние отличается от устанавливаемого
                if (value != _state) {

                    // установка значения
                    _state = value;

                    // зажигание события смены состояния
                    ChangeStateEvent(this, EventArgs.Empty);
                }
            }
        }


        // событие смены состояния статуса
        public event EventHandler ChangeStateEvent;


        // порт
        public PortModel Port { get; private set; }


        // лямбда для вывода информации о корабле
        public Action<Ship> ShowInfo;


        #region Конструкторы

        // конструктор инициализрующий
        public Ship(int count, PortModel port, Action<Ship> showInfo)
        {
            // установка значений
            Id = _nextId++;
            _count   = count;
            Port     = port;
            ShowInfo = showInfo;

            // подписка порта на событие смены состояния
            ChangeStateEvent += port.ChangeStateShipEventHandler;
        }

        #endregion

        #region Методы

        // запуск работы по заданию
        public void Run()
        {
            // если на корабле есть контейнеры
            if (_count > 0)
            {
                // смена статуса корабля
                State = ShipState.Unloading;

                // выгрузка контейнеров
                while (_count > 0)
                {
                    // пезультат выгрузки
                    bool? result = Port.PutContainer();

                    // если не удалось погрузить, из-за того, что больше нет кораблей на загрузку
                    if (result == null)
                    {
                        lock (this)
                        {

                            // смена статуса корабля
                            State = ShipState.Failed;
                            ShowInfo.Invoke(this);
                            return;

                        }
                    }

                    // если удалось выгрузить
                    else if (result == true)
                    {
                        _count--;
                        ShowInfo.Invoke(this);
                    }
                }
            }

            // смена статуса корабля
            State = ShipState.Loading;

            // загрузка контейнеров
            while (_count < Capacity)
            {
                // результат погрузки
                bool? result = Port.GetContainer();

                // если не удалось погрузить, из-за того, что больше нет кораблей на загрузку
                if (result == null)
                {
                    // смена статуса корабля
                    State = ShipState.Failed;
                    ShowInfo.Invoke(this);
                    return;
                }

                // если удалось погрузить
                else if (result == true)
                {
                    _count++;
                    ShowInfo.Invoke(this);
                }
            }

            // смена статуса корабля
            State = ShipState.Completed;
            ShowInfo.Invoke(this);

        }

        #endregion
    }
}
