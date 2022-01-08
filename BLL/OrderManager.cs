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

        //To assign a deliveryman to a order
        public DeliveryMan AssignDeliveryMan(Order order)
        {
            //1. retourner la liste des DeliveryMan dans la region du restaurant
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
            //S'il n'a pas de deliveryman alors il retourne null
            if(deliverymen == null)
            {
                DeliveryMan deli = null;
                return deli;
            }
            foreach (var m in deliverymen)
            {
                // regarde s'il travail
                if (m.IsWorking == 1)
                {
                    // pour savoir le nombre de commande il a deja a faire entre avant et apres 15 minutes
                    //de l'horaire de livraison de la nouvelle commande
                    DateTime min = order.DelaiLivraison.AddMinutes(-15);
                    DateTime max = order.DelaiLivraison.AddMinutes(15);
                    int nb = NbDeliveries(m.Id_Delivery, min, max);
                    //S'il est plus petit que 5, on peut lui assigner cette commande
                    if (nb < 5)
                    {
                        //On prend le livreur qui a le moins de commande a livrer
                        if (nb < minNB)
                        {
                            minNB = nb;
                            idMin = m.Id_Delivery;
                        }
                    }
                }
            }
            //Si idMin est egale a -1 ça veut dire qu'il n'y a pas de livreur disponible
            if (idMin == -1)
            {
                DeliveryMan deli = null;
                return deli;
            }
            
            //assigne le livreur a la commande
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

        //To get a list of dishes with its idOrder
        public List<Dishes> GetDishesFromOrder(int OrderID)
        {
            //avec cette methode on a une list de orderDishes et nous voulons une liste de dishes
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

        //To get the number of deliveries by a deliveryman at a given time
        public int NbDeliveries(int ID_DeliveryMan, DateTime minimum, DateTime maximum)
        {
            //aller chercher les orders du deliveryMan
            List<DeliveryOrderList> deliveriesOrderList = DeliveryOrderListDB.GetDeliveryOrderList(ID_DeliveryMan);
            int nbDeliveries = 0;
            foreach (var m in deliveriesOrderList)
            {
                //on compte seulement les commandes qui ne sont pas annule
                if(m.NumStatut!=0) {
                Order order = OrderDB.GetOrderIDOrder(m.ID_Order);
                //verifie si la commande rentre dans le temps donne
                if (order.DelaiLivraison > minimum && order.DelaiLivraison < maximum)
                {
                    nbDeliveries++;
                }
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
