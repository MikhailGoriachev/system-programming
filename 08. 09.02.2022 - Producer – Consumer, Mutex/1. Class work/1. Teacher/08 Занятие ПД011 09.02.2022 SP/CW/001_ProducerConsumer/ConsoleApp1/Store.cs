using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Store
    {
        // !!! общий ресурс !!!
        private int _counter = 0; // счетчик товаров на складе
        private int _value;


        // чтение данных - получить товар со склада
        public int Get() {
            // ожидаем появления товара на складе / появления данных
            while (_counter == 0) {}

            Console.WriteLine($"На складе появился товар, всего на складе {_counter} ед. товара");

            // имитация выдачи товара / чтения данных
            lock (this) {
                --_counter;
                Console.WriteLine($"Get: потребитель забрал товар со склада, всего на складе {_counter} ед. товара");
            }

            return _value;
        } // Get

        // запись данных - положить товар на склад
        public void Put(int value) {
            // ожидание момента получения товара потребителем / ожидание завершения чтения данных потребителем
            while(_counter > 0) {}

            lock (this) {
                ++_counter;
                _value = value;
                Console.WriteLine($"Put: производитель добавил товар на склад, всего на складе {_counter} ед. товара");
            }
        } // Put
    }
}
