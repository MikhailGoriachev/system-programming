using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.Models;          // модели
using HomeWork.Utilities;       // утилиты

/*
 * Задача 1. Разработайте приложение WPF по следующему заданию – реализация паттерна Производитель – Потребитель:
 * a.	Производитель генерирует n вещественных случайных чисел (от 10 до 50) с диапазоном значений от -10 до 20. 
 * b.	Потребитель вычисляет z1 и z2 по выражению: z1 = ((a + 2 * sqrt(2a)) - (a / sqrt(2 * a) + 2) + (2 / a - sqrt(2a))) * (sqrt(a) - sqrt(2) / a + 2)
 *                                                  z2 = 1 / (sqrt(a) + sqrt(2))
 *  
 * полученное значение и вычисленные результаты (или сообщение «ошибка вычислений») выводить в элемент управления окна.
 * Реализуйте три пары «Потребитель» - «Производитель», запускайте их командами интерфейса пользователя по одному или все три одновременно.
*/

namespace HomeWork.Controllers
{
    // Класс Контроллер обработки по заданию
    public class TaskController
    {
        // лямбда для вывода сгенерированного числа
        public Action<string> ShowNumber { get; set; }


        // лямбда для вывода информации о производителе
        public Action<Producer> ShowProducerInfo { get; set; }


        // лямбда для вывода результата обработки числа
        public Action<string, string> ShowResult { get; set; }


        // лямбда для вывода информации о потребителе
        public Action<Consumer> ShowConsumerInfo { get; set; }


        // лямбда для вывода данных потребителя
        public Action<string> ShowConsumerData { get; set; }


        // лямбда для вывода полученных данных
        public Action<string> ShowData { get; set; }


        #region Конструкторы

        // конструктор инициализирующий
        public TaskController(Action<string> showNumber, Action<Producer> showProducerInfo, Action<string, string> showResult,
            Action<Consumer> showConsumerInfo, Action<string> showConsumerData, Action<string> showData)
        {
            // установка значений
            ShowNumber          = showNumber;
            ShowProducerInfo    = showProducerInfo;
            ShowResult          = showResult;
            ShowConsumerInfo    = showConsumerInfo;
            ShowData            = showData;
            ShowConsumerData    = showConsumerData;
        }

        #endregion

        #region Методы

        // старт обработки по заданию
        public void Run()
        {
            // хранилище данных
            Store store = new Store(ShowData);

            // количество чисел для обработки
            int n = Utils.GetRand(10, 51);

            // начало обработки
            new Thread(new Consumer(store, n, ShowResult, ShowConsumerInfo, ShowConsumerData).Run).Start();
            new Thread(new Producer(store, n, ShowNumber, ShowProducerInfo).Run).Start();
        }

        #endregion
    }
}
