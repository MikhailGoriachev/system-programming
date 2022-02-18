using CarRentalConsole.Application;    // подключение главного класса приложения 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // установка заголовка окна 
            Console.Title = "Домашнее задание на 02.02.2022";

            // объект App
            App app = new App();

            // запуск меню приложения 
            app.Run();

            // возвращение исходного цвета 
            Console.ResetColor();
        }
    }
}
