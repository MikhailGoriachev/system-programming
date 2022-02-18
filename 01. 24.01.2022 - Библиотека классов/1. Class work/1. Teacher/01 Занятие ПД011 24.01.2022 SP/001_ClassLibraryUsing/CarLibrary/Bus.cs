using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class Bus : Car
    {
        // полное свойство с доступом только по чтению
        private readonly int _maxPassengers;
        public int MaxPassengers => _maxPassengers;

        private int _passengers;
        public int Passengers {
            get => _passengers;
            set => _passengers = value > _maxPassengers?_maxPassengers:value;
        }

        public Bus():base() {
            _maxPassengers = 30;
            _passengers = 0;
        } // Bus

        public Bus(int maxSpeed, int speed, int maxPassengers, int passengers):
            base(speed, maxSpeed) {
            _maxPassengers = maxPassengers;
            Passengers = passengers;
        } // Bus

        // высадка пассажиров - уменьшаем их количество в автобусе
        public override void Down() => Passengers--;

        // посадка пассажиров - увеличивем их колиество в автобусе 
        public override void Up() => Passengers++;

        public override string ToString() =>
            $"Bus: Максимальное число пассажиров автобуса: {_maxPassengers}, сейчас пассажиров {_passengers}";
    } // Bus
}
