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
    public class DeliveryManManager : IDeliveryManManager
    {
        private IDeliveryManDB DeliveryManDB { get; }
        private IDeliveryOrderListDB DeliveryOrderListDb { get; }
        private IOrderDB OrderDb { get; }
        private IWorkLocationDB WorkLocationDb { get; }
        private IRestaurantDB RestaurantDb { get; }
        private ILocationDB LocationDb { get; }
        private IPersonDB PersonDb { get; }
        private IOrderDishesDB OrderDishesDb { get; }
        private IDishesDB DishesDb { get; }

        public DeliveryManManager(IDeliveryManDB deliveryManDB, IDeliveryOrderListDB deliveryOrderListDb, IOrderDB orderDb, IWorkLocationDB workLocationDb, IRestaurantDB restaurantDb, ILocationDB locationDb, IPersonDB personDb, IOrderDishesDB orderDishesDb, IDishesDB dishesDb)
        {
            DeliveryManDB = deliveryManDB;
            DeliveryOrderListDb = deliveryOrderListDb;
            OrderDb = orderDb;
            WorkLocationDb = workLocationDb;
            RestaurantDb = restaurantDb;
            LocationDb = locationDb;
            PersonDb = personDb;
            OrderDishesDb = orderDishesDb;
            DishesDb = dishesDb;
        }

        public DeliveryMan AddDeliveryMan(DeliveryMan delivery)
        {
            return DeliveryManDB.AddDeliveryMan(delivery);
        }

        public DeliveryMan GetDeliveryMan(string EmailDelivery, string password)
        {
            return DeliveryManDB.GetDeliveryMan(EmailDelivery, password);
        }

        public DeliveryMan GetDeliveryManID(int deliveryMamId)
        {
            return DeliveryManDB.GetDeliveryManID(deliveryMamId);
        }
        public List<DeliveryMan> GetDeliveryMen()
        {
            return DeliveryManDB.GetDeliveryMen();
        }

        public DeliveryMan ChangeIsWorking(int IdDelivery, int IsWorking)
        {
            return DeliveryManDB.ChangeIsWorking(IdDelivery, IsWorking);
        }

        //To get a list of orders with the email and password of the deliveryman
        public List<Order> GetOrders(string login, string password)
        {
            //va chercher le livreur
            DeliveryMan deliveryMan = DeliveryManDB.GetDeliveryMan(login, password);
            //va chercher les deliveryOrderLists avec le livreur
            List<DeliveryOrderList> deliveryOrderLists = DeliveryOrderListDb.GetDeliveryOrderList(deliveryMan.Id_Delivery);
            List<Order> orders = new List<Order>();

            foreach (var m in deliveryOrderLists)
            {
                Order order = OrderDb.GetOrderIDOrder(m.ID_Order);
                orders.Add(order);
            }
            return orders;

        }

        //To get a list of restaurants with the initiales of the canton
        public List<Restaurant> GetRestaurantsWorkCanton(string Canton)
        {
            //va chercher toute les workLocations avec les initiales du canton
            List<WorkLocation> locations = WorkLocationDb.GetWorkLocationCanton(Canton);
            List<Restaurant> restaurantsEnd = new List<Restaurant>();
            foreach (var m in locations)
            {
                //va chercher la liste de restaurants qu'il y a a cette endroit
                List<Restaurant> restaurants = RestaurantDb.GetRestaurantIDLocation(m.ID_workLocation);
                foreach (var n in restaurants)
                {
                    Restaurant restaurant = RestaurantDb.GetRestaurantID(n.ID_restaurant);
                    restaurantsEnd.Add(restaurant);
                }
            }
            return restaurantsEnd;
        }

        //To get a list of restaurants with the name of the city
        public List<Restaurant> GetRestaurantsWorkCity(string City)
        {
            //va chercher toute les workLocations avec le nom de la ville
            WorkLocation workLocation = WorkLocationDb.GetWorkLocationCity(City);
            List<Restaurant> restaurants = RestaurantDb.GetRestaurantIDLocation(workLocation.ID_workLocation);
            return restaurants;
        }

        //To get the location with the email and the password of the deliveryman
        public Location GetLocation(string login, string password)
        {
            //va chercher le livreur
            DeliveryMan deliveryMan = DeliveryManDB.GetDeliveryMan(login, password);
            Location location = LocationDb.GetLocationID(deliveryMan.ID_Location);
            return location;
        }

        //To get the workLocation with the email and the password of the deliveryman
        public WorkLocation GetWorkLocation(string login, string password)
        {
            //va chercher le livreur
            DeliveryMan deliveryMan = DeliveryManDB.GetDeliveryMan(login, password);
            WorkLocation workLocation = WorkLocationDb.GetWorkLocationID(deliveryMan.ID_Location);
            return workLocation;
        }

        //To get a list of person with the name of a city
        public List<Person> GetPersonWorkCity(string City)
        {
            //va chercher la workLocation
            WorkLocation workLocation = WorkLocationDb.GetWorkLocationCity(City);
            List<Person> persons = PersonDb.GetPersonIDLocation(workLocation.ID_workLocation);
            return persons;
        }

        
        public DeliveryMan ModifyAllDeliveryMan(DeliveryMan delivery)
        {
            return DeliveryManDB.ModifyAllDeliveryMan(delivery);
        }

        public List<DeliveryMan> GetDeliveryManIDLocation(int ID_Location)
        {
            return DeliveryManDB.GetDeliveryManIDLocation(ID_Location);
        }

        public void ChangeNbDeliveries(int n, int ID_DeliveryMan)
        {
            var deliveryman = DeliveryManDB.GetDeliveryManID(ID_DeliveryMan);
            DeliveryManDB.ChangeNbDeliveries(deliveryman.nbDeliveries + n, ID_DeliveryMan);
        }
    }
}
