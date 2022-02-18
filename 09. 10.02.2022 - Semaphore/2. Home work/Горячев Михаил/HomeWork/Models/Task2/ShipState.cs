using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Models.Task2
{
    // состояния корабля
    public enum ShipState : byte
    {
        // ожидание распреления
        Waiting,

        // погрузка контейнеров
        Loading,

        // выгрузка контейнеров
        Unloading,

        // не удалось закончить работу
        Failed,

        // работа закончена
        Completed
    }
}
