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
            DeliveryManDB = new DeliveryManDB(conf);
            DeliveryOrderListDb = new DeliveryOrderListDB(conf);
            OrderDb = new OrderDB(conf);
            WorkLocationDb = new WorkLocationDB(conf);
            RestaurantDb = new RestaurantDB(conf);
            LocationDb = new LocationDB(conf);
            PersonDb = new PersonDB(conf);
            OrderDishesDb = new OrderDishesDB(conf);
            DishesDb = new DishesDB(conf);
        }

        public DeliveryMan AddDeliveryMan(DeliveryMan delivery)
        {
            return DeliveryManDB.AddDeliveryMan(delivery);
        }

        public DeliveryMan GetDeliveryMan(string username, string password)
        {
            return DeliveryManDB.GetDeliveryMan(username, password);
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

        public List<Order> GetOrders(string login, string password)
        {
            DeliveryMan deliveryMan = DeliveryManDB.GetDeliveryMan(login, password);
            List<DeliveryOrderList> deliveryOrderLists = DeliveryOrderListDb.GetDeliveryOrderList(deliveryMan.Id_Delivery);
            List<Order> orders = new List<Order>();

            foreach (var m in deliveryOrderLists)
            {
                Order order = OrderDb.GetOrderIDOrder(m.ID_Order);
                orders.Add(order);
            }
            return orders;

        }

        public List<Restaurant> GetRestaurantsWorkCanton(string Canton)
        {
            List<WorkLocation> locations = WorkLocationDb.GetWorkLocationCanton(Canton);
            List<Restaurant> restaurantsEnd = new List<Restaurant>();
            foreach (var m in locations)
            {
                List<Restaurant> restaurants = RestaurantDb.GetRestaurantIDLocation(m.ID_workLocation);
                foreach (var n in restaurants)
                {
                    Restaurant restaurant = RestaurantDb.GetRestaurantID(n.ID_restaurant);
                    restaurantsEnd.Add(restaurant);
                }
            }
            return restaurantsEnd;
        }

        public List<Restaurant> GetRestaurantsWorkCity(string City)
        {
            WorkLocation workLocation = WorkLocationDb.GetWorkLocationCity(City);
            List<Restaurant> restaurants = RestaurantDb.GetRestaurantIDLocation(workLocation.ID_workLocation);
            return restaurants;
        }

        public Location GetLocation(string login, string password)
        {
            DeliveryMan deliveryMan = DeliveryManDB.GetDeliveryMan(login, password);
            Location location = LocationDb.GetLocationID(deliveryMan.ID_Location);
            return location;
        }
        public WorkLocation GetWorkLocation(string login, string password)
        {
            DeliveryMan deliveryMan = DeliveryManDB.GetDeliveryMan(login, password);
            WorkLocation workLocation = WorkLocationDb.GetWorkLocationID(deliveryMan.ID_Location);
            return workLocation;
        }
        public List<Person> GetPersonWorkCity(string City)
        {
            WorkLocation workLocation = WorkLocationDb.GetWorkLocationCity(City);
            List<Person> persons = PersonDb.GetPersonIDLocation(workLocation.ID_workLocation);
            return persons;
        }

        public List<Dishes> GetAllDishes(string login, string password)
        {
            List<Order> orders = GetOrders(login, password);
            List<Dishes> dishes = new List<Dishes>();
            foreach (var m in orders)
            {
                List<OrderDishes> orderDishes = OrderDishesDb.GetOrderDishes(m.ID_Order);
                foreach (var n in orderDishes)
                {
                    Dishes dish = DishesDb.GetDishIP(n.ID_Dishes);
                    dishes.Add(dish);
                }
            }
            return dishes;

        }
        public List<Dishes> GetDishes(int IdOrder)
        {
            List<OrderDishes> orderDishes = OrderDishesDb.GetOrderDishes(IdOrder);
            List<Dishes> dishes = new List<Dishes>();
            foreach (var n in orderDishes)
            {
                Dishes dish = DishesDb.GetDishIP(n.ID_Dishes);
                dishes.Add(dish);
            }
            return dishes;
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
