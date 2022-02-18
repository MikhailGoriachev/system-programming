using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using HomeWokrWPF.Models;           // модели
using TaskLibrary.Controllers;      // контроллеры
using TaskLibrary.Models;           // контроллеры
using Microsoft.Win32;

namespace HomeWokrWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // контроллер обработки по заданию
        private Task1Controller _controller;

        public Task1Controller Controller
        {
            get => _controller;
            set => _controller = value;
        }


        #region Конструкторы

        // конструктор по умолчанию
        public MainWindow() : this(new Task1Controller()) { }


        // конструктор инициализирующий
        public MainWindow(Task1Controller controller)
        {
            InitializeComponent();

            // установка значений
            _controller = controller;

            DgdNumbers.ItemsSource = _controller.LoadNumbers().Select(n => new { Value = $"{n:n2}" });
            DgdNumbers.ItemsSource = _controller.LoadNumbers().Select(n => new { Value = $"{n:n2}" });
        }

        #endregion

        #region Методы

        #region Обработчики событий

        // загрузка формы
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // обновление привязки
            new Task(() => UpdateBinding(DgdNumbers, _controller.LoadNumbers().Select(n => new { Value = $"{n:n2}" }))).Start();
            new Task(() => UpdateBinding(DgdNotebooks, _controller.Notebooks)).Start();
            new Task(() => Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)(() => TblTextFile.Text = _controller.LoadText()))).Start();
            new Task(() => UpdateBinding(DgdDictionary, _controller.GetFrequencyDictionary())).Start();
        }


        #endregion

        #region Команды

        // выход из приложения
        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e) => Application.Current.Shutdown();


        // демонстрация многопоточности
        private void StartLoad_Executed(object sender, ExecutedRoutedEventArgs e) =>
            new Task(() => {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(300);
                    InitNumbers_Executed(sender, e);
                    ShuffleNotebooks_Executed(sender, e);
                }
            }).Start();

        #region 1. Числа

        // сформировать список
        private void InitNumbers_Executed(object sender, ExecutedRoutedEventArgs e) =>
            // создание и запуск потока
            new Task(() =>
            {
                // формирование коллекции
                _controller.FillNumbersFile(17);

                // обновление привязки
                UpdateBinding(DgdNumbers, _controller.LoadNumbers().Select(n => new { Value = $"{n:n2}" }));

            }).Start();


        // перемешать числа
        private void ShuffleNumbers_Executed(object sender, ExecutedRoutedEventArgs e) =>
            // создание и запуск потока
            new Task(() =>
            {
                // перемешнивание данных в файле
                _controller.ShuffleNumbersFile();

                // обновление привязки
                UpdateBinding(DgdNumbers, _controller.LoadNumbers().Select(n => new { Value = $"{n:n2}" }));

            }).Start();


        // сортировать числа по убыванию
        private void SortDescNumbers_Executed(object sender, ExecutedRoutedEventArgs e) =>
            // создание и запуск потока
            new Thread(() =>
            {
                // сортировка данных в файле
                _controller.SortNumbersDesc();

                // обновление привязки
                UpdateBinding(DgdNumbers, _controller.LoadNumbers().Select(n => new { Value = $"{n:n2}" }));

            }).Start();


        #endregion

        #region 2. Ремонт ноутбуков

        // cформировать список
        private void InitNotebooks_Executed(object sender, ExecutedRoutedEventArgs e) =>
            new Task(() =>
            {
                // формирование списка
                _controller.FillNotebooks();

                // обноваление привязки
                UpdateBinding(DgdNotebooks, _controller.Notebooks);

            }).Start();


        // перемешать числа
        private void ShuffleNotebooks_Executed(object sender, ExecutedRoutedEventArgs e) =>
            new Task(() =>
            {
                // перемешивание списка
                _controller.ShuffleNotebooks();

                // обноваление привязки
                UpdateBinding(DgdNotebooks, _controller.Notebooks);

            }).Start();


        // сохранить в файл...
        private void SaveAsNotebooks_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                FileName = "notebooks.json",
                DefaultExt = "json",
                Filter = "Файлы JSON (*.json)|*.json|Все файлы (*.*)|*.*",
            };

            // выбор файла
            if (dialog.ShowDialog() != true)
                return;

            // установка названия файла
            _controller.SaveFileNotebooks = dialog.FileName;

            // сохранение в файл данных
            _controller.SaveNotebooks();
        }


        // загрузить из файла...
        private void LoadNotebooks_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                FileName = "notebooks.json",
                DefaultExt = "json",
                Filter = "Файлы JSON (*.json)|*.json|Все файлы (*.*)|*.*",
            };

            // выбор файла
            if (dialog.ShowDialog() != true)
                return;

            // установка названия файла
            _controller.SaveFileNotebooks = dialog.FileName;

            // загрузка данных из файла
            _controller.LoadNotebooks();

            // обновление данных в окне
            new Task(() => UpdateBinding(DgdNotebooks, _controller.Notebooks)).Start();
        }

        #endregion

        #region 3. Словарь

        // открыть файл...
        private void OpenFileDictionary_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                FileName = "text.txt",
                DefaultExt = "txt",
                Filter = "Текстовые файлы TXT (*.txt)|*.txt|Все файлы (*.*)|*.*",
            };

            // выбор файла
            if (dialog.ShowDialog() != true)
                return;

            // установка названия файла
            _controller.TextFileName = dialog.FileName;

            // обновление данных в окне
            new Task(() => Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)(() => TblTextFile.Text = _controller.LoadText()))).Start();
            new Task(() => UpdateBinding(DgdDictionary, _controller.GetFrequencyDictionary())).Start();

        }


        // обновить данные
        private void UpdateDataDictionary_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // обновление данных
            new Task(() => Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)(() => TblTextFile.Text = _controller.LoadText()))).Start();
            new Task(() => UpdateBinding(DgdDictionary, _controller.GetFrequencyDictionary())).Start();
        }


        #endregion

        #region Общие методы

        // обновление привязки к DataGrid
        public void UpdateBinding(DataGrid grid, IEnumerable collection)
        {
            // безопасная работа
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)(() =>
            {
                grid.ItemsSource = null;
                grid.ItemsSource = collection;
            }));
        }

        #endregion

        #endregion

        #endregion

    }
}
