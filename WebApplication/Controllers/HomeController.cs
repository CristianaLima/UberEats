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
                RestaurantDishesVM restaurantDishes = new RestaurantDishesVM();
                restaurantDishes.RestaurantName = restaurant.RestaurantName;
                restaurantDishes.RestaurantAddress = restaurant.RestaurantAddress;
                restaurantDishes.RestaurantImage = restaurant.RestaurantImage;
                restaurantDishes.RestaurantId = restaurant.ID_restaurant;

                List<String> dishName = null;
                List<String> dishDescription = null;
                List<int> dishPrice = null;
                List<String> dishImage = null;
                List<int> dishId = null;
                foreach (var dish in dishes)
                {
                    if (dish.isDishAvailable == 1)
                    {


                        if (dishDescription == null)
                        {
                            dishName = new List<string>();
                            dishDescription = new List<string>();
                            dishPrice = new List<int>();
                            dishImage = new List<string>();
                            dishId = new List<int>();
                        }



                        dishName.Add(dish.DishesName);
                        dishDescription.Add(dish.DishesDescription);
                        dishPrice.Add(dish.DishesPrice);
                        dishImage.Add(dish.DishImage);
                        dishId.Add(dish.ID_Dishes);

                    } 
                }
                restaurantDishes.DishesName = dishName;
                restaurantDishes.DishesDescription = dishDescription;
                restaurantDishes.DishesPrice = dishPrice;
                restaurantDishes.DishImage = dishImage;
                restaurantDishes.DishesId = dishId;

                restaurantsDishes.Add(restaurantDishes);
            }

            return View(restaurantsDishes);
        }
       

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetInt32("IdPerson") == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

     
        public IActionResult Choice(int id)
        {
            if (HttpContext.Session.GetInt32("IdPerson") == null)
                return RedirectToAction("Index", "Login");

            List<int> idDishes = new List<int>();
            if ( HttpContext.Session.Get<List<int>>("listIdDishes")==null)
            {               
                idDishes.Add(id);
                HttpContext.Session.Set<List<int>>("listIdDishes",idDishes);
            }
            else
            {
                idDishes = HttpContext.Session.Get<List<int>>("listIdDishes");
                idDishes.Add(id);
                HttpContext.Session.Remove("listIdDishes");
                HttpContext.Session.Set<List<int>>("listIdDishes", idDishes);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Dishes(int id)
        {
            if (HttpContext.Session.GetInt32("IdPerson") == null)
                return RedirectToAction("Index", "Login");

            var dish = DishesManager.GetDishIP(id);
            return View(dish);
        }

       
    }
}
