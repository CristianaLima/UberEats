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
            int quant = 1;
            OrderVM orderVM = new OrderVM();
            var IdDishesList = HttpContext.Session.Get<List<int>>("listIdDishes");
            if (IdDishesList == null)
            {
                return View();
            }

            List<String> namesDishes = null;
            List<int> DishesUnitePrice = null;
            List<int> DishesTotalPrice = null;
            List<int> Quantity = null;
            int Total = 0;

            foreach (var IdDish in IdDishesList)
            {
                if (namesDishes == null)
                {
                    namesDishes = new List<string>();
                    DishesUnitePrice = new List<int>();
                    DishesTotalPrice = new List<int>();
                    Quantity = new List<int>();
                }
                var dish = DishesManager.GetDishIP(IdDish);
                namesDishes.Add(dish.DishesName);
                DishesUnitePrice.Add(dish.DishesPrice);
                Quantity.Add(quant);
                DishesTotalPrice.Add(dish.DishesPrice * quant);

            }
            foreach (var totalPrice in DishesTotalPrice)
            {
                Total += totalPrice;
            }
            orderVM.DishesName = namesDishes;
            orderVM.DishesId = IdDishesList;
            orderVM.DishesUnitePrice = DishesUnitePrice;
            orderVM.Quantity = Quantity;
            orderVM.DishesTotalPrice = DishesTotalPrice;
            orderVM.TotalPrice = Total;

            // Person
            int idPerson = (int)HttpContext.Session.GetInt32("IdPerson");
            Person person = (Person)PersonManager.GetPersonID(idPerson);
            orderVM.Name = person.Name;
            orderVM.FirstName = person.FirstName;
            orderVM.MailAddress = person.MailAddress;
            orderVM.PhoneNumber = person.PhoneNumber;
            orderVM.Address = person.Address;

            // Order
            List<DateTime> dateList = new List<DateTime>();
            for(int i = 1; i < 10; i++)
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

        public IActionResult Index(OrderVM orderVM)
        {

        }
    }
}
