using SharedResourceProblem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharedResourceProblem
{
    class Program
    {
        // Демонстрация проблемы доступа к общему ресурсу
        // (консоль) из нескольких потоков
        static void Main(string[] args) {
            Thread thread1, thread2;
            Console.SetWindowSize(120, 38);

            // этот выводит только четные числа, должен выводить их зеленым цветом
            thread1 = new Thread(() => {
                while (true) {
                    // получить случайное число
                    // если четное - выводим зеленым цветом, иначе не выводим
                    ConsoleColor oldColor = Console.ForegroundColor;
                    int t = Utils.GetRandom(100, 999);
                    if ((t & 1) == 0) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{t, 7} ");
                        Console.ForegroundColor = oldColor;
                    } // if

                    // Thread.Sleep(30);
                } // while
            });

            // выводит тоько нечетные числа, должен выводить их желтым цветом
            thread2 = new Thread(() => {
                while (true) {
                    // получить случайное число
                    // если не четное - выводим желтым цветом, иначе не выводим
                    ConsoleColor oldColor = Console.ForegroundColor;
                    int t = Utils.GetRandom(10, 99);
                    if ((t & 1) != 0) {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{t, 7} ");
                        Console.ForegroundColor = oldColor;
                    } // if

                    // Thread.Sleep(30);
                }
            });

            thread1.Start();
            thread2.Start();

            while (true) {
                // в главной функции нет никакой обработки - просто ожидаем выхода

                // читаем клавишу, не выводим "эхо" при нажатии на клавишу
                ConsoleKeyInfo key = Console.ReadKey(false);
                if (key.Key == ConsoleKey.F10) break;
            } // while

            thread1.Abort();
            thread2.Abort();
        } // Main
    }
}
