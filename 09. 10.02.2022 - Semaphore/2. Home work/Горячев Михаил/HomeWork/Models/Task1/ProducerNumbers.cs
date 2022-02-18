using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using HomeWork.Utilities;       // утилиты

/*
 * Задача 1. Разработайте приложение WPF по следующему заданию – реализация
 * паттерна Производитель – Потребитель, для синхронизации использовать 
 * мьютексы:
 * 
 * a.	Есть текстовый файл, содержащий вещественные числа, записанные по 
 *      одному в строке. В файле может быть от 12 до 18 чисел.
 * 
 * b.	Один поток записывает в файл данные и ожидает, пока второй поток 
 *      их прочитает и обработает. Поток извещает другой поток о завершении
 *      записи каждого числа. Поток завершает работу, когда количество чисел 
 *      в файле станет больше 64
 *      
 * c.	Второй поток ожидает, пока данные будут записаны в файл, читает файл
 *      и выводит числа в две строки – в первую строку в исходном порядке 
 *      следования, во вторую строку нечетные (нечетная целая часть) в конце
 *      строки. Поток извещает другой поток о завершении чтения. Поток 
 *      завершает работу, когда количество прочитанных и обработанных чисел 
 *      станет больше 64.
*/

namespace HomeWork.Models.Task1
{
    // Класс Запись чисел в текстовый файл по заданию (Производитель)
    public class ProducerNumbers
    {
        // хранилище данных
        public StoreNumbers Store { get; set; }


        // лямбда для вывода записанного числа
        public Action<double> ShowNumber { get; set; }


        #region Конструкторы

        // конструктор инициализирующий
        public ProducerNumbers(StoreNumbers store, Action<double> showNumber)
        {
            // установка значений
            Store = store;
            ShowNumber = showNumber;
        }

        #endregion

        #region Методы

        // запуск обработки чисел в файле
        public void Run()
        {
            // запись чисел в файл
            while (true)
            {
                // генерация числа для записи
                double number = Utils.GetRand(10d, 90d);

                // успешность записи числа в файл
                if (!Store.PutNumber(number))
                    return;

                // имитация обработки
                Thread.Sleep(Utils.GetRand(200, 500));

                // вывод записанного числа
                ShowNumber.Invoke(number);
            }
        }

        #endregion
    }
}
