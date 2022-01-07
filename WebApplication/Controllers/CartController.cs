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
            
            HttpContext.Session.Set<CartVM>("Cart", Cart);
            
            
            return View(Cart);
        }
        public ActionResult More(int id)
        {
            CartVM newCart = HttpContext.Session.Get<CartVM>("Cart");
            HttpContext.Session.Remove("Cart");
            int index = newCart.DishesId.IndexOf(id);
            newCart.Quantity[index] += 1;
            newCart.DishesTotalPrice[index] = newCart.DishesUnitePrice[index] * newCart.Quantity[index];
            int total = 0;
            foreach(int price in newCart.DishesTotalPrice)
            {
                total += price;
            }
            newCart.TotalPrice = total;
            HttpContext.Session.Set<CartVM>("Cart", newCart);


            return View("Index",newCart);
        }
        public ActionResult Less(int id)
        {
            
            CartVM newCart = HttpContext.Session.Get<CartVM>("Cart");
            HttpContext.Session.Remove("Cart");
            int index = newCart.DishesId.IndexOf(id);
            if(newCart.Quantity[index]-1 != 0)
            {
                newCart.Quantity[index] -= 1;
                newCart.DishesTotalPrice[index] = newCart.DishesUnitePrice[index] * newCart.Quantity[index];
                int total=0;
                foreach (int price in newCart.DishesTotalPrice)
                {
                    total += price;
                }
                newCart.TotalPrice = total;
            }
            

            HttpContext.Session.Set<CartVM>("Cart", newCart);


            return View("Index", newCart);
        }
        public ActionResult Remove(int id)
        {
            CartVM newCart = HttpContext.Session.Get<CartVM>("Cart");
            HttpContext.Session.Remove("Cart");
            int index = newCart.DishesId.IndexOf(id);
            newCart.DishesId.RemoveAt(index);
            newCart.DishesName.RemoveAt(index);
            newCart.DishesUnitePrice.RemoveAt(index);
            newCart.Quantity.RemoveAt(index);
            int dishTotal = newCart.DishesTotalPrice[index];
            int newTotal = newCart.TotalPrice - dishTotal;
            newCart.DishesTotalPrice.RemoveAt(index);
            newCart.TotalPrice = newTotal;

            HttpContext.Session.Set<CartVM>("Cart", newCart);


            return View("Index", newCart);
        }


    }
}
