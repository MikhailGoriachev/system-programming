using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

using HomeWork.Controllers;     // контроллеры

namespace HomeWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // контроллер обработки по заданию
        private TaskController _controller1;
        private TaskController _controller2;
        private TaskController _controller3;

        #region Конструкоры

        // конструктор инициализирующий
        public MainWindow()
        {
            InitializeComponent();

            // установка значений
            _controller1 = new TaskController(s => ShowTextBox(TbxProdData1, $"Последние данные: {s}"),
                p => { ShowTextBox(TbxProdLimit1, $"Требуется произвести данных: {p.Limit}"); ShowTextBox(TbxProdCount1, $"Произведено: {p.Counter}"); },
                (z1, z2) => ShowTextBox(TbxConsResult1, $"Последний результат: z1 = {z1}, z2 = {z2}"),
                c => { ShowTextBox(TbxConsLimit1, $"Требуется обработать данных: {c.Limit}"); ShowTextBox(TbxConsCount1, $"Обработано: {c.Counter}"); },
                x => ShowTextBox(TbxConsData1, $"Последние данные: {x}"),
                d => ShowTextBox(TbxStoreData1, $"Последние данные: {d}"));

            _controller2 = new TaskController(s => ShowTextBox(TbxProdData2, $"Последние данные: {s}"),
                p => { ShowTextBox(TbxProdLimit2, $"Требуется произвести данных: {p.Limit}"); ShowTextBox(TbxProdCount2, $"Произведено: {p.Counter}"); },
                (z1, z2) => ShowTextBox(TbxConsResult2, $"Последний результат: z1 = {z1}, z2 = {z2}"),
                c => { ShowTextBox(TbxConsLimit2, $"Требуется обработать данных: {c.Limit}"); ShowTextBox(TbxConsCount2, $"Обработано: {c.Counter}"); },
                x => ShowTextBox(TbxConsData2, $"Последние данные: {x}"),
                d => ShowTextBox(TbxStoreData2, $"Последние данные: {d}"));

            _controller3 = new TaskController(s => ShowTextBox(TbxProdData3, $"Последние данные: {s}"),
                p => { ShowTextBox(TbxProdLimit3, $"Требуется произвести данных: {p.Limit}"); ShowTextBox(TbxProdCount3, $"Произведено: {p.Counter}"); },
                (z1, z2) => ShowTextBox(TbxConsResult3, $"Последний результат: z1 = {z1}, z2 = {z2}"),
                c => { ShowTextBox(TbxConsLimit3, $"Требуется обработать данных: {c.Limit}"); ShowTextBox(TbxConsCount3, $"Обработано: {c.Counter}"); },
                x => ShowTextBox(TbxConsData3, $"Последние данные: {x}"),
                d => ShowTextBox(TbxStoreData3, $"Последние данные: {d}"));

        }

        #endregion

        #region Методы

        // загрузка окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // запуск всех потоков
            ExecAllPoint_Executed(sender, null);
        }

        // выход из приложения
        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e) => Application.Current.Shutdown();

        // запуск потока 1
        private void ExecPoint1_Executed(object sender, ExecutedRoutedEventArgs e) => new Thread(_controller1.Run).Start();

        // запуск потока 2
        private void ExecPoint2_Executed(object sender, ExecutedRoutedEventArgs e) => new Thread(_controller2.Run).Start();

        // запуск потока 3
        private void ExecPoint3_Executed(object sender, ExecutedRoutedEventArgs e) => new Thread(_controller3.Run).Start();

        // запуск всех потоков
        private void ExecAllPoint_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            new Thread(_controller1.Run).Start();
            new Thread(_controller2.Run).Start();
            new Thread(_controller3.Run).Start();
        }


        // безопасный вывод в TextBox
        public void ShowTextBox(TextBox textBox, string text) =>
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)(() => textBox.Text = text));

        #endregion

    }
}
