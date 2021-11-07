using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderDishesManager : IOrderDishesManager
    {
        private IOrderDishesDB OrderDishesDb { get; }

        public OrderDishesManager(IConfiguration conf)
        {
            OrderDishesDb = new OrderDishesDB(conf);
        }
        public OrderDishes AddOrderDishes(OrderDishes orderDishes)
        {
            Console.WriteLine("Hello");
            return OrderDishesDb.AddOrderDishes(orderDishes);
        }
        public List<OrderDishes> GetAllOrderDishes()
        {
            return OrderDishesDb.GetAllOrderDishes();
        }

        public List<OrderDishes> GetOrderDishes(int IdOrder)
        {
            return OrderDishesDb.GetOrderDishes(IdOrder);
        }
    }
}
