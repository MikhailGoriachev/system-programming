using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalLibrary.Models.ViewModels
{
    // Класс Представление для результата запроса 5
    public class Query5ViewModel
    {
        // Id
        public int Id { get; set; }

        // фамилия клиента
        public string Surname { get; set; }

        // имя клиента
        public string Name { get; set; }

        // отчество клиента
        public string Patronymic { get; set; }

        // количество фактов проката
        public int CountRentals { get; set; }

        // суммарная длительность
        public int SumDuration { get; set; }

    }
}
