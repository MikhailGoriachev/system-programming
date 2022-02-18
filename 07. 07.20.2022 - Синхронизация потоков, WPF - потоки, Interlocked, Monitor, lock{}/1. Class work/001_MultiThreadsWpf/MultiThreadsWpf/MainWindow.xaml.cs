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

namespace MultiThreadsWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
        }
        
        // методы исполняются в потоке интерфейса пользователя thread UI (user interface)
        private void ThreadUnsafe_Click(object sender, RoutedEventArgs e) {
            TxbInfo1.Text += $"Старт потока в {DateTime.Now:T}\n";

            // создание потока в стиле "быстро, но грязно" - при помощи лямбда-выражения
            Thread thread = new Thread(() => {
                // получить ид потока
                int id = Thread.CurrentThread.ManagedThreadId;

                TxbInfo1.Text += $"Старт потока подтвержден, потоком получен Id = {id}\n";
                Thread.Sleep(1_000); // задержка времени - имитация обработки
                TxbInfo1.Text += $"Поток с id = {id}, финишровал в {DateTime.Now:T}\n\n";
            });
            thread.Start();
        } // ThreadUnsafe_Click

        private void ThreadSafe_Click(object sender, RoutedEventArgs e) {
            TxbInfo2.Text += $"Старт потока в {DateTime.Now:T}\n";

            // создание потока в стиле "быстро, но грязно" - при помощи лямбда-выражения
            Thread thread = new Thread(() => {
                // получить ид потока
                int id = Thread.CurrentThread.ManagedThreadId;

                // Dispatcher - свойство, присущее почти всем контролам,
                // конкретно - это свойство окна
                // Dispatcher.BeginInvoke(
                //     DispatcherPriority.Normal,
                //     (ThreadStart) (() => TxbInfo2.Text += $"Старт потока подтвержден, потоком получен Id = {id}\n"));
                
                // упрощение потокобезопасного доступа к элементам UI
                AddTextToTextBox(TxbInfo2, $"Старт потока подтвержден, потоком получен Id = {id}\n");

                Thread.Sleep(10_000); // задержка времени - имитация обработки

                // Dispatcher - свойство, присущее почти всем контролам,
                // конкретно - это свойство окна
                // Dispatcher.BeginInvoke(
                //     DispatcherPriority.Normal,
                //     (ThreadStart) (() => TxbInfo2.Text += $"Поток с id = {id}, финишровал в {DateTime.Now:T}\n\n"));
                AddTextToTextBox(TxbInfo2, $"Поток с id = {id}, финишровал в {DateTime.Now:T}\n\n");
            });
            thread.Start();
        } // ThreadSafe_Click

        // Улучшение - потокобезопасный вывод в текст-бокс вынесен в отдельный метод
        private void AddTextToTextBox(TextBox textBox, string text) {
            Dispatcher.BeginInvoke(
                DispatcherPriority.Normal,
                (ThreadStart)(() => textBox.Text += text));
        } // AddTextToTextBox
    }

}
