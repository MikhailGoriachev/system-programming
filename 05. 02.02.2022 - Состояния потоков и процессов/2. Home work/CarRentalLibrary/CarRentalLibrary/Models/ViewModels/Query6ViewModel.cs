using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalLibrary.Models.ViewModels
{
    // Класс Представление для результата запроса 6
    public class Query6ViewModel
    {
        // Id
        public int Id { get; set; }

        // модель
        public string Brand { get; set; }

        // госномер
        public string Plate { get; set; }

        // cтоимость одного дня проката
        public int Rental { get; set; }

        // количество фактов проката
        public int CountRentals { get; set; }

        // сумма прокатов
        public int SumRentals { get; set; }

        // длительность прокатов
        public int SumDuration { get; set; }

    }
}
