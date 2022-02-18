using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public abstract class Car
    {
        private int curSpeed;  // текущая скорость
        public int CurSpeed {
            get => curSpeed;
            set => curSpeed = value > maxSpeed ? maxSpeed : value; 
        }

        private int maxSpeed;  // макс. скорость
        public int MaxSpeed => maxSpeed; 

        public Car():this(0, 150) { }
        public Car(int cur, int max) {
            curSpeed = cur;
            maxSpeed = max;
        }

        public abstract void Up();    // для потомков...
        public abstract void Down();
    } // class Car
}
