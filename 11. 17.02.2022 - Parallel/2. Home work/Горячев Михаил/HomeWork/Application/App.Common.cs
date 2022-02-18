using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.Controllers;     // контроллеры

using static HomeWork.Application.App.Utils;       // для использования утилит

/*
 * 1.	При помощи класса Parallel вычислить параллельно: корни квадратного 
 *      уравнения, 42е число Фибоначчи (не рекурсивно), объем усеченного конуса.
 * 
 * 2.	С использованием Parallel.ForEach вычислите и поместите результат в
 *      ConcurrencyDictionary для 12 квадратных уравнений.  
*/

namespace HomeWork.Application
{

    public partial class App
    {

        // контроллер обработки по заданию
        private TaskController _controller;

        public TaskController Controller
        {
            get => _controller;
            set => _controller = value;
        }


        #region Конструкторы

        // конструктор по умолчанию
        public App() : this(new TaskController()) { }


        // конструктор инициализирующий
        public App(TaskController taskController)
        {
            // установка значений
            _controller = taskController;
        }

        #endregion
    }
}
