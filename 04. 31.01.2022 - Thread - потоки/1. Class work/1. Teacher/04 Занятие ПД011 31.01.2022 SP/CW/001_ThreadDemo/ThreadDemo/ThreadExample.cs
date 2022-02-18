using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadDemo
{
    class ThreadExample
    {
        // Метод потока - вариант c параметром
        // количество табуляций перед выводом
        // private int[] _arr = new int[12];

        // В классе может быть один или несколько методов для потока
        public void Method3(object obj) {
            // свойство Thread.CurrentThread - ссылка на текущий поток 
            Thread self = Thread.CurrentThread;
            Console.WriteLine($"{self.Name}: старт потока");

            try {
                int n = (int)obj;
                for (int i = 0; i < 10; i++) {
                    // _arr[i] = i;

                    // выводим n табуляций 
                    for (int j = 0; j < n; j++) Console.Write('\t');
                    Console.WriteLine($"{self.Name}/{self.ManagedThreadId}: {i,2}");
                    Thread.Sleep(300);
                } // for i
            } finally {
                Console.WriteLine($"{self.Name}: завершен");
            } // try-catch
        } // Method3
    } // class ThreadExample
}
