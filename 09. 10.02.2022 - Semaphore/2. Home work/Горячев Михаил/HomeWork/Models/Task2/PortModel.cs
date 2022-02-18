using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using HomeWork.Utilities;       // утилиты

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
    // Класс Порт
    public class PortModel
    {
        // емкость порта
        public const int Capacity = 40;


        // количество контейнеров на складе
        private int _countContainers;

        public int CountContainers => _countContainers;


        // порт (семафор)
        public Semaphore Port { get; private set; }


        // лямбда для вывода информации о порту
        public Action<PortModel> ShowInfo;


        // очередь кораблей на погрузку
        public ObservableCollection<Ship> QueueLoading { get; private set; }


        // очередь кораблей на выгрузку
        public ObservableCollection<Ship> QueueUnloading { get; private set; }


        #region Конструкторы

        // конструктор инициализирующий
        public PortModel(Action<PortModel> showInfo)
        {
            // установка значений
            ShowInfo = showInfo;
            QueueLoading    = new ObservableCollection<Ship>();
            QueueUnloading  = new ObservableCollection<Ship>();

            Port = new Semaphore(3, 3, "SemaphorePortOnject");
        }

        #endregion

        #region Методы

        // выгрузить контейнеры в порт
        public bool? PutContainer()
        {
            // ожидание свободного места для груза 
            while(_countContainers >= Capacity)
                // если нет кораблей в очереди на погрузку
                if (QueueLoading.Count == 0)
                    return null;

            try
            {
                // занять место в порту (захват ресурса)
                Port.WaitOne();

                lock (this) {

                    // если порт заполнен
                    if (_countContainers >= Capacity)
                        return false;

                    // выгрузить груз в порт
                    _countContainers++;

                    // задержка для демонстрации
                    Thread.Sleep(200);

                    // вывод данных о порте
                    ShowInfo.Invoke(this);
                }
                return true;

            }
            finally
            {
                Port.Release();
            }
        }


        // погрузить контейнеры на корабль
        public bool? GetContainer()
        {
            // если в порту нет груза
            while (_countContainers == 0)
                // если нет кораблей в очереди на выгрузку
                if (QueueUnloading.Count == 0)
                    return null;

            try
            {

                // занять место в порту (захват ресурса)
                Port.WaitOne();

                // !!! без секции lock - работает невалидно. Количество контейнеров в порту становится отрицательным
                // т.к. места 3, несколько мест может быть занято кораблями на погрузку, внутри секции семафора
                // может идти переключение между тремя местами, тогда результат проверки условия if (_countContainers == 0) 
                // возможно будет неактуальным !!!
                lock (this)
                {
                    // если нет контейнеров в порту
                    if (_countContainers == 0)
                        return false;

                    // задержка для демонстрации
                    Thread.Sleep(200);

                    // погрузить груз на корабль
                    _countContainers--;

                    // вывод данных о порте
                    ShowInfo.Invoke(this);
                }
                return true;

            }
            finally
            {
                Port.Release();
            }
        }


        // обработчик события изменения статуса корабля
        public void ChangeStateShipEventHandler(object sender, EventArgs e)
        {
            // текущий корабль
            Ship ship = sender as Ship;

            switch (ship.State)
            {
                // загрузка контейнеров
                case ShipState.Loading:
                    QueueUnloading.Remove(ship);
                    QueueLoading.Add(ship);
                    break;

                // выгрузка контейнеров
                case ShipState.Unloading:
                    QueueLoading.Remove(ship);
                    QueueUnloading.Add(ship);
                    break;

                // не удалось закончить работу
                case ShipState.Failed:
                    QueueLoading.Remove(ship);
                    QueueUnloading.Remove(ship);
                    break;

                // работа закончена
                case ShipState.Completed:
                    QueueLoading.Remove(ship);
                    QueueUnloading.Remove(ship);
                    break;
            }
        }

        #endregion
    }
}