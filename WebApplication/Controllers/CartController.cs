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
            //verifie que la personne est connecte
            if (HttpContext.Session.GetInt32("IdPerson") == null)
                return RedirectToAction("Index", "Login");

            //initialise la quantite a 1
            int quant = 1;
            CartVM Cart = new CartVM();
            //va chercher la list de plats que la personne a decide de prendre
            var IdDishesList = HttpContext.Session.Get<List<int>>("listIdDishes");
            //si la personne n'a rien pris comme plat
            if (IdDishesList == null)
            {
                return View();
            }

            //Plats
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

            //pour avoir le prix total de la commande
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
            
            //on garde en memoir ce panier pour les prochaines modifications
            HttpContext.Session.Set<CartVM>("Cart", Cart);
            
            
            return View(Cart);
        }

        public ActionResult More(int id)
        {
            //var chercher le panier
            CartVM newCart = HttpContext.Session.Get<CartVM>("Cart");
            HttpContext.Session.Remove("Cart");
            //va chercher ou se trouve le plat a modifie dans la liste
            int index = newCart.DishesId.IndexOf(id);
            //augmente la quantite de 1
            newCart.Quantity[index] += 1;
            //recalcule le prix total du plat
            newCart.DishesTotalPrice[index] = newCart.DishesUnitePrice[index] * newCart.Quantity[index];
            int total = 0;
            //recalcule le prix total
            foreach(int price in newCart.DishesTotalPrice)
            {
                total += price;
            }
            newCart.TotalPrice = total;
            //met le nouveau panier dans la session
            HttpContext.Session.Set<CartVM>("Cart", newCart);


            return View("Index",newCart);
        }
        public ActionResult Less(int id)
        {
            //var chercher le panier
            CartVM newCart = HttpContext.Session.Get<CartVM>("Cart");
            HttpContext.Session.Remove("Cart");
            //va chercher ou se trouve le plat a modifie dans la liste
            int index = newCart.DishesId.IndexOf(id);
            //ne laisse pas aller plus bas que 1 au niveau des quantite
            if(newCart.Quantity[index]-1 != 0)
            {
                //soustre la quantite de 1
                newCart.Quantity[index] -= 1;
                //recalcule le prix total du plat
                newCart.DishesTotalPrice[index] = newCart.DishesUnitePrice[index] * newCart.Quantity[index];
                int total=0;
                //recalcule le prix total
                foreach (int price in newCart.DishesTotalPrice)
                {
                    total += price;
                }
                newCart.TotalPrice = total;
            }

            //met le nouveau panier dans la session
            HttpContext.Session.Set<CartVM>("Cart", newCart);


            return View("Index", newCart);
        }
        public ActionResult Remove(int id)
        {
            //var chercher le panier
            CartVM newCart = HttpContext.Session.Get<CartVM>("Cart");
            HttpContext.Session.Remove("Cart");
            //va chercher ou se trouve le plat a modifie dans la liste
            int index = newCart.DishesId.IndexOf(id);
            //le supprime du panier
            newCart.DishesId.RemoveAt(index);
            newCart.DishesName.RemoveAt(index);
            newCart.DishesUnitePrice.RemoveAt(index);
            newCart.Quantity.RemoveAt(index);
            int dishTotal = newCart.DishesTotalPrice[index];
            //recalcule le prix total
            int newTotal = newCart.TotalPrice - dishTotal;
            newCart.DishesTotalPrice.RemoveAt(index);
            newCart.TotalPrice = newTotal;

            //met le nouveau panier dans la session
            HttpContext.Session.Set<CartVM>("Cart", newCart);


            return View("Index", newCart);
        }


    }
}
