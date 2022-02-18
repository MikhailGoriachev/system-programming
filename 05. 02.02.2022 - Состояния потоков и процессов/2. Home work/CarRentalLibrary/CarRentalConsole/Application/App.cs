using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static CarRentalConsole.Application.App.Utils;       // для использования утилит

/*
 *  2.	Разработайте консольное приложение, по таймеру, с интервалом 2 секунды,
 *      выполняющее запросы 1, …, 5. После выполнения запроса 5 требуется перейти к 
 *      выполнению запроса 1 и т.д., в бесконечном цикле. Параметры запросов формируйте
 *      генерацией, вводить параметры с клавиатуры не надо. Приложение использует 
 *      библиотеку классов из пункта 1
*/

namespace CarRentalConsole.Application
{

    public partial class App
    {

        #region Меню заданий 

        // меню заданий
        public void Run()
        {
            Timer timer = new Timer(TimerHandler);

            timer.Change(0, 2000);

            Console.Read();
        } // Run


        // номер запроса
        public int _numberQuery = 0;

        // обработчик таймера по заданию
        public void TimerHandler(object o)
        {
            // очистка консоли
            Console.Clear();

            switch (_numberQuery++)
            {
                case 0:
                    Point1();
                    break;
                case 1:
                    Point2();
                    break;
                case 2:
                    Point3();
                    break;
                case 3:
                    Point4();
                    break;
                case 4:
                    Point5();
                    break;
                default:
                    _numberQuery = 0;
                    goto case 0;
            }
        }


        #endregion

    }
}
