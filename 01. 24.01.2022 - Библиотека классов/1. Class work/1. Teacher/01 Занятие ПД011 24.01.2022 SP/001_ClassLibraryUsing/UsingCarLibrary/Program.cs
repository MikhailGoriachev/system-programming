using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CarLibrary;
using Petshop;
using ExhibitionModel;


namespace UsingCarLibrary
{
    // пример использования класса из библиотеки классов т.е. dll .NET 
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 24.01.2022 - библиотека классов .Net";

            /* Использование библиотеки классов "Коллекция автомобилей" CarLibrary.dll  */
            Bus bus = new Bus(120, 68, 50, 12);
            Console.WriteLine($"bus: {bus}");
            bus.Passengers = 20;
            Console.WriteLine($"bus: {bus}");
            bus.Up();
            Console.WriteLine($"bus: {bus}");
            Console.WriteLine();
            
            // Truck truck = new Truck(50, 30, 3500, 3500);
            Truck truck = new Truck();
            Console.WriteLine($"truck: {truck}");

            truck.Down();
            Console.WriteLine($"truck: после разгрузки {truck}");

            truck.Up();
            Console.WriteLine($"truck: после погрузки {truck}");
            Console.Write("Нажмите любую клавишу для продолжения... ");
            Console.ReadKey(true);

            
            Pet pet = new Pet
            {
                Name = "Вася",
                Description = "Рыжий милаха"
            };
            Console.WriteLine($"\n\n{pet}\n");
            Console.Write("Нажмите любую клавишу для продолжения... ");
            Console.ReadKey(true);

            /* Использование библиотеки классов "Выставка и картины" ExhibitionModel.dll */

            List<Picture> pictures = new List<Picture>(new[] {
                new Picture {Id =1, Genre = Genres.Landscape, Artist = "Иванов И.Р.",     Title = "Дуборвая роща",    Year = 1976},
                new Picture {Id =2, Genre = Genres.StillLive, Artist = "Живчик П.О.",     Title = "Сельдь и лук",     Year = 1961},
                new Picture {Id =3, Genre = Genres.Portrait,  Artist = "Столярова А.А.",  Title = "Маляр",            Year = 1976},
                new Picture {Id =4, Genre = Genres.Landscape, Artist = "Столярова А.А.",  Title = "Новостройки",      Year = 1976},
                new Picture {Id =5, Genre = Genres.StillLive, Artist = "Добродеева К.Н.", Title = "Сыр и кефир",      Year = 1966},
                new Picture {Id =6, Genre = Genres.StillLive, Artist = "Добродеева К.Н.", Title = "Бородинский хлеб", Year = 1977},
                new Picture {Id =7, Genre = Genres.Portrait,  Artist = "Столярова А.А.",  Title = "Бригада С",        Year = 1982}
            });

            Exhibition exhibition = new Exhibition {
                Id       = 1,
                Place    = "ул. 230й стрелковой дивизии",
                Date     = new DateTime(2020, 5, 29),
                Pictures = pictures
            };

            Console.WriteLine($"\n\n{exhibition.Place} | {exhibition.Date:d} |");
            pictures.ForEach(Console.WriteLine);
            
            Console.WriteLine("\n\n");
        } // Main
    } // class Program
}
