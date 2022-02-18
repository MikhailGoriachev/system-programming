using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalLibrary.Models.ViewModels
{
    // Класс Представление для класса Client
    public class CarsViewModel
    {
        // Id
        public int Id { get; set; }

        // модель
        public string Brand { get; set; }

        // цвет
        public string Color { get; set; }

        // госномер
        public string Plate { get; set; }

        // год выпуска
        public int YearManuf { get; set; }

        // страховая стоимость
        public int InshurancePay { get; set; }

        // стоимость одного дня
        public int Rental { get; set; }

    }
}
