using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalLibrary.Models.ViewModels
{
    // Класс Представление для класса Rental
    public class RentalViewModel
    {
        // Id
        public int Id { get; set; }

        // клиент
        public string Client { get; set; }

        // модель
        public string Brand { get; set; }

        // цвет
        public string Color { get; set; }

        // госномер
        public string Plate { get; set; }

        // cтоимость одного дня проката
        public int Rental { get; set; }

        // дата начала проката
        public DateTime DateStart { get; set; }

        // количество дней проката
        public int Duration { get; set; }

    }
}
