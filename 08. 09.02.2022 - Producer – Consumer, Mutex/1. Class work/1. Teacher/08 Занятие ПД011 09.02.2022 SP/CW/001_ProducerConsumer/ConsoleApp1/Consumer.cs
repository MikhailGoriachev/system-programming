using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Consumer
    {
        private const int LimitConcumer = 5;
        private int _consumed = 0;   // счетчик потребленных товаров

        // ссылка на общий ресурс
        private Store _store;

        public Consumer(Store store) {
            _store = store;
        }

        // поток для чтения из общего ресурса - получить и использовать товар со склада
        public void Run() {
            Console.WriteLine($"Запуск потребителя, требуется потребить {LimitConcumer} ед. товара");

            while (_consumed < LimitConcumer) {
                // получение товара / чтение данных
                int value = _store.Get();
                Thread.Sleep(1_200); // имитация обработки

                ++_consumed;
                Console.WriteLine($"Потребитель получил {_consumed} ед., осталось потребить {LimitConcumer - _consumed} ед.: {value}");
            } // while

            Console.WriteLine($"Финиш потребителя, потреблено {_consumed} ед. товара");
        }  // Run
    }
}