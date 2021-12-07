using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IPersonManager PersonManager;
        private IDishesManager DishesManager;
        private IRestaurantManager RestaurantManager;

        public HomeController(ILogger<HomeController> logger, IPersonManager personManager, IDishesManager dishesManager, IRestaurantManager restaurantManager)
        {
            _logger = logger;
            PersonManager = personManager;
            DishesManager = dishesManager;
            RestaurantManager = restaurantManager;
        }

        public IActionResult Index(RestaurantDishesVM restaurantDishesVM)
        {
            if (HttpContext.Session.GetInt32("IdPerson") == null)
                return RedirectToAction("Index", "Login");
            var dishes = DishesManager.GetDishes();
            var restaurants = RestaurantManager.GetRestaurants();
            return View(restaurantDishesVM);
        }
       

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetInt32("IdPerson") == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
