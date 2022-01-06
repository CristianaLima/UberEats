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
    public class OrderManager : IOrderManager
    {
        private IOrderDB OrderDB { get; }
        private IOrderDishesDB OrderDishesDB { get; }
        private IDishesDB DishesDB { get; }
        private IDeliveryManDB DeliveryManDB { get; }
        private IDeliveryOrderListDB DeliveryOrderListDB { get; }
        private IRestaurantDishesDB RestaurantDishesDB { get; }
        private IRestaurantDB RestaurantDB { get; }
        private ILocationDB LocationDB { get; }
        private IWorkLocationDB WorkLocationDB { get; }


        public OrderManager(IOrderDB orderDB, IOrderDishesDB orderDishesDB, IDishesDB dishesDB, IDeliveryManDB deliveryManDB, IDeliveryOrderListDB deliveryOrderListDB, IRestaurantDishesDB restaurantDishesDB, IRestaurantDB restaurantDB, ILocationDB locationDB, IWorkLocationDB workLocationDB)
        {
            OrderDB = orderDB;
            OrderDishesDB = orderDishesDB;
            DishesDB = dishesDB;
            DeliveryManDB = deliveryManDB;
            DeliveryOrderListDB = deliveryOrderListDB;
            RestaurantDishesDB = restaurantDishesDB;
            RestaurantDB = restaurantDB;
            LocationDB = locationDB;
            WorkLocationDB = workLocationDB;

        }

        public List<Order> GetOrders()
        {
            return OrderDB.GetOrders();
        }



        public Order AddOrder(Order order)
        {
            return OrderDB.AddOrder(order);
        }

        public DeliveryMan AssignDeliveryMan(Order order)
        {
            //1. retourner la liste des DeliveryMan dans la région du restaurant
            //   aller rechercher la location du restaurant
            List<OrderDishes> orderDishes = OrderDishesDB.GetOrderDishes(order.ID_Order);
            //Console.WriteLine(orderDishes.First().ToString);
            var firstDishes = orderDishes[0];
            var idDishes = firstDishes.ID_Dishes;//[1].ID_Dishes;
            RestaurantDishes restaurantDishes = RestaurantDishesDB.GetRestaurant(idDishes);
            Restaurant restaurant = RestaurantDB.GetRestaurantID(restaurantDishes.ID_restaurant);
            Location locationRestaurant = LocationDB.GetLocationID(restaurant.ID_location);

            // aller chercher la worklocation des deliveryMan
            List<DeliveryMan> deliverymen = DeliveryManDB.GetDeliveryManIDLocation(locationRestaurant.ID_location);
            int minNB = 1000, idMin = -1;
            foreach (var m in deliverymen)
            {
                if (m.IsWorking == 1)
                {
                    DateTime min = order.DelaiLivraison.AddMinutes(-15);
                    DateTime max = order.DelaiLivraison.AddMinutes(15);
                    int nb = NbDeliveries(m.Id_Delivery, min, max);
                    if (nb < 5)
                    {
                        if (nb < minNB)
                        {
                            minNB = nb;
                            idMin = m.Id_Delivery;
                        }
                    }
                }
            }

            if (idMin == -1)
            {
                DeliveryMan deli = null;
                return deli;
            }
            
            Console.WriteLine(minNB + " " + idMin);
            DeliveryOrderList deliveryOrderList = DeliveryOrderListDB.AddDeliveryOrderList(new DeliveryOrderList { Id_Delivery = idMin, ID_Order = order.ID_Order, NumStatut = 1 });
            
            return DeliveryManDB.GetDeliveryManID(idMin);
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

        public int NbDeliveries(int ID_DeliveryMan, DateTime minimum, DateTime maximum)
        {
            //aller chercher les orders du deliveryMan
            List<DeliveryOrderList> deliveriesOrderList = DeliveryOrderListDB.GetDeliveryOrderList(ID_DeliveryMan);
            int nbDeliveries = 0;
            foreach (var m in deliveriesOrderList)
            {
                Order order = OrderDB.GetOrderIDOrder(m.ID_Order);
                if (order.DelaiLivraison > minimum && order.DelaiLivraison < maximum)
                {
                    nbDeliveries++;
                }
            }
            return nbDeliveries;
        }
        public void Remove(int idorder)
        {
            OrderDB.Remove(idorder);
        }
    }
}
