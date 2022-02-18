using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalLibrary.Models.ViewModels
{
    // Класс Представление для результата запроса 4
    public class Query4ViewModel
    {
        // Id
        public int Id { get; set; }

        // дата начала проката
        public DateTime DateStart { get; set; }

        // госномер
        public string Plate { get; set; }

        // модель
        public string Brand { get; set; }

        // cтоимость одного дня проката
        public int Rental { get; set; }

        // количество дней проката
        public int Duration { get; set; }

        // количество дней проката
        public int SumPrice { get; set; }

    }
}
