using BLL;
using DAL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private IDishesManager DishesManager;
        private IPersonManager PersonManager;
        private IOrderManager OrderManager;
        private ILocationManager LocationManager;
        private IOrderDishesManager OrderDishesManager;

        public OrderController(ILogger<OrderController> logger, IDishesManager dishesManager, IPersonManager personManager, IOrderManager orderManager, ILocationManager locationManager, IOrderDishesManager orderDishesManager)
        {
            _logger = logger;
            DishesManager = dishesManager;
            PersonManager = personManager;
            OrderManager = orderManager;
            LocationManager = locationManager;
            OrderDishesManager = orderDishesManager;
    }
        public IActionResult Index()
        {
            // Login 
            if (HttpContext.Session.GetInt32("IdPerson") == null)
                return RedirectToAction("Index", "Login");

            // Cart
            OrderVM orderVM = new OrderVM();
            var cart = HttpContext.Session.Get<CartVM>("Cart");

            orderVM.DishesName = cart.DishesName;
            orderVM.DishesId = cart.DishesId;
            orderVM.DishesUnitePrice = cart.DishesUnitePrice;
            orderVM.Quantity = cart.Quantity;
            orderVM.DishesTotalPrice = cart.DishesTotalPrice;
            orderVM.TotalPrice = cart.TotalPrice;

            // Person
            int idPerson = (int)HttpContext.Session.GetInt32("IdPerson");
            Person person = (Person)PersonManager.GetPersonID(idPerson);
            orderVM.Name = person.Name;
            orderVM.FirstName = person.FirstName;
            orderVM.PhoneNumber = person.PhoneNumber;
            orderVM.Address = person.Address;

            // Order
            orderVM.OrderDate = DateTime.Now;
            List<DateTime> dateList = new List<DateTime>();
            for (int i = 1; i < 10; i++)
            {
                if (DateTime.Now.AddMinutes(15 * i).Hour < 23)
                {
                    dateList.Add(DateTime.Now.AddMinutes(15 * i));
                }
                else
                {
                    break;
                }
            }

            orderVM.ListPossibleDate = dateList;

            // Location
            int idLocationPerson = person.ID_location;
            Location location = LocationManager.GetLocationID(idLocationPerson);
            orderVM.Canton = location.Canton;
            orderVM.City = location.City;
            orderVM.NPA = location.NPA;

            HttpContext.Session.Set<OrderVM>("Order", orderVM);

            return View(orderVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(OrderVM orderVM)
        {
            var oldOrder = HttpContext.Session.Get<OrderVM>("Order");
            if (ModelState.IsValid)
            {
                var idLocation = LocationManager.GetLocationNPACity(orderVM.NPA, orderVM.City);
                if (idLocation == 0)
                {
                    ModelState.AddModelError("NPA","le NPA ou la ville est incorrect");
                    HttpContext.Session.Set<OrderVM>("Order", oldOrder);
                    return View(oldOrder);
                }
                var location = LocationManager.GetLocationID(idLocation);
                


                HttpContext.Session.Remove("Order");
                Order order = new Order();
                order.DelaiLivraison = orderVM.DelaiLivraison;
                order.ID_person = (int)HttpContext.Session.GetInt32("IdPerson");
                order.OrderDate = oldOrder.OrderDate;
                OrderManager.AddOrder(order);
                OrderDishes orderDishes = new OrderDishes();

                for(int i=0; i<oldOrder.DishesId.Count; i++)
                {
                    orderDishes.ID_Dishes = oldOrder.DishesId[i];
                    orderDishes.Quantity = oldOrder.Quantity[i];
                    orderDishes.ID_Order = order.ID_Order;
                    OrderDishesManager.AddOrderDishes(orderDishes);
                }


                if(OrderManager.AssignDeliveryMan(order) == null)
                {
                    ModelState.AddModelError("ListPossibleDate", "Aucun livreur n'est disponible pour le moment");
                    HttpContext.Session.Set<OrderVM>("Order", oldOrder);
                    return View(oldOrder);
                }
                //var deli = OrderManager.AssignDeliveryMan(order);

                return RedirectToAction("Index", "Status");

            }
            HttpContext.Session.Set<OrderVM>("Order", oldOrder);
            return View(oldOrder);
        }
    }
}
