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
using System.Windows.Shapes;

namespace HomeWork.Views
{
    /// <summary>
    /// Interaction logic for ProgramInfoWindow.xaml
    /// </summary>
    public partial class ProgramInfoWindow : Window
    {
        public ProgramInfoWindow()
        {
            InitializeComponent();
        }


        // загрузка формы
        private void Window_Loaded(object sender, RoutedEventArgs e) =>
            // заполнение текст-блока информацией о программе
            BtnExit.Focus();


        // закрытие окна
        private void Exit_Click(object sender, RoutedEventArgs e) => Close();
    }
}
