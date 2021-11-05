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
        private IOrderDishesDB OrderDishesDB { get; }
        private IDishesDB DishesDB { get; }
        private IDeliveryManDB DeliveryManDB { get; }
        private IDeliveryOrderListDB DeliveryOrderListDB { get; }

        public OrderManager(IConfiguration conf)
        {
            OrderDB = new OrderDB(conf);
            OrderDishesDB = new OrderDishesDB(conf);
            DishesDB = new DishesDB(conf);
            DeliveryManDB = new DeliveryManDB(conf);
            DeliveryOrderListDB = new DeliveryOrderListDB(conf);
        }

        public List<Order> GetOrders()
        {
            return OrderDB.GetOrders();
        }

     

        public Order AddOrder(Order order)
        {
            return OrderDB.AddOrder(order);
        }

        public int GetOrderID(int ID_person, DateTime OrderDate)
        {
            return OrderDB.GetOrderID(ID_person, OrderDate);
        }

        public List<Order> GetOrderIDPerson(int idPerson)
        {
            return OrderDB.GetOrderIDPerson(idPerson);
        }

        public Order GetOrderIDOrder(int IdOrder)
        {
            return OrderDB.GetOrderIDOrder(IdOrder);
        }

        public List<Dishes> GetDishesFromOrder(int OrderID)
        {
            var dishesOrder = OrderDishesDB.GetOrderDishes(OrderID);
            var dishes = new List<Dishes>();

            foreach (var m in dishesOrder)
            {
                var idDishes = m.ID_Dishes;
                Dishes dish = DishesDB.GetDishIP(idDishes);
                dishes.Add(dish);
            }

            return dishes;
        }

        public DeliveryMan GetDeliveryManFromOrder(int OrderID)
        {
            var deliveryManOrder = DeliveryOrderListDB.GetDeliveryManFromOrderID(OrderID);
           
            var deliveryMan = DeliveryManDB.GetDeliveryManID(deliveryManOrder.Id_Delivery);
            
            return deliveryMan;
        }

        public Order ModifyAllOrder(Order order)
        {
            return OrderDB.ModifyAllOrder(order);
        }
    }
}
