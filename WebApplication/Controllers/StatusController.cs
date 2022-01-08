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
    public class StatusController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private IOrderManager OrderManager;
        private IDeliveryOrderListManager DeliveryOrderListManager;
        private IOrderDishesManager OrderDishesManager;
        private IDishesManager DishesManager;
        private IDeliveryManManager DeliveryManManager;

        public StatusController(ILogger<OrderController> logger, IOrderManager orderManager, IDeliveryOrderListManager deliveryOrderListManager, IOrderDishesManager orderDishesManager, IDishesManager dishesManager, IDeliveryManManager deliveryManManager)
        {
            _logger = logger;
            OrderManager = orderManager;
            DeliveryOrderListManager = deliveryOrderListManager;
            OrderDishesManager = orderDishesManager;
            DishesManager = dishesManager;
            DeliveryManManager = deliveryManManager;
        }

        // GET: StatusController
        public ActionResult Index()
        {
            //verifie que la person est bien connecte
            if (HttpContext.Session.GetInt32("IdPerson") == null)
                return RedirectToAction("Index", "Login");

            //va chercher son id
            int idPerson = (int) HttpContext.Session.GetInt32("IdPerson");
            //va chercher ses informations
            var listOrders = OrderManager.GetOrderIDPerson(idPerson);
            List<int> listNumStatut = new List<int>();
            StatusVM status = new StatusVM();
            //verifie si la personne a deja commande quelque chose
            if (listOrders != null)
            {
                foreach (var order in listOrders)
                {
                    var deliveryOrderList = DeliveryOrderListManager.GetDeliveryFromOrder(order.ID_Order);
                    listNumStatut.Add(deliveryOrderList.NumStatut);
                }
                
                status.orders = listOrders;
                status.status = listNumStatut;
            }
            


            return View("Index",status) ;
        }

        // GET: StatusController/Details/5
        public ActionResult Detail(int id)
        {
            OrderVM order = new OrderVM();
            order.IdOrder = id;
            //va chercher les orderDishes correspondants a l'id
            var orderDishes = OrderDishesManager.GetOrderDishes(id);
            List<string> DishesName = new List<string>();
            List<int> DishesId = new List<int>();
            List<int> DishesUnitePrice = new List<int>();
            List<int> DishesTotalPrice = new List<int>();
            List<int> Quantity = new List<int>();
            int TotalPrice = 0;

            //Dish
            foreach (var orderDish in orderDishes)
            {
                var dish = DishesManager.GetDishIP(orderDish.ID_Dishes);
                DishesName.Add(dish.DishesName);
                DishesId.Add(dish.ID_Dishes);
                DishesUnitePrice.Add(dish.DishesPrice);
                Quantity.Add(orderDish.Quantity);
                DishesTotalPrice.Add(dish.DishesPrice * orderDish.Quantity);
            }

            foreach(var disheTotal in DishesTotalPrice)
            {
                TotalPrice += disheTotal;
            }

            order.DishesName = DishesName;
            order.DishesId = DishesId;
            order.DishesUnitePrice = DishesUnitePrice;
            order.Quantity = Quantity;
            order.DishesTotalPrice = DishesTotalPrice;
            order.TotalPrice = TotalPrice;

            //DeliveryMan
            var deliveryOrderList = DeliveryOrderListManager.GetDeliveryFromOrder(id);
            var deliveryMan = DeliveryManManager.GetDeliveryManID(deliveryOrderList.Id_Delivery);
            order.DeliveryManName = deliveryMan.NameDelivery;
            order.DeliveryManTel = deliveryMan.PhoneNumberDelivery;

            //Order
            var ord = OrderManager.GetOrderIDOrder(id);
            order.DelaiLivraison = ord.DelaiLivraison;

            return View(order);
        }

        public ActionResult Remove(int id)
        {
            //va chercher le deliveryOrderList
            var deliveryOrderList = DeliveryOrderListManager.GetDeliveryFromOrder(id);
            //change le statut de la commande en annule
            deliveryOrderList.NumStatut = 0;
            DeliveryOrderListManager.ModifyStatut(deliveryOrderList);

            return Index();
        }

        
    }
}
