using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProducerConsumer
{
    // Склад - общий ресурс
    class Store
    {
        int _counter = 0;  // счетчик товаров на складе

        // получить со склада одну единицу товара - вызывается Consumer
        public void Get() {
            // ждать появления товара на складе
            // (ждать передачи данных объектом, формирующим, производящем данные)
            while (_counter == 0) { }

            Console.WriteLine($"Get: На складе появился товар. Остаток товара {_counter}");

            // забираем товар со склада
            // Interlocked.Decrement(ref _counter);
            // Console.WriteLine($"Get: Потребитель забрал товар со склада. Остаток товара {_counter}");
            lock (this) {
                --_counter;
                Console.WriteLine($"Get: Потребитель забрал товар со склада. Остаток товара {_counter}");
            } // lock
        } // Get

        // положить на склад одну единицу товара - выполняет Producer
        public void Put() {
            // ожидаем пока потребитель заберет товар
            // (обработает данные)
            while(_counter > 0) { }

            // записываем данные в общий ресурс
            // Interlocked.Increment(ref _counter);
            // Console.WriteLine($"Put: Производитель добавил товар на склад. Остаток товара {_counter}");
            lock (this) {
                ++_counter;
                Console.WriteLine($"Put: Производитель добавил товар на склад. Остаток товара {_counter}");
            } // lock
        } // Put
    } // class Store
}
