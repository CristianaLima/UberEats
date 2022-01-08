using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DeliveryManController : Controller
    {
        private IDeliveryManManager DeliveryManManager;
        private IDeliveryOrderListManager DeliveryOrderListManager;
        private IOrderManager OrderManager;
        private IOrderDishesManager OrderDishesManager;
        private IDishesManager DishesManager;
        private IRestaurantDishesManager RestaurantDishesManager;
        private IRestaurantManager RestaurantManager;
        private ILocationManager LocationManager;
        private IPersonManager PersonManager;

        public DeliveryManController(IDeliveryManManager deliveryManManager, IDeliveryOrderListManager deliveryOrderListManager, IOrderManager orderManager, IOrderDishesManager orderDishesManager, IDishesManager dishesManager, IRestaurantDishesManager restaurantDishesManager, IRestaurantManager restaurantManager, ILocationManager locationManager, IPersonManager personManager)
        {
            DeliveryManManager = deliveryManManager;
            DeliveryOrderListManager = deliveryOrderListManager;
            OrderManager = orderManager;
            OrderDishesManager = orderDishesManager;
            DishesManager = dishesManager;
            RestaurantDishesManager = restaurantDishesManager;
            RestaurantManager = restaurantManager;
            LocationManager = locationManager;
            PersonManager = personManager;
        }
        // GET: DeliveryManController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("IdDeliveryMan") == null)
            {
                    return RedirectToAction("Index", "Login");
            }
            var id = (int) HttpContext.Session.GetInt32("IdDeliveryMan");
            var deliveryMan = DeliveryManManager.GetDeliveryManID(id);

            var statusVM = new StatusVM();
            var deliveryOrders = DeliveryOrderListManager.GetDeliveryOrderList(id);
            List<Order> orders = new List<Order>();
            List<int> status = new List<int>();
            foreach (var deliveryOrder in deliveryOrders)
            {
                var order = OrderManager.GetOrderIDOrder(deliveryOrder.ID_Order);
                orders.Add(order);
                status.Add(deliveryOrder.NumStatut);
            }
            statusVM.orders = orders;
            statusVM.status = status;

            return View("Index",statusVM);
        }

        // GET: DeliveryManController/Details/5
        public ActionResult Detail(int id)
        {
            DeliveryOrderDetailVM final = new DeliveryOrderDetailVM();
            List<RestaurantDishesVM> listRestaurantsDishes = new List<RestaurantDishesVM>();
            List<string> DishesName = new List<string>();
            List<int> Quantity = new List<int>();
            List<string> RestaurantName = new List<string>();
            List<string> RestaurantAddress = new List<string>();
            List<int> RestaurantNPA = new List<int>();
            List<string> RestaurantsCity = new List<string>();

            Order order = OrderManager.GetOrderIDOrder(id);
            var orderDishes = OrderDishesManager.GetOrderDishes(id);
            var dishes = OrderManager.GetDishesFromOrder(id);
            foreach(var orderDish in orderDishes)
            {
                var dish = DishesManager.GetDishIP(orderDish.ID_Dishes);
                Quantity.Add(orderDish.Quantity);
                DishesName.Add(dish.DishesName);

                var restaurantDish = RestaurantDishesManager.GetRestaurant(dish.ID_Dishes);
                var restaurant = RestaurantManager.GetRestaurantID(restaurantDish.ID_restaurant);
                RestaurantName.Add(restaurant.RestaurantName);
                RestaurantAddress.Add(restaurant.RestaurantAddress);

                var location = LocationManager.GetLocationID(restaurant.ID_location);
                RestaurantNPA.Add(location.NPA);
                RestaurantsCity.Add(location.City);

            }
            var person = PersonManager.GetPersonID(order.ID_person);
            var locationPerson = LocationManager.GetLocationID(person.ID_location);
            var deliveryOrder = DeliveryOrderListManager.GetDeliveryFromOrder(id);
            final.clientAdress = person.Address;
            final.clientCity = locationPerson.City;
            final.clientFirstName = person.FirstName;
            final.clientName = person.Name;
            final.clientTel = person.PhoneNumber;
            final.clientNPA = locationPerson.NPA;
            final.DishesName = DishesName;
            final.NumStatut = deliveryOrder.NumStatut;
            final.Quantity = Quantity;
            final.RestaurantAddress = RestaurantAddress;
            final.RestaurantName = RestaurantName;
            final.RestaurantNPA = RestaurantNPA;
            final.RestaurantsCity = RestaurantsCity;
            int total = 0;
            for(int i=0; i<Quantity.Count; i++)
            {
                int sousTotal = dishes[i].DishesPrice * Quantity[i];
                total += sousTotal;
            }
            final.clientPrixTotal = total;

            if (HttpContext.Session.GetInt32("IdOrder") != null)
                HttpContext.Session.Remove("IdOrder");

            HttpContext.Session.SetInt32("IdOrder", id);

            return View("Detail",final);
        }
        public ActionResult Begin()
        {
            int idOrder = (int)HttpContext.Session.GetInt32("IdOrder");
            var deliveryOrderList = DeliveryOrderListManager.GetDeliveryFromOrder(idOrder);
            deliveryOrderList.NumStatut = 2;
            DeliveryOrderListManager.ModifyStatut(deliveryOrderList);

            return Detail(idOrder);
        }
        public ActionResult Finish()
        {
            int idOrder = (int)HttpContext.Session.GetInt32("IdOrder");
            var deliveryOrderList = DeliveryOrderListManager.GetDeliveryFromOrder(idOrder);
            deliveryOrderList.NumStatut = 3;
            DeliveryOrderListManager.ModifyStatut(deliveryOrderList);

            return Index();
        }


    }
}
