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

            return View(statusVM);
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

            return View(final);
        }

        // GET: DeliveryManController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryManController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeliveryManController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeliveryManController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeliveryManController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeliveryManController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
