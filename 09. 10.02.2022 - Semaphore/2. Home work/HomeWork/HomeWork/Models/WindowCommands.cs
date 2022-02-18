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

        // команда - загрузка всех потоков
        public static RoutedUICommand StartThreads { get; set; }

        #region Конструкторы

        // статический конструктор
        static WindowCommands()
        {
            // установка значений

            Exit = new RoutedUICommand("Выход", "Exit", typeof(WindowCommands), new InputGestureCollection { new KeyGesture(Key.F4, ModifierKeys.Alt, "Alt+F4") });

            // команды - запуск потоков
            StartThreads = new RoutedUICommand("Запуск обработки",      "StartThreads", typeof(WindowCommands), new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Control, "Ctrl+A") });

        }
        
        #endregion
    }
}
