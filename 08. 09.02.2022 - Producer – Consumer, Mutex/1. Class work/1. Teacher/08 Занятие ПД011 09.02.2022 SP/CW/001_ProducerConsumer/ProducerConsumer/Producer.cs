using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    // Производитель - источник данных 
    class Producer
    {
        const int LimitProducer = 5;    // лимит производства
        private Store _store;           // ссылка на склад для помещения товара 
        private int _product = 0;       // счетчик произведенных товаров

        // !!! Внедрение зависимости !!! Получаем ссылку на общий ресурс в конструкторе
        public Producer(Store store) {
            _store = store;
        } // Producer

        // метод - поток для имитации работы производителя
        public void Run() {
            Console.WriteLine($"Запуск производителя выполнен, Надо произвести {LimitProducer} ед.\n");

            // рабочий цикл производсьва, поставки данных
            while (_product < LimitProducer) {
                _product++;
                Thread.Sleep(100);   // имитация изготовления товара
                Console.WriteLine($"\nПроизводитель изготовил {_product} ед. товара. Осталось произвести {LimitProducer - _product}");

                _store.Put();         // передать другому потоку - положить на склад
            } // while

            Console.WriteLine("\nПроизводитель выполнил задание на производство товара\n");
        } // Run
    } // class Producer
}
