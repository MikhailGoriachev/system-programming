using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

using HomeWork.Controllers;     // контроллеры
using HomeWork.Models;          // модели

namespace HomeWork.Views
{
    /// <summary>
    /// Interaction logic for Task1Window.xaml
    /// </summary>
    public partial class Task1Window : Window
    {
        // контроллер обработки по заданию 1
        private Task1Controller _controller;

        public Task1Controller Controller
        {
            get => _controller;
            set => _controller = value;
        }


        #region Конструкторы

        // конструктор по умолчанию
        public Task1Window()
        {
            InitializeComponent();

            // устновка значений
            _controller = new Task1Controller("./App_Data/numbers.txt", (l1, l2) => { ShowDataGrid(DgdNumbers, l1.Select(i => new { Value = $"{i:f3}" }).ToList()); ShowDataGrid(DgdNumbersSort, l2.Select(i => new { Value = $"{i:f3}" }).ToList());
                ShowTextBox(TbxConsumerCount, $"Количество чисел: {l1.Count}"); },
                (n) => ShowTextBox(TbxProducerValue, $"Последнее значение: {n}"),
                (s) => ShowTextBox(TbxStoreStatus, $"Наличие данных: {(s ? "Есть даные" : "Данных нет")}"));
        }

        #endregion

        #region Методы

        #region Команды

        // команда выхода из приложения
        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e) => Application.Current.Shutdown();


        // команда запуска обработки
        private void StartThreads_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // сброс данных
            _controller.Reset();

            // запуск обработки
            _controller.Run();
        }


        #endregion

        // загрузка окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _controller.Run();
        }


        // безопасный вывод в DataGrid
        public void ShowDataGrid(DataGrid grid, IEnumerable items) =>
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)(() => { grid.ItemsSource = null; grid.ItemsSource = items; }));


        // безопасный вывод в TextBox
        public void ShowTextBox(TextBox textBox, string line) => 
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)(() => textBox.Text = line));


        #endregion

    }
}
