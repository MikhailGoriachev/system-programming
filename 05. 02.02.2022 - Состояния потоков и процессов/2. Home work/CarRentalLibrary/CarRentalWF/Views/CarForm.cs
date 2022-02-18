using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CarRentalLibrary.Models;      // модели

namespace CarRentalWF.Views
{
    // Форма добавление/редактирование автомобиля
    public partial class CarForm : Form
    {
        // модель для работы
        private Car _carModel;

        public Car CarModel
        {
            get => _carModel;
            set => _carModel = value;
        }


        // модель базы данных
        public CarRentalDataContext Data { get; set; }


        #region Конструкторы

        // конструктор для запуска формы в режиме создания
        public CarForm(CarRentalDataContext data) 
        {
            InitializeComponent();

            // установка ссылки на объект модели базы данных
            Data = data;

            // создание объекта
            _carModel = new Car
            {
                Brand = data.Brands.ToArray()[0],
                Color = data.Colors.ToArray()[0],
                Plate = "А001АА",
                InshurancePay = 100_000,
                Rental = 6_000,
                YearManuf = 2018
            };

            // заполнение ComboBox
            SetComboBoxesValues();

            // установка значений из модели в поля
            SetValueFields();
        }


        // конструктор для запуска формы в режиме редактирования
        public CarForm(CarRentalDataContext data, Car car)
        {
            InitializeComponent();

            // установка ссылки на объект модели базы данных
            Data = data;

            // установка ссылки на редактируемый объект
            _carModel = car;

            // заполнение ComboBox
            SetComboBoxesValues();

            // установка значений из модели в поля
            SetValueFields();

            // установка текста заголовков
            Text = LblHeader.Text = "Редактирование автомобиля";

            // установка текта на кнопке
            BtnOk.Text = "Сохранить";
        }

        #endregion

        #region Методы

        // установка значений из модели в поля
        public void SetValueFields()
        {
            TbxPlate.Text           = _carModel.Plate;
            CmbBrand.SelectedItem   = _carModel.Brand.Brand1;
            CmbColor.SelectedItem   = _carModel.Color.Color1;
            NudPay.Value            = _carModel.InshurancePay;
            NudRental.Value         = _carModel.Rental;
            NudYear.Value           = _carModel.YearManuf;
        }

        // установка значений для комбо-боксов
        public void SetComboBoxesValues()
        {
            CmbBrand.Items.AddRange(Data.Brands.Select(g => g.Brand1).ToArray());
            CmbColor.Items.AddRange(Data.Colors.Select(u => u.Color1).ToArray());
        }

        #endregion

        // применение изменений
        private void BtnOk_Click(object sender, EventArgs e)
        {
            _carModel.Plate             = TbxPlate.Text;
            _carModel.Brand             = Data.Brands.Where(b => b.Brand1 == CmbBrand.SelectedItem as string).ToArray()[0];
            _carModel.Color             = Data.Colors.Where(c => c.Color1 == CmbColor.SelectedItem as string).ToArray()[0];
            _carModel.InshurancePay     = (int)NudPay.Value;
            _carModel.Rental            = (int)NudRental.Value;
            _carModel.YearManuf         = (int)NudYear.Value;

        }
    }
}
