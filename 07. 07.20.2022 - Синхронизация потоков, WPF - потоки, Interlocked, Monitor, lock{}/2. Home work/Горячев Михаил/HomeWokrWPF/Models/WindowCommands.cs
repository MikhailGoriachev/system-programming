using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeWokrWPF.Models
{
    // команды окна
    public class WindowCommands
    {
        // команда - выхода из приложения
        public static RoutedUICommand Exit { get; set; }

        // команда - выполнения потока 1
        public static RoutedUICommand Point1 { get; set; }

        // команда - выполнения потока 2
        public static RoutedUICommand Point2 { get; set; }

        // команда - выполнения потока 3
        public static RoutedUICommand Point3 { get; set; }

        // команда - загрузка всех заданий
        public static RoutedUICommand StartLoad { get; set; }

        #region 1. Числа

        // команда - сформировать список
        public static RoutedUICommand InitNumbers { get; set; }

        // команда - перемешать числа
        public static RoutedUICommand ShuffleNumbers { get; set; }

        // команда - сортировать числа по убыванию
        public static RoutedUICommand SortDescNumbers { get; set; }

        #endregion

        #region 2. Ремонт ноутбуков

        // команда - cформировать список
        public static RoutedUICommand InitNotebooks { get; set; }

        // команда - перемешать числа
        public static RoutedUICommand ShuffleNotebooks { get; set; }

        // команда - сохранить в файл...
        public static RoutedUICommand SaveAsNotebooks { get; set; }

        // команда - загрузить из файла...
        public static RoutedUICommand LoadNotebooks { get; set; }

        // команда - сортировать по убыванию стоимости
        public static RoutedUICommand SortPriceDescNotebooks { get; set; }

        #endregion

        #region 3. Словарь

        // команда - открыть файл...
        public static RoutedUICommand OpenFileDictionary { get; set; }

        // команда - обновить данные
        public static RoutedUICommand UpdateDataDictionary { get; set; }

        #endregion


        #region Конструкторы

        // статический конструктор
        static WindowCommands()
        {
            // установка значений
            Exit        = new RoutedUICommand("Выход",                      "Exit",         typeof(WindowCommands), new InputGestureCollection { new KeyGesture(Key.F4, ModifierKeys.Alt,    "Alt+F4") });
            StartLoad   = new RoutedUICommand("Выполнение всех заданий",    "StartLoad",    typeof(WindowCommands), new InputGestureCollection { new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl+R") });

            // 1. Числа
            InitNumbers         = new RoutedUICommand("Сформировать список",        "InitNumbers",      typeof(WindowCommands));
            ShuffleNumbers      = new RoutedUICommand("Перемешать числа",           "ShuffleNumbers",   typeof(WindowCommands));
            SortDescNumbers     = new RoutedUICommand("Сортировать по убыванию",    "SortDescNumbers",  typeof(WindowCommands));

            // 2. Ремонт ноутбуков
            InitNotebooks               = new RoutedUICommand("Сформировать список",                "InitNotebooks",            typeof(WindowCommands));
            ShuffleNotebooks            = new RoutedUICommand("Перемешать числа",                   "ShuffleNotebooks",         typeof(WindowCommands));
            SaveAsNotebooks             = new RoutedUICommand("Сохранить в файл...",                "SaveAsNotebooks",          typeof(WindowCommands));
            LoadNotebooks               = new RoutedUICommand("Загрузить из файла...",              "LoadNotebooks",            typeof(WindowCommands));
            SortPriceDescNotebooks      = new RoutedUICommand("Сортировать по убыванию стоимости",  "SortPriceDescNotebooks",   typeof(WindowCommands));

            // 3. Словарь
            OpenFileDictionary          = new RoutedUICommand("Открыть файл...",    "OpenFileDictionary",       typeof(WindowCommands));
            UpdateDataDictionary        = new RoutedUICommand("Обновить данные",    "UpdateDataDictionary",     typeof(WindowCommands));
        }
        
        #endregion
    }
}
