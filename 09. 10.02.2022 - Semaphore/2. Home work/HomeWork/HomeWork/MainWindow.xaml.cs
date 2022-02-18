using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

using HomeWork.Views;       // окна

namespace HomeWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // запуск задания 1
        private void Task1_Click(object sender, RoutedEventArgs e) => new Task1Window().ShowDialog();


        // запуск задания 2
        private void Task2_Click(object sender, RoutedEventArgs e) => new Task2Window().ShowDialog();


        // запуск задания 2
        private void Info_Click(object sender, RoutedEventArgs e) => new ProgramInfoWindow().ShowDialog();


        // выход из приложения
        private void Exit_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

    }
}
