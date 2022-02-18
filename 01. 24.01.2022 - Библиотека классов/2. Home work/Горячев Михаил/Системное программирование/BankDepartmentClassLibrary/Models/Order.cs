using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BankDepartmentClassLibrary.Utilities;         // утилиты

/* 
 * Поля класса Платеж
 *      - расчетный счет плательщика;
 *      - расчетный счет получателя;
 *      - текущая сумма на счету плательщика (в рублях)
 *      - текущая сумма на счету получателя (в рублях)
 *      - сумма платежа
*/


namespace BankDepartmentClassLibrary.Models
{
    // Класс Платеж
    [Serializable]
    public class Order
    {
        // расчетный счет плательщика
        private string _senderAccount;

        public string SenderAccount
        {
            get => _senderAccount;
            set => _senderAccount = value;
        }


        // расчетный счет получателя
        private string _receiverAccount;

        public string ReceiverAccount
        {
            get => _receiverAccount;
            set => _receiverAccount = value;
        }


        // текущая сумма на счету плательщика(в рублях)
        private int _senderAmount;

        public int SenderAmount
        {
            get => _senderAmount;
            set => _senderAmount = value;
        }


        // текущая сумма на счету получателя(в рублях)
        private int _receiverAmount;

        public int ReceiverAmount
        {
            get => _receiverAmount;
            set => _receiverAmount = value;
        }


        // сумма платежа
        private int _amountPayment;

        public int AmountPayment
        {
            get => _amountPayment;
            set => _amountPayment = value;
        }


        #region 

        // фабричный метод 
        public static Order GetOrder() => new Order
        {
            SenderAccount = LibraryUtils.GetPayNumber(),
            ReceiverAccount = LibraryUtils.GetPayNumber(),
            AmountPayment = LibraryUtils.GetRand(10, 100) * 1000,
            ReceiverAmount = LibraryUtils.GetRand(10, 100) * 1000,
            SenderAmount = LibraryUtils.GetRand(10, 100) * 1000
        };

        #endregion

    }
}
