using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;       // для работы с процессами

using HomeWork.Controllers;     // контроллеры
using HomeWork.Models;          // модели

namespace HomeWork
{
    public partial class MainForm : Form
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
        public MainForm() : this(new Task1Controller()) { }


        // конструктор инициализирующий
        public MainForm(Task1Controller controller)
        {
            InitializeComponent();

            // установка значений
            _controller = controller;
        }

        #endregion

        #region Методы

        #region Обработчики событий

        // загрузка формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            // обновление информации о количестве элементов в списке в статус-баре
            UpdateStatus();
        }


        // запуск процесса
        private void StartProcess_Command(object sender, EventArgs e)
        {
            // запуск диалога для выбора файла запуска
            if (OfdMain.ShowDialog() != DialogResult.OK)
                return;

            // запуск процесса
            _controller.Add(new Process { StartInfo = new ProcessStartInfo(OfdMain.FileName) });
            _controller.ExecuteProcessAt(0);

            // вывод в ListView
            ShowListView();

            // обновление информации о количестве элементов в списке в статус-баре
            UpdateStatus();
        }


        // вывод в ListView
        public void ShowListView()
        {
            LviHistory.Items.Clear();
            _controller.Processes.ForEach(p => LviHistory.Items.Add(p.GetListViewItem()));
        }


        // выход из приложения
        private void Exit_Command(object sender, EventArgs e) => Application.Exit();


        // очистка списка
        private void Clear_Command(object sender, EventArgs e)
        {
            // очистка списка
            _controller.Clear();

            // вывод в ListView
            ShowListView();

            // обновление информации о количестве элементов в списке в статус-баре
            UpdateStatus();
        }

        #endregion

        // обновление информации о количестве элементов в списке в статус-баре
        public void UpdateStatus()
        {
            // текущее значение label
            string text = LblAmountElem.Text;

            LblAmountElem.Text = text.Remove(text.LastIndexOf(':') + 2) + _controller.Processes.Count.ToString();
        }

        #endregion


    }
}
