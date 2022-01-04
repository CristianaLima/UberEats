using BLL;
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
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private IDishesManager DishesManager;

        public CartController(ILogger<CartController> logger, IDishesManager dishesManager)
        {
            _logger = logger;
            DishesManager = dishesManager;
        }
        // GET: CartController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("IdPerson") == null)
                return RedirectToAction("Index", "Login");

            int quant = 1;
            CartVM Cart = new CartVM();
            var IdDishesList = HttpContext.Session.Get<List<int>>("listIdDishes");
            if (IdDishesList == null)
            {
                return View();
            }

            List<String> namesDishes = null;
            List<int> DishesUnitePrice = null;
            List<int> DishesTotalPrice = null;
            List<int> Quantity = null;
            int Total=0;

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
            Cart.DishesName = namesDishes;
            Cart.DishesId = IdDishesList;
            Cart.DishesUnitePrice = DishesUnitePrice;
            Cart.Quantity = Quantity;
            Cart.DishesTotalPrice = DishesTotalPrice;
            Cart.TotalPrice = Total;

            
            
            return View(Cart);
        }

       
    }
}
