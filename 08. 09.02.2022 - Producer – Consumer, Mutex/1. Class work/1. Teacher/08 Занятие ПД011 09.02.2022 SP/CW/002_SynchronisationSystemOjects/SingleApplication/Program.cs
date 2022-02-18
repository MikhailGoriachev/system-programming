using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingleApplication
{
    class Program
    {
        static Mutex _mutex;

        static void Main(string[] args) {
            Console.Title = "Занятие 09.02.2021 - единственный экземпляр приложения при помощи мьютекса";

            string mutexName = "SingleApplication";   // имя мьютекса - должно быть уникальным

            // создать мьютекс
            _mutex = new Mutex(true, mutexName, out bool createdNew);

            // Если мьютекс создать не удалось - экземпляр приложения уже запущен
            // и поэтому завершаем текущий экземпляр
            if (!createdNew) {
                Console.WriteLine("SingleApplication. Приложение уже запущено! Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            } // if

            // Запущен первый экземпляр приложения
            Console.WriteLine("SingleApplication. Привет, мир!");

            // Чтобы приложение осталось запущенным просто ждем нажатия на клавишу
            Console.ReadKey(true);
        } // Main
    }
}
