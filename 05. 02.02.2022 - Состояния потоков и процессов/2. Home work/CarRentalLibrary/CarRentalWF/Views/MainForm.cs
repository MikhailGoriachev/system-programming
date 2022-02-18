using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CarRentalLibrary.Controllers;     // контроллеры
using CarRentalWF.Utilities;            // утилиты


/*
 * Разработайте, пожалуйста, приложение Windows Forms для решения задачи на выполнение 
 * запросов к базе данных учета продаж оптового магазина из задания на 24.11.2021. 
 * Разработайте и выполните запросы LINQ to SQL с использованием расширяющих методов. 
 * Выводите результаты запросов в DataGridView в отдельных вкладках. Один запрос – одна
 * вкладка. 
 * 
 * Используйте меню, панель инструментов, окно с выводом сведений о приложении и
 * разработчике. При необходимости используйте вспомогательные классы для отображения 
 * результатов запросов к связанным таблицам.
 * 
 * База данных «Оптовый магазин. Учет продаж». Описание предметной области
 * Оптовый магазин закупает товар по Цене закупки единицы товара и продает товар по 
 * Цене продажи единицы товара. Разница между ценой продажи и ценой закупки составляет 
 * прибыль магазина от реализации единицы товара.
 * 
 * Каждый продавец получает комиссионное вознаграждение за проданный товар. Размер этого
 * вознаграждения равен: Цена продажи единицы товара * Кол-во проданных единиц товара * 
 * Процент комиссионных продавца.
 * 
 * Прибыль от продажи партии товара вычисляется как (Цена продажи единицы товара - Цена 
 * закупки единицы товара) * Кол-во проданных единиц товара.
 * 
 * База данных должна включать как минимум таблицы ТОВАРЫ, ПРОДАВЦЫ, ПРОДАЖИ, содержащие
 * следующую информацию:
 * Наименование товара
 * Единица измерения товара
 * Цена закупки единицы товара
 * Дата продажи товара
 * Цена продажи единицы товара
 * Количество проданных единиц товара
 * Фамилия продавца, оформившего продажу
 * Имя продавца, оформившего продажу
 * Отчество продавца, оформившего продажу
 * Процент комиссионных продавца, оформившего продажу
 * 
 * Разработайте скрипты:
 * 1.	создания таблиц 
 * 2.	заполнения таблиц начальным набором данных. Каждая таблица должна содержать 
 *      не менее 10 записей.
 * 3.	Запросы SQL по заданию
 * 
 * Запросы:
 * 1	Запрос с параметрами	Выбирает из таблицы ТОВАРЫ информацию о товарах, 
 *      единицей измерения которых является «шт» (штуки) и цена закупки составляет
 *      меньше 200 руб.
 * 2	Запрос с параметрами	Выбирает из таблицы ТОВАРЫ информацию о товарах, цена
 *      закупки которых больше 500 руб. за единицу товара
 * 3	Запрос с параметрами	Выбирает из таблицы ТОВАРЫ информацию о товарах с 
 *      заданным наименованием (например, «чехол защитный»), для которых цена закупки 
 *      меньше 1800 руб.
 * 4	Запрос с параметрами	Выбирает из таблицы ПРОДАВЦЫ информацию о продавцах с 
 *      заданным значением процента комиссионных. 
 * 5	Запрос с параметрами	Выбирает из таблиц ТОВАРЫ, ПРОДАВЦЫ и ПРОДАЖИ 
 *      информацию обо всех зафиксированных фактах продажи товаров (Наименование 
 *      товара, Цена закупки, Цена продажи, дата продажи), для которых Цена продажи 
 *      оказалась в некоторых заданных границах. 
 * 6	Запрос с вычисляемыми полями	Вычисляет прибыль от продажи за каждый 
 *      проданный товар. Включает поля Дата продажи, Наименование товара, Цена 
 *      закупки, Цена продажи, Количество проданных единиц, Прибыль. Сортировка по 
 *      полю Наименование товара
 * 		
 * 7	Итоговый запрос	Выполняет группировку по полю Наименование товара. Для 
 *      каждого наименования вычисляет среднюю цену закупки товара, количество закупок
 * 8	Итоговый запрос	Выполняет группировку по полю Код продавца из таблицы ПРОДАЖИ. 
 *      Для каждого продавца вычисляет среднее значение по полю Цена продажи единицы 
 *      товара, количество продаж
 *      
 * При помощи запросов LINQ to SQL также выведите все таблицы Вашей базы данных.
*/

namespace CarRentalWF.Views
{
    public partial class MainForm : Form
    {
        // контроллер обработки по заданию
        private QueryController _controller;

        public QueryController Controller
        {
            get => _controller;
            set => _controller = value;
        }


        #region Конструкторы

        // конструктор по умолчанию
        public MainForm() : this(new QueryController()) { }


        // конструктор инциализирующий
        public MainForm(QueryController controller)
        {
            InitializeComponent();

            // установка значений
            _controller = controller;
            TbcMain_SelectedIndexChanged(new object(), EventArgs.Empty);
        }


        #endregion


        #region Методы 


        #region Обработчики событий


        // выход из программы
        private void Exit_Command(object sender, EventArgs e) => Application.Exit();


        // открытие формы с информацией о программе
        private void Info_Command(object sender, EventArgs e) => new InfoForm().ShowDialog();



        #endregion


        #region Общие методы


        // переключение вкладки
        private void TbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // выключение редактирующих кнопок
            TsiAdd.Enabled = TsiEdit.Enabled = false;

            switch (TbcMain.SelectedIndex)
            {
                // Содержание таблицы Brands (Модели_автомобилей)
                case 0:
                    UpdateBinding(DgvBrands, _controller.GetBrands());
                    break;

                // Содержание таблицы Colors (Цвета)
                case 1:
                    UpdateBinding(DgvColors, _controller.GetColors());
                    break;

                // Содержание таблицы Clients (Клиенты)
                case 2:
                    UpdateBinding(DgvClients, _controller.GetClients());
                    break;

                // Содержание таблицы Cars (Машины)
                case 3:

                    // включение редактирующих кнопок
                    TsiAdd.Enabled = TsiEdit.Enabled = true;

                    UpdateBinding(DgvCars, _controller.GetCars());
                    break;

                // Содержание таблицы Rentals (Факты_проката)
                case 4:

                    // включение редактирующих кнопок
                    TsiAdd.Enabled = TsiEdit.Enabled = true;

                    UpdateBinding(DgvRentals, _controller.GetRentals());
                    break;

                // Запрос 1
                case 5:

                    // госномер 
                    string plate = _controller.GetPlate();

                    // текст информации о запросе
                    string text1 = TbxQuery3.Text;

                    // вывод условий запроса
                    TbxQuery1.Text = text1.Remove(text1.LastIndexOf(':') + 2) + plate;

                    UpdateBinding(DgvQuery1, _controller.Query1(plate));
                    break;

                // Запрос 2
                case 6:

                    // модель 
                    string brand = _controller.GetBrand();

                    // текст информации о запросе
                    string text2 = TbxQuery3.Text;

                    // вывод условий запроса
                    TbxQuery2.Text = text2.Remove(text2.LastIndexOf(':') + 2) + brand;

                    UpdateBinding(DgvQuery2, _controller.Query2(brand));
                    break;

                // Запрос 3
                case 7:

                    // паспорт 
                    string passport = _controller.GetPassport();

                    // текст информации о запросе
                    string text3 = TbxQuery3.Text;

                    // вывод условий запроса
                    TbxQuery3.Text = text3.Remove(text3.LastIndexOf(':') + 2) + passport;

                    // обновление привязки
                    UpdateBinding(DgvQuery3, _controller.Query3(passport));

                    break;

                // Запрос 4
                case 8:

                    UpdateBinding(DgvQuery4, _controller.Query4());
                    break;

                // Запрос 5
                case 9:

                    UpdateBinding(DgvQuery5, _controller.Query5());
                    break;

                // Запрос 6
                case 10:

                    UpdateBinding(DgvQuery6, _controller.Query6());
                    break;
                default:
                    break;
            }
        }


        // обновление привязки DataGridView
        public void UpdateBinding(DataGridView view, object dataSource)
        {
            view.DataSource = null;
            view.DataSource = dataSource;
        }


        // добавление записи в таблицу
        private void Add_Command(object sender, EventArgs e)
        {
            switch (TbcMain.SelectedIndex)
            {
                // Содержание таблицы Cars (Машины)
                case 3:
                    // форма для добавления
                    CarForm formCar = new CarForm(_controller.Data);
                    
                    // запуск формы 
                    if (formCar.ShowDialog() != DialogResult.OK)
                        return;

                    // добавление товара в коллекцию
                    _controller.Data.Cars.InsertOnSubmit(formCar.CarModel);

                    // применение изменений в базе данных
                    _controller.Data.SubmitChanges();

                    UpdateBinding(DgvCars, _controller.GetCars());
                    break;

                // Содержание таблицы Rentals (Факты_проката)
                case 4:
                    // форма для добавления
                    RentalForm formRental = new RentalForm(_controller.Data);

                    // запуск формы 
                    if (formRental.ShowDialog() != DialogResult.OK)
                        return;

                    // добавление товара в коллекцию
                    _controller.Data.Rentals.InsertOnSubmit(formRental.RentalModel);

                    // применение изменений в базе данных
                    _controller.Data.SubmitChanges();

                    UpdateBinding(DgvRentals, _controller.GetRentals());
                    break;
            }
        }


        // редактирование записи в таблице
        private void Edit_Command(object sender, EventArgs e)
        {
            switch (TbcMain.SelectedIndex)
            {
                // Содержание таблицы Cars (Машины)
                case 3:
                    // если элемент не выбран
                    if (DgvCars.SelectedRows.Count == 0)
                        return;

                    // форма для редактирования
                    CarForm formCar = new CarForm(_controller.Data, _controller.Data.Cars.ToArray()[DgvCars.SelectedRows[0].Index]);

                    // запуск формы 
                    if (formCar.ShowDialog() != DialogResult.OK)
                        return;

                    // применение изменений в базе данных
                    _controller.Data.SubmitChanges();

                    UpdateBinding(DgvCars, _controller.GetCars());
                    break;

                // Содержание таблицы Rentals (Факты_проката)
                case 4:
                    // если элемент не выбран
                    if (DgvRentals.SelectedRows.Count == 0)
                        return;

                    // форма для редактирования
                    RentalForm formRental = new RentalForm(_controller.Data, _controller.Data.Rentals.ToArray()[DgvRentals.SelectedRows[0].Index]);

                    // запуск формы 
                    if (formRental.ShowDialog() != DialogResult.OK)
                        return;

                    // применение изменений в базе данных
                    _controller.Data.SubmitChanges();

                    UpdateBinding(DgvRentals, _controller.GetRentals());
                    break;
            }
        }


        #endregion

        #endregion

    }
}
