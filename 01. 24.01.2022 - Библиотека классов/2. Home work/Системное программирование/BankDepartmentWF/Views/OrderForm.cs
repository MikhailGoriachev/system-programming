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

namespace BankDepartmentWF.Views
{
    public partial class OrderForm : Form
    {
        // обрабатываемый платеж
        private Order _orderModel;

        public Order OrderModel => _orderModel;


        #region Конструкторы

        // конструктор для запуска в режиме создания
        public OrderForm()
        {
            InitializeComponent();

            // установка значений
            _orderModel = Order.GetOrder();

            // заполнение полей
            TbxSenderAccount.Text   = _orderModel.SenderAccount;
            TbxReceiverAccount.Text = _orderModel.ReceiverAccount;
            NudSenderAmount.Value   = _orderModel.SenderAmount;
            NudReceiverAmount.Value = _orderModel.ReceiverAmount;
            NudAmountPayment.Value  = _orderModel.AmountPayment;

        }


        // конструктор для запуска в режиме редактирования
        public OrderForm(Order order)
        {
            InitializeComponent();

            // установка значений
            _orderModel = order;

            // заполнение полей
            TbxSenderAccount.Text   = _orderModel.SenderAccount;
            TbxReceiverAccount.Text = _orderModel.ReceiverAccount;
            NudSenderAmount.Value   = _orderModel.SenderAmount;
            NudReceiverAmount.Value = _orderModel.ReceiverAmount;
            NudAmountPayment.Value  = _orderModel.AmountPayment;

            // установка заголовка
            Text = LblHeader.Text = "Редактирование платежа";

            // установка текста кнопки сохранения изменений
            BtnOk.Text = "Сохранить";
        }

        #endregion

        #region Методы

        // проверка изменения текста
        private void TextBox_TextChanged(object sender, EventArgs e) =>
            BtnOk.Enabled = !string.IsNullOrWhiteSpace(TbxReceiverAccount.Text) && !string.IsNullOrWhiteSpace(TbxSenderAccount.Text);


        // установка значений с полей ввода в поля платежа
        private void BtnOk_Click(object sender, EventArgs e)
        {
            _orderModel.SenderAccount   =   TbxSenderAccount.Text;
            _orderModel.ReceiverAccount =   TbxReceiverAccount.Text;
            _orderModel.SenderAmount    =   (int)NudSenderAmount.Value;
            _orderModel.ReceiverAmount  =   (int)NudReceiverAmount.Value;
            _orderModel.AmountPayment   =   (int)NudAmountPayment.Value;
        }

        #endregion

    }
}
