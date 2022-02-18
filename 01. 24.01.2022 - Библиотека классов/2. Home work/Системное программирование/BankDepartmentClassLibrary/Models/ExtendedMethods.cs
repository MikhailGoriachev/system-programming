using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDepartmentClassLibrary.Models
{
    // Класс Расширяющие методы
    public static class ExtendedMethods
    {
        // фабричный метод списка платежей
        //public static List<Order> GetOrders(this List<Order> orders, int n = 15) => Enumerable.Repeat(new Order(), n)
        //                                                                                      .Select(s => Order.GetOrder())
        //                                                                                      .ToList();        
        public static List<Order> GetOrders(this List<Order> orders, int n = 15) 
        {
            List<Order> list = new List<Order>();

            for (int i = 0; i < n; i++)
                list.Add(Order.GetOrder());

            return list;
        }
    }
}
