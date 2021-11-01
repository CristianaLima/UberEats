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
    public class OrderManager
    {
        private IOrderDB OrderDB { get; }

        public OrderManager(IConfiguration conf)
        {
            OrderDB = new OrderDB(conf);
        }

        public List<Order> GetOrders()
        {
            return OrderDB.GetOrders();
        }

        public Order GetOrder(string OrderName)
        {
            return OrderDB.GetOrder(OrderName);
        }

        public Order AddOrder(Order order)
        {
            return OrderDB.AddOrder(order);
        }

        public int GetOrderID(int ID_person, DateTime OrderDate)
        {
            return OrderDB.GetOrderID(ID_person, OrderDate);
        }
    }
}
