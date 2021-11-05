using DTO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public interface IOrderManager
    {
        Order AddOrder(Order order);
        DeliveryMan GetDeliveryManFromOrder(int OrderID);
        List<Dishes> GetDishesFromOrder(int OrderID);
        int GetOrderID(int ID_person, DateTime OrderDate);
        Order GetOrderIDOrder(int IdOrder);
        List<Order> GetOrderIDPerson(int idPerson);
        List<Order> GetOrders();
        Order ModifyAllOrder(Order order);
        int NbDeliveries(int ID_DeliveryMan, DateTime minimum, DateTime maximum);
    }
}