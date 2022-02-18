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
using CarRentalWF.Utilities;        // утилиты

namespace CarRentalWF.Views
{
    // Форма добавление/редактирование проката
    public partial class RentalForm : Form
    {
        // модель для работы
        private Rental _rentalModel;

        public Rental RentalModel
        {
            get => _rentalModel;
            set => _rentalModel = value;
        }


        // модель базы данных
        public CarRentalDataContext Data { get; set; }


        #region Конструкторы

        // конструктор для запуска формы в режиме создания
        public RentalForm(CarRentalDataContext data) 
        {
            InitializeComponent();

            // установка ссылки на объект модели базы данных
            Data = data;

            // создание объекта
            _rentalModel = new Rental
            {
                Car = data.Cars.ToArray()[Utils.GetRand(0, data.Cars.Count())],
                Client = data.Clients.ToArray()[Utils.GetRand(0, data.Clients.Count())],
                DateStart = new DateTime(2022,02,02),
                Duration = Utils.GetRand(0, 20)
            };

            // заполнение ComboBox
            SetComboBoxesValues();

            // установка значений из модели в поля
            SetValueFields();
        }


        // конструктор для запуска формы в режиме редактирования
        public RentalForm(CarRentalDataContext data, Rental rental)
        {
            InitializeComponent();

            // установка ссылки на объект модели базы данных
            Data = data;

            // установка ссылки на редактируемый объект
            _rentalModel = rental;

            // заполнение ComboBox
            SetComboBoxesValues();

            // установка значений из модели в поля
            SetValueFields();

            // установка текста заголовков
            Text = LblHeader.Text = "Редактирование факта проката";

            // установка текта на кнопке
            BtnOk.Text = "Сохранить";
        }

        #endregion

        #region Методы

        // установка значений из модели в поля
        public void SetValueFields()
        {
            TbxDate.Text            = $"{_rentalModel.DateStart:d}";
            CmbBrand.SelectedItem   = _rentalModel.Car.Brand.Brand1;
            CmbClient.SelectedItem  = _rentalModel.Client.Passport;
            NudDuration.Value       = _rentalModel.Duration;
        }

        // установка значений для комбо-боксов
        public void SetComboBoxesValues()
        {
            CmbBrand.Items.AddRange(Data.Brands.Select(g => g.Brand1).ToArray());
            CmbClient.Items.AddRange(Data.Clients.Select(c => c.Passport).ToArray());
        }

        #endregion

        // применение изменений
        private void BtnOk_Click(object sender, EventArgs e)
        {
            _rentalModel.DateStart          = DateTime.Parse(TbxDate.Text);
            _rentalModel.Car                = Data.Cars.Where(c => c.Brand.Brand1 == CmbBrand.SelectedItem as string).ToArray()[0];
            _rentalModel.Client             = Data.Clients.Where(c => c.Passport == CmbClient.SelectedItem as string).ToArray()[0]; ;
            _rentalModel.Duration           = (int)NudDuration.Value;
        }
    }
}
