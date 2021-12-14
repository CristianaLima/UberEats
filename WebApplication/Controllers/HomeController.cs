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

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("IdPerson") == null)
                return RedirectToAction("Index", "Login");
            List<RestaurantDishesVM> restaurantsDishes = new List<RestaurantDishesVM>();
            var restaurants = RestaurantManager.GetRestaurants();
            foreach(var restaurant in restaurants)
            {
                
                var dishes = RestaurantManager.GetDishesFromRestaurant(restaurant.RestaurantName);

                foreach(var dish in dishes)
                {
                    RestaurantDishesVM restaurantDishes = new RestaurantDishesVM();
                    restaurantDishes.RestaurantName = restaurant.RestaurantName;
                    restaurantDishes.RestaurantAddress = restaurant.RestaurantAddress;
                    restaurantDishes.RestaurantImage = restaurant.RestaurantImage;
                    restaurantDishes.DishesName = dish.DishesName;
                    restaurantDishes.DishesDescription = dish.DishesDescription;
                    restaurantDishes.DishesPrice = dish.DishesPrice;
                    restaurantDishes.DishImage = dish.DishImage;

                    restaurantsDishes.Add(restaurantDishes);
                }
            }

            return View(restaurantsDishes);
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
