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

        public OrderController(ILogger<OrderController> logger, IDishesManager dishesManager, IPersonManager personManager, IOrderManager orderManager, ILocationManager locationManager)
        {
            _logger = logger;
            DishesManager = dishesManager;
            PersonManager = personManager;
            OrderManager = orderManager;
            LocationManager = locationManager;
    }
        public IActionResult Index()
        {
            // Login 
            if (HttpContext.Session.GetInt32("IdPerson") == null)
                return RedirectToAction("Index", "Login");

            // Cart
            OrderVM orderVM = new OrderVM();
            var Cart = HttpContext.Session.Get<CartVM>("Cart");
            orderVM.DishesName = Cart.DishesName;
            orderVM.DishesId = Cart.DishesId;
            orderVM.DishesUnitePrice = Cart.DishesUnitePrice;
            orderVM.Quantity = Cart.Quantity;
            orderVM.DishesTotalPrice = Cart.DishesTotalPrice;
            orderVM.TotalPrice = Cart.TotalPrice;

            // Person
            int idPerson = (int) HttpContext.Session.GetInt32("IdPerson");
            Person person = PersonManager.GetPersonID(idPerson);
            orderVM.Name = person.Name;
            orderVM.FirstName = person.FirstName;
            orderVM.PhoneNumber = person.PhoneNumber;
            orderVM.Address = person.Address;

            // Order
            List<DateTime> dateList = new List<DateTime>();
            for(int i = 1; i < 11; i++)
            {
                if(DateTime.Now.AddMinutes(15*i).Hour < 23)
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

            return View(orderVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(OrderVM orderVM)
        {
            return View(orderVM);
        }
    }
}
