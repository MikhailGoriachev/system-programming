using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static BankDepartmentConsole.Application.App.Utils;       // для использования утилит

using BankDepartmentClassLibrary.Controllers;       // контроллеры

/*
 * Условия заданий
*/

namespace BankDepartmentConsole.Application
{
    public partial class App
    {
        // контроллер обработки по заданию 1
        private TaskController _controller;

        public TaskController Controller
        {
            get => _controller;
            set => _controller = value;
        }

        #region Конструкторы

        // конструктор по умолчанию
        public App() : this(new TaskController()) { }


        // конструктор инициализрующий
        public App(TaskController taskController)
        {
            // установка значений
            _controller = taskController;
        }

        #endregion
    }
}
