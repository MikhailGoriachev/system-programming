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
using HomeWork.Controllers;         // контроллеры
using HomeWork.Models;              // модели
using HomeWork.Models.Task2;        // модели задания 2

namespace HomeWork.Views
{
    /// <summary>
    /// Interaction logic for Task2Window.xaml
    /// </summary>
    public partial class Task2Window : Window
    {
        // контроллер обработки по заданию 2
        private Task2Controller _controller;

        public Task2Controller Controller
        {
            get => _controller;
            set => _controller = value;
        }


        #region Конструкторы

        // конструктор по умолчанию
        public Task2Window()
        {
            InitializeComponent();

            // установка значений
            _controller = new Task2Controller((p) => { ShowTextBox(TbxLoadingCount, $"Очередь на погрузку: {p.QueueLoading.Count}");
                                                       ShowTextBox(TbxUnloadingCount, $"Очередь на выгрузку: {p.QueueUnloading.Count}");
                                                       ShowTextBox(TbxCountContainer, $"Загруженность порта: {p.CountContainers} / {PortModel.Capacity}"); },
                (s) => {
                    ShowDataGrid(DgdLoading, _controller.Port.QueueLoading.ToList());
                    ShowDataGrid(DgdUnloading, _controller.Port.QueueUnloading.ToList());
                    ShowTextBox(TbxLoadingCount, $"Очередь на погрузку: {_controller.Port.QueueLoading.Count}");
                    ShowTextBox(TbxUnloadingCount, $"Очередь на выгрузку: {_controller.Port.QueueUnloading.Count}");
                });

            // подписка на событие изменения очереди на погрузку кораблей
            _controller.Port.QueueLoading.CollectionChanged += (sender, e) =>
            {
                ShowDataGrid(DgdLoading, _controller.Port.QueueLoading.ToList());
                ShowTextBox(TbxLoadingCount, $"Очередь на погрузку: {_controller.Port.QueueLoading.Count}");
                ShowTextBox(TbxUnloadingCount, $"Очередь на выгрузку: {_controller.Port.QueueUnloading.Count}");
            };

            // подписка на событие изменения очереди на выгрузку кораблей
            _controller.Port.QueueUnloading.CollectionChanged += (sender, e) =>
            {
                ShowDataGrid(DgdUnloading, _controller.Port.QueueUnloading.ToList());
                ShowTextBox(TbxLoadingCount, $"Очередь на погрузку: {_controller.Port.QueueLoading.Count}");
                ShowTextBox(TbxUnloadingCount, $"Очередь на выгрузку: {_controller.Port.QueueUnloading.Count}");
            };
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
        private void Window_Loaded(object sender, RoutedEventArgs e) =>
            _controller.Run();


        // безопасный вывод в DataGrid
        public void ShowDataGrid(DataGrid grid, IEnumerable items) =>
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)(() => { grid.ItemsSource = null; grid.ItemsSource = items; }));


        // безопасный вывод в TextBox
        public void ShowTextBox(TextBox textBox, string line) =>
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)(() => textBox.Text = line));


        #endregion

    }
}
