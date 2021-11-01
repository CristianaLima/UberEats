using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IOrderDB
    {
        List<Order> GetOrders();
        Order GetOrder(string OrderName);
        int GetOrderID(int ID_person, DateTime OrderDate);
        Order AddOrder(Order order);
    }
}
