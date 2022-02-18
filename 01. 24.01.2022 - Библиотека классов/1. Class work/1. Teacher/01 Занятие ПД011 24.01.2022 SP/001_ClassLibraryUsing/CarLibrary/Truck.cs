using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class Truck: Car
    {
        // полное свойство с доступом только по чтению
        private int maxCargo;
        public int MaxCargo => maxCargo;

        private int cargo;

        public int Cargo {
            get => cargo;
            set => cargo = value > maxCargo ? maxCargo : value;
        }

        public Truck():base()
        {
            maxCargo = 18500;
            cargo = 0;
        }
        public Truck(int maxSpeed, int speed, int maxCargo, int cargo):
            base(speed, maxSpeed)
        {
            this.maxCargo = maxCargo;
            Cargo = cargo;
        }

        // выгрузка груза
        public override void Down() => Cargo = 0;

        // загрузка груза
        public override void Up() => Cargo = maxCargo;

        public override string ToString() =>
            $"Макс. грузоподъемность {maxCargo} кг; загрузка {cargo} кг";
    }
}
