using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeWork.Models
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

        // команда - загрузка всех потоков
        public static RoutedUICommand AllPoint { get; set; }


        #region Конструкторы

        // статический конструктор
        static WindowCommands()
        {
            // установка значений

            Exit = new RoutedUICommand("Выход", "Exit", typeof(WindowCommands), new InputGestureCollection { new KeyGesture(Key.F4, ModifierKeys.Alt, "Alt+F4") });

            // команды - запуск потоков
            Point1   = new RoutedUICommand("Запуск потока 1",       "Point1",       typeof(WindowCommands), new InputGestureCollection { new KeyGesture(Key.Q, ModifierKeys.Control, "Ctrl+Q") });
            Point2   = new RoutedUICommand("Запуск потока 2",       "Point2",       typeof(WindowCommands), new InputGestureCollection { new KeyGesture(Key.W, ModifierKeys.Control, "Ctrl+W") });
            Point3   = new RoutedUICommand("Запуск потока 3",       "Point3",       typeof(WindowCommands), new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Control, "Ctrl+E") });
            AllPoint = new RoutedUICommand("Запуск всех потоков",   "AllPoint",     typeof(WindowCommands), new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Control, "Ctrl+A") });

        }
        
        #endregion
    }
}
