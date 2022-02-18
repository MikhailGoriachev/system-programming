using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SynchronisationSystemOjects
{
    // Модель философа
    class Philosopher
    {
        private const int NDiner = 3;   // количество блюд в обеде философа
        private Semaphore _semaphore;   // ссылка на семафор - обеденный стол с посадочными местами
        private string    _name;        // имя философа
        private int       _counter = 0; // счетчик блюд

        public Philosopher():this(null, "") { }
        public Philosopher(Semaphore semaphore, string name) {
            _semaphore = semaphore;
            _name = name;
        } // Philosopher


        // поток, реализующий поведение философа за обедом в нашей задаче
        public void Behavor() {
            // поедание всех блюд обеда
            for (; _counter < NDiner; _counter++) {
                try {
                    // занимаем ресурс, декремент счетчика свободных ресурсов 
                    // если свободных ресурсов нет - ожидание освобождения ресурса
                    _semaphore.WaitOne();
                    Console.WriteLine($"{_name,-12} садится за стол, будет есть   блюдо {_counter + 1}");
                    Thread.Sleep(Utils.GetRandom(200, 500)); // философ кушает

                    Console.WriteLine($"{_name,-12} съел блюдо {_counter + 1},    идет  гулять по саду");
                } finally { // гарантированнное освобождение ресурса

                    _semaphore.Release(); // освобождаем ресурс, инкремент счетчика свободных ресурсов
                } // try-finally

                Thread.Sleep(Utils.GetRandom(200, 600)); // философ гуляет по саду
            } // for i

        } // Behavor
    } // class Philosopher
}
