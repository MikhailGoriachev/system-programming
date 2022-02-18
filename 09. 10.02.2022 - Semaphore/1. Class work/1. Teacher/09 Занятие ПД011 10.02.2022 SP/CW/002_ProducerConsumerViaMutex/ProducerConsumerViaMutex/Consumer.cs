using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumerViaMutex
{
    class Consumer
    {
        const int LimitConsumer = 5;  // лимит потребления
        private Store _store;         // ссылка на склад для помещения товара 
        private int _product = 0;     // счетчик потребленных товаров

        public Consumer(Store store) {
            this._store = store;
        }

        // метод - поток для имитации работы производителя
        public void Run() {
            while (_product < LimitConsumer) {
                _store.Get();                          // получить из другого потока
                Thread.Sleep(100);   // имитация использования
                _product++;
                Console.WriteLine($"\nПотребитель купил {_product} ед. товара. Осталось купить {LimitConsumer - _product}\n");
            } // while

            Console.WriteLine("Потребитель завершил закупку товара\n");
        } // Run
    } // class Consumer
}
