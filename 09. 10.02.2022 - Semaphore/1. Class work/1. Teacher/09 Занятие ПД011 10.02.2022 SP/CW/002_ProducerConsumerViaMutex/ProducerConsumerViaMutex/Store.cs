using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProducerConsumerViaMutex
{
    // Склад - общий ресурс
    class Store
    {
        private int _counter = 0;  // счетчик товаров на складе
        private Mutex _mutex;   // мьютекс для синхронизации объектов

        public Store(Mutex mutex) {
            // получить мьютекс для синхронизации Потребителя и Производителя
            _mutex = mutex;
        } // Store

        // получить со склада одну единицу товара
        public void Get() {
            // ждать появления товара на складе
            // (передачи данных производителем)
            while (_counter == 0) { }

            // забираем товар со склада при помощи критической секции
            try {
                _mutex.WaitOne();

                Console.WriteLine($"Get: На складе появился товар. Остаток товара {_counter}");
                _counter--;
                Console.WriteLine($"Get: Потребитель забрал товар со склада. Остаток товара {_counter}");
            }
            finally {

                _mutex.ReleaseMutex();
            }

        } // Get

        // положить на склад одну единицу товара
        public void Put() {
            // ожидаем пока потребитель заберет товар
            // (обработает данные)
            while(_counter > 0) { }

            // записываем данные в общий ресурс
            try {
                _mutex.WaitOne();

                ++_counter;
                Console.WriteLine($"Put: Производитель добавил товар на склад. Остаток товара {_counter}");
            }
            finally {

                _mutex.ReleaseMutex();
            }
        } // Put
    } // class Store
}
