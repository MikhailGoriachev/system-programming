using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // производоитель товара - запись данных в общий ресурс
    public class Producer
    {
        private const int LimitProducer = 5;
        private int _produced = 0;   // счетчик произведенных товаров

        // ссылка на общий ресурс
        private Store _store;

        public Producer(Store store) {
            _store = store;
        }

        // поток для записи в общий ресурс - произвести и положить тлвар на склад
        public void Run() {
            Console.WriteLine($"Запуск производителя, требуется произвести {LimitProducer} ед. товара");

            while (_produced < LimitProducer) {
                // производство товара / запись данных
                Thread.Sleep(1_200);
                ++_produced;
                int value = DateTime.Now.Second;
                Console.WriteLine($"Производитель изготовил {_produced} ед., осталось произвести {LimitProducer - _produced} ед.: {value}");

                // положить данные на склад, передать данные другому потоку
                _store.Put(value);
            } // while

            Console.WriteLine($"Финиш производителя, произведено {_produced} ед. товара");
        }  // Run
    } // class Producer
}
