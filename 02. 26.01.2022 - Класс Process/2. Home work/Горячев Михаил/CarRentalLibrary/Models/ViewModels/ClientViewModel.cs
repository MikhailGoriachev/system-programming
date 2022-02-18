using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalLibrary.Models.ViewModels
{
    // Класс Представление для класса Client
    public class ClientViewModel
    {
        // Id
        public int Id { get; set; }

        // фамилия клиента
        public string Surname { get; set; }

        // имя клиента
        public string Name { get; set; }

        // отчество клиента
        public string Patronymic { get; set; }

        // серия, номер паспорта клиента
        public string Passport { get; set; }

    }
}
