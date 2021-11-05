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
        int GetOrderID(int ID_person, DateTime OrderDate);
        Order AddOrder(Order order);
        List<Order> GetOrderIDPerson(int idPerson);
        Order GetOrderIDOrder(int IdOrder);
        Order ModifyAllOrder(Order order);
    }
}
