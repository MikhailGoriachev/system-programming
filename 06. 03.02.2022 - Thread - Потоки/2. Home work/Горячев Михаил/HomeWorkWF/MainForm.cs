using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Задача 1. Разработайте библиотеку классов для выполнения обработок:
 * a)	создание файла случайных вещественных чисел (не более 20 чисел), 
 *      создается при первом запуске, при последующих запусках – перемешивание 
 *      данных в файле. Сортировка файла по убыванию и сохранение файла
 * b)	создание коллекции заявок на ремонт ноутбуков (наименование устройства,
 *      модель, тип процессора, объем оперативной памяти, емкость накопителя, 
 *      диагональ экрана, описание неисправности, фамилия и инициалы владельца),
 *      сериализация этой коллекции при первом запуске; десериализация, 
 *      перемешивание и сериализация при последующих запусках. Формат файла 
 *      данных – JSON
 * c)	обработка текстового файла – подсчет (без учета регистра) частоты слов,
 *      результаты выводите в словарь (пары «слово – количество»)
 *      
 * Разработайте консольное приложение и приложение Windows Forms, выполняющее
 * эти обработки. В приложении Windows Forms словарь выводите в DataGridView, 
 * файлы для обработки задавайте стандартным диалогом. В консольном приложении 
 * имена файлов должны быть заданы литеральными константами (хардкод).
*/

using TaskLibrary.Controllers;      // контроллеры
using TaskLibrary.Models;           // модели

namespace HomeWorkWF
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

            // установка вкладки
            TbcMain_SelectedIndexChanged(null, null);
        }


        #endregion

        #region Методы

        #region Обработчики событий

        // выход из приложения
        private void Exit_Command(object sender, EventArgs e) => Application.Exit();


        // выбор вкладки
        private void TbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TbcMain.SelectedIndex)
            {
                // 1. Числа
                case 0:
                    new Thread(FillListViewNumbers).Start();
                    break;

                // 2. Ремонт ноутбуков
                case 1:
                    new Thread(() => UpdateBinding(DgvNotebooks, _controller.Notebooks)).Start();
                    break;

                // 3. Словарь
                case 2:
                    new Thread(UpdateDataDictionaryTab).Start();
                    break;

                default:
                    break;
            }
        }


        // перемешать коллекцию чисел
        private void ShuffleNumbers_Command(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                // перемешивание коллекции
                _controller.ShuffleNumbersFile();

                // вывод чисел
                FillListViewNumbers();            
            }).Start();

            // переход на вкладку
            TbcMain.SelectedTab = TbpPoint1;
        }


        // сортировать коллекцию чисел
        private void SortNumbers_Command(object sender, EventArgs e)
        {
            new Thread(() => { 
                // сортировка коллекции
                _controller.SortNumbersDesc();

                // вывод чисел
                FillListViewNumbers();
            }).Start();

            // переход на вкладку
            TbcMain.SelectedTab = TbpPoint1;
        }


        // загрузка из файла данных о ноутбуках, с выбором файла
        private void LoadNotebooks_Command(object sender, EventArgs e)
        {
            // выбор файла
            if (OfdNotebooks.ShowDialog() != DialogResult.OK)
                return;

            // установка файла
            _controller.SaveFileNotebooks = OfdNotebooks.FileName;

            new Thread(() =>
            {
                // загрузка данных
                _controller.LoadNotebooks();

                // обновление данных
                UpdateBinding(DgvNotebooks, _controller.Notebooks);
            }).Start();

            // переход на вкладку
            TbcMain.SelectedTab = TbpPoint2;
        }


        // сохранение в файл данных о ноутбуках, с выбором файла
        private void SaveAsNotebooks_Command(object sender, EventArgs e)
        {
            // выбор файла
            if (SfdMain.ShowDialog() != DialogResult.OK)
                return;

            // установка файла
            _controller.SaveFileNotebooks = SfdMain.FileName;

            // сохранение данных
            new Thread(_controller.SaveNotebooks).Start();

            // переход на вкладку
            TbcMain.SelectedTab = TbpPoint2;
        }


        // сформировать список ноутбуков
        private void InitNotebooks_Command(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                // генерация ноутбуков
                _controller.Notebooks = new List<NotebookModel>().GetNotebooks();

                // обновление данных
                UpdateBinding(DgvNotebooks, _controller.Notebooks);
            }).Start();

            // переход на вкладку
            TbcMain.SelectedTab = TbpPoint2;
        }


        // перемешать список ноутбуков
        private void ShuffleNotebooks_Command(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                // перемешивание списка
                _controller.ShuffleNotebooksFile();

                // обновление данных
                UpdateBinding(DgvNotebooks, _controller.Notebooks);
            }).Start();

            // переход на вкладку
            TbcMain.SelectedTab = TbpPoint2;
        }


        // обновление данных на вкладке "3. Словарь"
        private void UpdateTextData_Command(object sender, EventArgs e)
        {
            new Thread(UpdateDataDictionaryTab).Start();

            // переход на вкладку
            TbcMain.SelectedTab = TbpPoint3;
        }


        // загрузка файла с текстом
        private void OpenText_Command(object sender, EventArgs e)
        {
            // выбор файла
            if (OfdTextFile.ShowDialog() != DialogResult.OK)
                return;

            // установка названия файла
            _controller.TextFileName = OfdTextFile.FileName;

            // загрузка текста в TextBox
            TbxText.Text = _controller.LoadText();

            // получение и вывод словаря
            UpdateDataDictionaryTab();

            // переход на вкладку
            TbcMain.SelectedTab = TbpPoint3;
        }

        #endregion

        #endregion


        // обновление привязка DataGridView
        public void UpdateBinding(DataGridView grid, IEnumerable colletion)
        {
            // лямбда
            Action action = () =>
            {
                grid.DataSource = null;
                grid.DataSource = colletion;
            };

            // безопасное исполнение
            if (grid.InvokeRequired)
                BeginInvoke(action);
            else
                action.Invoke();
        }


        // сформировать список чисел
        private void NumbersInit_Command(object sender, EventArgs e)
        {
            // формирование чисел и заполнение файла
            _controller.FillNumbersFile(20);

            // обновление данных
            LviNumbers.Items.Clear();
            LviNumbers.Items.AddRange(_controller.LoadNumbers().Select(n => new ListViewItem(new string[] { $"{n:n4}" })).ToArray());

            // переход на вкладку
            TbcMain.SelectedTab = TbpPoint1;
        }


        // безопасное заполнение ListView
        public void FillListViewNumbers()
        {
            // лямбда заполнения ListView
            Action action = (Action)(() =>
            {
                LviNumbers.Items.Clear();
                LviNumbers.Items.AddRange(_controller.LoadNumbers().Select(n =>
                                new ListViewItem(new string[] { $"{n:n4}" })).ToArray());
            });

            // безопасный запуск
            if (LviNumbers.InvokeRequired)
                BeginInvoke(action);
            else
                action.Invoke();

            TbcMain.SelectedTab = TbpPoint1;
        }


        // обновление данных на вкладке 3. Словарь
        public void UpdateDataDictionaryTab()
        {
            // загрузка текста в TextBox
            if (TbxText.InvokeRequired)
                BeginInvoke((Action)(() => TbxText.Text = _controller.LoadText()));
            else
                TbxText.Text = _controller.LoadText();

            // обновление привязки в BindingSource
            Action action = () =>
            {
                BnsSource.DataSource = null;
                BnsSource.DataSource = _controller.GetFrequencyDictionary().OrderByDescending(p => p.Value).ToList();
            };

            // загрузка текста в TextBox
            if (TbxText.InvokeRequired)
                BeginInvoke(action);
            else
                action.Invoke();
        }
    }
}
