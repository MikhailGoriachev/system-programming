using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BankDepartmentClassLibrary.Models;        // модели
using BankDepartmentClassLibrary.Controllers;   // контроллеры
using BankDepartmentClassLibrary.Utilities;     // утилиты

using BankDepartmentWF.Views;                   // формы

namespace BankDepartmentWF
{
    public partial class MainForm : Form
    {
        // контроллер обработки по заданию
        private TaskController _controller;

        public TaskController Controller
        {
            get => _controller;
            set => _controller = value;
        }


        #region Конструкторы

        // конструктор по умолчанию
        public MainForm() : this(new TaskController()) { }


        // конструктор инициализирующий
        public MainForm(TaskController taskController)
        {
            InitializeComponent();

            // установка значений
            _controller = taskController;

            // установка ссылки на вкладку запроса в тег элементов управления вызова запроса
            MniQuery1.Tag = TbpQuery1;
            MniQuery2.Tag = TbpQuery2;
            MniQuery3.Tag = TbpQuery3;
        }

        #endregion


        #region Методы

        #region Обработчики событий

        // загрузка формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            // заполнение DataGridView
            UpdateBinding(_controller.BankDepartment.Orders, DgvMain);

            // установка названия отделения банка
            TbxName.Text = _controller.BankDepartment.Name;
        }


        // переход на вкладку
        private void TbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {

            // выключение редактирующих элементов управления
            MniControl.Enabled = TsiAdd.Enabled = TsiEdit.Enabled = TsiRemove.Enabled =
                TsiInit.Enabled = TsiAddRange.Enabled = TsiClear.Enabled = false;

            switch (TbcMain.SelectedIndex)
            {
                // главная 
                case 0:

                    // включение редактирующих элементов управления
                    MniControl.Enabled = TsiAdd.Enabled = TsiEdit.Enabled = TsiRemove.Enabled =
                        TsiInit.Enabled = TsiAddRange.Enabled = TsiClear.Enabled = true;

                    // обновление данных
                    UpdateBinding(_controller.BankDepartment.Orders, DgvMain);

                    break;

                // запрос 1
                case 1:

                    // если коллекция пуста
                    if (_controller.Count == 0)
                        return;

                    // номер счёта 
                    string num1 = _controller.BankDepartment.Orders.ToArray()[LibraryUtils.GetRand(0, _controller.Count)].SenderAccount;

                    // текст информации о запросе
                    string text1 = TbxQuery1.Text;

                    // вывод условий запроса
                    TbxQuery1.Text = text1.Remove(text1.LastIndexOf(':') + 2) + num1;

                    // обновление привязки
                    UpdateBinding(_controller.Query1(num1), DgvQuery1);
                    break;

                // запрос 2
                case 2:

                    // если коллекция пуста
                    if (_controller.Count == 0)
                        return;

                    // номер счёта 
                    string num2 = _controller.BankDepartment.Orders.ToArray()[LibraryUtils.GetRand(0, _controller.BankDepartment.Orders.Count())].ReceiverAccount;

                    // текст информации о запросе
                    string text2 = TbxQuery2.Text;

                    // вывод условий запроса
                    TbxQuery2.Text = text2.Remove(text2.LastIndexOf(':') + 2) + num2;

                    // обновление привязки
                    UpdateBinding(_controller.Query2(num2), DgvQuery2);
                    break;

                // запрос 3
                case 3:

                    // диапазон значений 
                    int lo = LibraryUtils.GetRand(10, 20) * 1_000, hi = lo + 40_000;

                    // текст информации о запросе
                    string text3 = TbxQuery3.Text;

                    // вывод условий запроса
                    TbxQuery3.Text = text3.Remove(text3.LastIndexOf(':') + 2) + $"{lo} - {hi}";

                    // обновление привязки
                    UpdateBinding(_controller.Query3(lo, hi), DgvQuery3);
                    break;

                default:
                    break;
            }
        }


        // сформировать данные
        private void Init_Command(object sender, EventArgs e)
        {
            // установка новых данных
            _controller.Init();

            // обновление информации
            MainForm_Load(sender, e);
        }


        // добавить коллекцию платежей
        private void AddRange_Command(object sender, EventArgs e)
        {
            // добавление записей
            _controller.AddRange();

            // обновление информации
            UpdateBinding(_controller.BankDepartment.Orders, DgvMain);
        }


        // добавить платеж
        private void Add_Command(object sender, EventArgs e)
        {
            // форма для добавления
            OrderForm form = new OrderForm();

            // получение результата формы
            if (form.ShowDialog() != DialogResult.OK)
                return;

            // добавление в коллекцию
            _controller.Add(form.OrderModel);

            // обновление информации
            UpdateBinding(_controller.BankDepartment.Orders, DgvMain);
        }


        // изменение платежа
        private void Edit_Command(object sender, EventArgs e)
        {
            // если платеж не выбран
            if (DgvMain.SelectedRows.Count == 0)
                return;

            // индекс платежа в списке DataGrid
            int index = DgvMain.SelectedRows[0].Index;

            // форма для редактирования
            OrderForm form = new OrderForm(_controller.BankDepartment[index]);

            // получение результата формы
            if (form.ShowDialog() != DialogResult.OK)
                return;

            // обновление информации
            UpdateBinding(_controller.BankDepartment.Orders, DgvMain);
        }


        // удаление платежа
        private void Remove_Command(object sender, EventArgs e)
        {
            // если платёж не выбран
            if (DgvMain.SelectedRows.Count == 0)
                return;

            // индекс выбранного платежа
            int index = DgvMain.SelectedRows[0].Index;

            // удаление
            _controller.RemoveAt(index);

            // обновление данных
            UpdateBinding(_controller.BankDepartment.Orders, DgvMain);
            
        }


        // очистить список платежей
        private void Clear_Command(object sender, EventArgs e)
        {
            // удаление
            _controller.Clear();

            // обновление данных
            UpdateBinding(_controller.BankDepartment.Orders, DgvMain);
        }


        // запуск выбранного запроса
        private void Query_Command(object sender, EventArgs e)
        {
            // переход на вкладку запроса (запрос выполняется по переходу на вкладку запроса)
            TbcMain.SelectedTab = (TabPage)((ToolStripItem)sender).Tag;
        }


        // сохранить данные с выбором файла
        private void SaveAs_Command(object sender, EventArgs e)
        {
            // открытие диалога для выбора файла
            if (SfdMain.ShowDialog() != DialogResult.OK)
                return;

            // установка файла для сохранения
            _controller.SaveFile = SfdMain.FileName;

            // сохранение в файл
            _controller.SerializableXml();

            // обновление формы
            MainForm_Load(sender, e);
        }


        // загрузить данные из выбранного файла
        private void Load_Command(object sender, EventArgs e)
        {
            // открытие диалога для выбора файла
            if (OfdMain.ShowDialog() != DialogResult.OK)
                return;

            // установка файла для сохранения
            _controller.SaveFile = SfdMain.FileName;

            // загрузка из файла
            _controller.DeserializableXml();

            // переход на главную вкладку
            TbcMain.SelectedTab = TbpMain;

            // обновление формы
            MainForm_Load(sender, e);
        }


        // выход из приложения
        private void Exit_Command(object sender, EventArgs e) => Application.Exit();


        // выбор записи
        private void DgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #endregion

        #region Общие методы

        // обновление привязки 
        public void UpdateBinding(List<Order> source, DataGridView grid)
        {
            grid.DataSource = null;
            grid.DataSource = source;

            // обновление данных о количестве платежей в статус-баре
            UpdateCountStatus();
        }


        // обновление данных о количестве платежей в статус-баре
        public void UpdateCountStatus()
        {
            // текст в label
            string text = TsiCount.Text;

            // вывод условий запроса
            TsiCount.Text = text.Remove(text.LastIndexOf(':') + 2) + $"{_controller.Count}";
        }


        #endregion

        #endregion

        private void DgvMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // если запись не выбрана
            if (e.RowIndex == -1)
                return;

            // установка выбранной записи как активной
            DgvMain.Rows[e.RowIndex].Selected = true;

        }
    }
}
