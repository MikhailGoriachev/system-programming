using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork.Models.Task1
{
    // Класс Общий ресурс для работы с текстовым файлом по заданию 1
    public class StoreNumbers
    {
        // показатель, есть ли данные
        private bool _isData = false;


        // лимит чисел в файле
        public readonly int Limit;


        // Mutex для работы
        public Mutex MutexCurrent { get; set; }


        // название текстового файла для работы
        public string TextFileName { get; set; }


        // вывод статуса данных в хранилище
        public Action<bool> ShowStatusData { get; set; }


        // флаг окончания работы
        private bool _isEndTask = false;

        #region Конструкторы

        // конструктор инициализирующий
        public StoreNumbers(Mutex mutexCurrent, string textFileName, Action<bool> showStatusData, int limit)
        {
            // установка значений
            MutexCurrent    = mutexCurrent;
            TextFileName    = textFileName;
            ShowStatusData  = showStatusData;
            Limit           = limit;
        }

        #endregion

        #region Методы

        // взять данные
        public List<double> GetNumbers()
        {
            // ожидания наличия данных
            while (!_isData && !_isEndTask) { }

            // чтение чисел в файле
            try
            {
                // захват ресурса
                MutexCurrent.WaitOne();

                // чисел из файла получение данных
                List<double> numbers = File.ReadAllLines(TextFileName).Select(s => double.Parse(s)).ToList();

                // если количества чисел в файле превыщает лимит
                if (numbers.Count > Limit)
                {
                    _isEndTask = true;
                    return null;
                }

                // установка флага наличия данных
                _isData = false;

                // вывод статуса данных в хранилище
                new Thread(() => ShowStatusData.Invoke(_isData)).Start();

                // получение чисел
                return numbers;
            }
            finally
            {
                // освобождение ресурса
                MutexCurrent.ReleaseMutex();
            }
        }


        // положить данные (возвращает были ли числа записаны, они не будут записаны, если лимит чисел в файле превышен)
        public bool PutNumber(double number)
        {
            // ожидания отсутсвия данных
            while (_isData && !_isEndTask) { }

            try
            {
                // захват ресурса
                MutexCurrent.WaitOne();

                // если количества чисел в файле превыщает лимит
                if (File.ReadAllLines(TextFileName).Length > Limit)
                {
                    _isEndTask = true;
                    return false;
                }

                // установка флага наличия данных
                _isData = true;

                // вывод статуса данных в хранилище
                new Thread(() => ShowStatusData.Invoke(_isData)).Start();

                // запись числа в конец файла
                File.AppendAllLines(TextFileName, new[] { number.ToString() });

                // установка флага наличия данных
                return true;
            }
            finally
            {
                // освобождение ресурса
                MutexCurrent.ReleaseMutex();
            }
        }

        #endregion
    }
}
