using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarRentalLibrary.Controllers;         // контроллеры

using static CarRentalConsole.Application.App.Utils;       // для использования утилит


namespace CarRentalConsole.Application
{
    public partial class App
    {
        // контроллер обработки по заданию
        private QueryController _controller;

        public QueryController Controller
        {
            get => _controller;
            set => _controller = value;
        }


        #region Конструкторы

        // конструктор по умолчанию
        public App() : this(new QueryController()) { }


        // конструктор инициализрующий
        public App(QueryController queryController)
        {
            // установка значений
            _controller = queryController;
        }

        #endregion
    }
}
