using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumerViaMutex
{
    // Производитель - источник данных 
    class Producer
    {
        const int LimitProducer = 5;  // лимит производства
        private Store _store;         // ссылка на склад для помещения товара 
        private int _product = 0;     // счетчик произведенных товаров

        public Producer(Store store) {
            this._store = store;
        }

        // метод - поток для имитации работы производителя
        public void Run() {
            while (_product < LimitProducer) {
                Thread.Sleep(100);   // имитация изготовления товара
                _product++;
                Console.WriteLine($"\nПроизводитель изготовил {_product} ед. товара. Осталось произвести {LimitProducer - _product}\n");
                
                _store.Put();         // передать другому потоку - положить на склад
            } // while

            Console.WriteLine("\nПроизводитель выполнил задание на производство товара\n");
        } // Run
    } // class Producer
}
