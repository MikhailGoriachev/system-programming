using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarRentalLibrary.Models.ViewModels;       // модели представления
using CarRentalLibrary.Models;                  // модели
using CarRentalLibrary.Utilities;               // утилиты

/*
 *  1.Разработайте библиотеку классов для доступа к базе данных (из задания на 29.11.2022) 
 *  при помощи LINQ to SQL и выполнения запросов по заданию. Также требуется разработать 
 *  запросы, ко всем таблицам базы данных для выборки всех записей. Конечно же, все запросы
 *  должны возвращать коллекции.
 *  
 *  База данных «Прокат автомобилей»
 *  
 *  Описание предметной области
 *  Фирма выдает напрокат автомобили. При этом фиксируется информация о клиенте, 
 *  информация об автомобиле, дата начала проката и количество дней проката. Стоимость 
 *  одного дня проката является фиксированной для каждого автомобиля. В случае аварии 
 *  клиент выплачивает фирме возмещение в размере, равном некоторому проценту от страховой 
 *  стоимости автомобиля.
 *  
 *  Стоимость проката автомобиля определяется как Стоимость одного дня проката * Количество 
 *  дней проката. 
 *  
 *  Фирма ежегодно страхует автомобили, выдаваемые клиентам. Страховой взнос, выплачиваемый
 *  фирмой, равен 10% от страховой стоимости автомобиля.
 *  
 *  База данных должна включать как минимум таблицы КЛИЕНТЫ, АВТОМОБИЛИ, ФАКТЫ_ПРОКАТА, 
 *  содержащие следующую информацию:
 *      - Фамилия клиента
 *      - Имя клиента
 *      - Отчество клиента
 *      - Серия, и номер паспорта клиента
 *      - Модель автомобиля, включая бренд (это лучше разместить в отдельной таблице)
 *      - Цвет автомобиля(это лучше разместить в отдельной таблице)
 *      - Год выпуска автомобиля
 *      - Госномер автомобиля
 *      - Страховая стоимость автомобиля
 *      - Стоимость одного дня проката
 *      - Дата начала проката
 *      - Количество дней проката
 *  
 *  Определить состав полей базовых таблиц.
 *  Определить свойства каждого поля в таблице.
 *  В каждой таблице определить ключевое поле.
 *  Определить тип связей между таблицами базы данных.
 *  Установить связи между таблицами.
 *  
 *  Разработайте скрипты:
 *  •	создания таблиц 
 *  •	создания представлений для таблиц с внешними ключами
 *  •	заполнения таблиц начальным набором данных. Каждая таблица должна содержать
 *      не менее 10 записей.
 *  
 *  ЗАПРОСЫ
 *  1	Выборка данных	Выбирает информацию обо всех фактах проката автомобиля с 
 *      заданным госномером
 *  2	Выборка данных	Выбирает информацию обо всех фактах проката автомобиля с 
 *      заданной моделью/брендом
 *  3	Выборка данных	Выбирает информацию о клиентах по серии и номеру паспорта
 *  4	Выборка данных	Вычисляет для каждого факта проката стоимость проката.
 *      Включает поля Дата проката, Госномер автомобиля, Модель автомобиля, Стоимость
 *      проката. Сортировка по полю Дата проката
 *   	 	 
 *  5	Запрос с левым соединением	Для всех клиентов прокатной фирмы вычисляет 
 *      количество фаыктов проката, суммарное количество дней проката, упорядочивание
 *      по убыванию суммарного количества дней проката
 *  6	Запрос с левым соединением	Для всех автомобилей прокатной фирмы определите
 *      количество фактов проката, сумма за прокаты, суммарная длительность прокатов
*/

namespace CarRentalLibrary.Controllers
{
    // Класс Контроллер запросов по заданию
    public class QueryController
    {
        // модель доступа к базе данных
        private CarRentalDataContext _data;

        public CarRentalDataContext Data
        {
            get => _data;
            set => _data = value;
        }


        #region Конструкторы

        // конструктор по умолчанию
        public QueryController() : this(new CarRentalDataContext()) { }


        // конструктор инициализирующий
        public QueryController(CarRentalDataContext data)
        {
            // установка значений
            _data = data;
        }

        #endregion

        #region Методы 

        #region Получение всех записей таблиц

        // все записи таблицы Brands          (Модели_автомобилей)
        public List<Brand> GetBrands() => _data.Brands.ToList();


        // все записи таблицы Colors          (Цвета)
        public List<Color> GetColors() => _data.Colors.ToList();


        // все записи таблицы Clients         (Клиенты)
        public List<Client> GetClients() => _data.Clients.ToList();


        // все записи таблицы Cars            (Машины)
        public List<CarsViewModel> GetCars() => _data.Cars.Select(c => new CarsViewModel
                                                        {
                                                            Id = c.Id,
                                                            Brand = c.Brand.Brand1,
                                                            Color = c.Color.Color1,
                                                            Plate = c.Plate,
                                                            YearManuf = c.YearManuf,
                                                            InshurancePay = c.InshurancePay,
                                                            Rental = c.Rental
                                                        }).ToList();


        // все записи таблицы Rentals         (Факты_проката)
        public IEnumerable GetRentals() => _data.Rentals.Select(r => new
                                                        {
                                                            r.Id,
                                                            Client = $"{r.Client.Surname} {r.Client.Name[0]}. {r.Client.Patronymic[0]}.",
                                                            Brand = r.Car.Brand.Brand1,
                                                            Color = r.Car.Color.Color1,
                                                            r.Car.Plate,
                                                            r.Car.Rental,
                                                            r.DateStart,
                                                            r.Duration
                                                        });


        #endregion

        #region Запросы по заданию


        // 1. Факты проката по заданному номеру автомобиля
        public List<RentalViewModel> Query1(string plate) => (from r in _data.Rentals
                                                              where r.Car.Plate == plate
                                                              select new RentalViewModel
                                                              {
                                                                  Id           = r.Id,
                                                                  Client       = $"{r.Client.Surname} {r.Client.Name[0]}. {r.Client.Patronymic[0]}.",
                                                                  Brand        = r.Car.Brand.Brand1,
                                                                  Color        = r.Car.Color.Color1,
                                                                  Plate        = r.Car.Plate,
                                                                  Rental       = r.Car.Rental,
                                                                  DateStart    = r.DateStart,
                                                                  Duration     = r.Duration
                                                              }).ToList();


        // 2. Факты проката по с заданной моделью автомобиля
        public List<RentalViewModel> Query2(string brand) => (from r in _data.Rentals
                                                              where r.Car.Brand.Brand1 == brand
                                                              select new RentalViewModel
                                                              {
                                                                  Id           = r.Id,
                                                                  Client       = $"{r.Client.Surname} {r.Client.Name[0]}. {r.Client.Patronymic[0]}.",
                                                                  Brand        = r.Car.Brand.Brand1,
                                                                  Color        = r.Car.Color.Color1,
                                                                  Plate        = r.Car.Plate,
                                                                  Rental       = r.Car.Rental,
                                                                  DateStart    = r.DateStart,
                                                                  Duration     = r.Duration
                                                              }).ToList();


        // 3. Клиенты по заданной серии серии и номеру паспорту
        public List<ClientViewModel> Query3(string passport) => (from c in _data.Clients
                                                                 where c.Passport == passport
                                                                 select new ClientViewModel 
                                                                 { 
                                                                    Id          = c.Id,
                                                                    Surname     = c.Surname,
                                                                    Name        = c.Name,
                                                                    Patronymic  = c.Patronymic,
                                                                    Passport    = c.Passport
                                                                 }).ToList();


        // 4. Все факты проката со стоимостью проката. Сортировка по полю Дата проката
        public List<Query4ViewModel> Query4() => (from r in _data.Rentals
                                                  select new Query4ViewModel {
                                                      Id        = r.Id,
                                                      DateStart = r.DateStart,
                                                      Plate     = r.Car.Plate,
                                                      Brand     = r.Car.Brand.Brand1,
                                                      Duration  = r.Duration,
                                                      Rental    = r.Car.Rental,
                                                      SumPrice  = r.Car.Rental * r.Duration
                                                  }).OrderBy(r => r.DateStart)
                                                    .ToList();


        // 5. Количество фактов проката и суммарное количество дней проката для каждого клиента.
        //    Сортировка по убыванию суммарного количества дней проката
        public List<Query5ViewModel> Query5() => (from c in _data.Clients
                                                  join r in _data.Rentals on c.Id equals r.IdClient into Result
                                                  from res in Result.DefaultIfEmpty()
                                                  group res by new { c.Id, c.Surname, c.Name, c.Patronymic } into Group
                                                  select new Query5ViewModel
                                                  {
                                                      Id            = Group.Key.Id,
                                                      Surname       = Group.Key.Surname,
                                                      Name          = Group.Key.Name,
                                                      Patronymic    = Group.Key.Patronymic,
                                                      CountRentals  = Group.Count(g => g != null),
                                                      SumDuration   = Group.Sum(g => g != null ? g.Duration : 0)
                                                  }).OrderByDescending(c => c.SumDuration)
                                                    .ToList();


        // 6. Количество фактов проката, сумма, суммарная длительность прокатов для каждого автомобиля
        public List<Query6ViewModel> Query6() => (from c in _data.Cars
                                                  join r in _data.Rentals on c.Id equals r.Car.Id into Result
                                                  from res in Result.DefaultIfEmpty()
                                                  group res by new { c.Id, c.Brand.Brand1, c.Plate, c.Rental } into Group
                                                  select new Query6ViewModel
                                                  {
                                                      Id            = Group.Key.Id,
                                                      Brand         = Group.Key.Brand1,
                                                      Plate         = Group.Key.Plate,
                                                      Rental        = Group.Key.Rental,
                                                      CountRentals  = Group.Count(g => g != null),
                                                      SumRentals    = Group.Sum(g => g != null ? g.Car.Rental * g.Duration : 0),
                                                      SumDuration   = Group.Sum(g => g != null ? g.Duration : 0)
                                                  }).ToList();


        // получить госномер автомобиля
        public string GetPlate() => _data.Rentals.ToList()[Utils.GetRand(0, _data.Rentals.Count())].Car.Plate;


        // получить модель автомобиля
        public string GetBrand() => _data.Rentals.ToList()[Utils.GetRand(0, _data.Rentals.Count())].Car.Brand.Brand1;


        // получить паспорт клиента
        public string GetPassport() => _data.Rentals.ToList()[Utils.GetRand(0, _data.Rentals.Count())].Client.Passport;

        #endregion

        #endregion
    }
}
