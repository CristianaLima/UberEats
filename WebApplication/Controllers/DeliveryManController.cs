using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DeliveryManController : Controller
    {
        private IDeliveryManManager DeliveryManManager;
        private IDeliveryOrderListManager DeliveryOrderListManager;
        private IOrderManager OrderManager;
        private IOrderDishesManager OrderDishesManager;
        private IDishesManager DishesManager;
        private IRestaurantDishesManager RestaurantDishesManager;
        private IRestaurantManager RestaurantManager;
        private ILocationManager LocationManager;
        private IPersonManager PersonManager;

        public DeliveryManController(IDeliveryManManager deliveryManManager, IDeliveryOrderListManager deliveryOrderListManager, IOrderManager orderManager, IOrderDishesManager orderDishesManager, IDishesManager dishesManager, IRestaurantDishesManager restaurantDishesManager, IRestaurantManager restaurantManager, ILocationManager locationManager, IPersonManager personManager)
        {
            DeliveryManManager = deliveryManManager;
            DeliveryOrderListManager = deliveryOrderListManager;
            OrderManager = orderManager;
            OrderDishesManager = orderDishesManager;
            DishesManager = dishesManager;
            RestaurantDishesManager = restaurantDishesManager;
            RestaurantManager = restaurantManager;
            LocationManager = locationManager;
            PersonManager = personManager;
        }
        // GET: DeliveryManController
        public ActionResult Index()
        {
            //verifie que le livreur est bien connecte
            if (HttpContext.Session.GetInt32("IdDeliveryMan") == null)
            {
                    return RedirectToAction("Index", "Login");
            }
            //va chercher son id
            var id = (int) HttpContext.Session.GetInt32("IdDeliveryMan");
            //va chercher toutes ses informations
            var deliveryMan = DeliveryManManager.GetDeliveryManID(id);

            var statusVM = new StatusVM();
            statusVM.deliveryStatut = deliveryMan.IsWorking;
            //va chercher toute les deliveryOrderList lien a ce livreur
            var deliveryOrders = DeliveryOrderListManager.GetDeliveryOrderList(id);
            //regarde s'il a des commandes
            if (deliveryOrders != null) {
            List<Order> orders = new List<Order>();
            List<int> status = new List<int>();
            //prend toutes ses commandes est numero de statut
            foreach (var deliveryOrder in deliveryOrders)
            {
                var order = OrderManager.GetOrderIDOrder(deliveryOrder.ID_Order);
                orders.Add(order);
                status.Add(deliveryOrder.NumStatut);
            }
            statusVM.orders = orders;
            statusVM.status = status;
            }

            return View("Index",statusVM);
        }

        // GET: DeliveryManController/Details/5
        public ActionResult Detail(int id)
        {
            DeliveryOrderDetailVM final = new DeliveryOrderDetailVM();
            List<string> DishesName = new List<string>();
            List<int> Quantity = new List<int>();
            List<string> RestaurantName = new List<string>();
            List<string> RestaurantAddress = new List<string>();
            List<int> RestaurantNPA = new List<int>();
            List<string> RestaurantsCity = new List<string>();

            //va chercher la commande correspondante a l'id donne
            Order order = OrderManager.GetOrderIDOrder(id);
            //va chercher les orderDishes correspondantes
            var orderDishes = OrderDishesManager.GetOrderDishes(id);
            foreach(var orderDish in orderDishes)
            {
                var dish = DishesManager.GetDishIP(orderDish.ID_Dishes);
                Quantity.Add(orderDish.Quantity);
                DishesName.Add(dish.DishesName);

                var restaurantDish = RestaurantDishesManager.GetRestaurant(dish.ID_Dishes);
                var restaurant = RestaurantManager.GetRestaurantID(restaurantDish.ID_restaurant);
                RestaurantName.Add(restaurant.RestaurantName);
                RestaurantAddress.Add(restaurant.RestaurantAddress);

                var location = LocationManager.GetLocationID(restaurant.ID_location);
                RestaurantNPA.Add(location.NPA);
                RestaurantsCity.Add(location.City);

            }
            //va chercher la person
            var person = PersonManager.GetPersonID(order.ID_person);
            var locationPerson = LocationManager.GetLocationID(person.ID_location);
            var deliveryOrder = DeliveryOrderListManager.GetDeliveryFromOrder(id);

            //mes toutes les informations dans le model
            final.clientAdress = person.Address;
            final.clientCity = locationPerson.City;
            final.clientFirstName = person.FirstName;
            final.clientName = person.Name;
            final.clientTel = person.PhoneNumber;
            final.clientNPA = locationPerson.NPA;
            final.DishesName = DishesName;
            final.NumStatut = deliveryOrder.NumStatut;
            final.Quantity = Quantity;
            final.RestaurantAddress = RestaurantAddress;
            final.RestaurantName = RestaurantName;
            final.RestaurantNPA = RestaurantNPA;
            final.RestaurantsCity = RestaurantsCity;

            int total = 0;
            //va chercher les plats
            var dishes = OrderManager.GetDishesFromOrder(id);
            //va chercher le montant que doit le client
            for (int i=0; i<Quantity.Count; i++)
            {
                int sousTotal = dishes[i].DishesPrice * Quantity[i];
                total += sousTotal;
            }
            final.clientPrixTotal = total;

            //verifie qu'il n'y a pas de idOrder dans la session
            if (HttpContext.Session.GetInt32("IdOrder") != null)
                HttpContext.Session.Remove("IdOrder");

            //ajoute idOrder dans la session
            HttpContext.Session.SetInt32("IdOrder", id);

            return View("Detail",final);
        }
        public ActionResult Begin()
        {
            //va chercher l'id de la commande
            int idOrder = (int)HttpContext.Session.GetInt32("IdOrder");
            var deliveryOrderList = DeliveryOrderListManager.GetDeliveryFromOrder(idOrder);
            //change le statut de la commande
            deliveryOrderList.NumStatut = 2;
            DeliveryOrderListManager.ModifyStatut(deliveryOrderList);

            return Detail(idOrder);
        }
        public ActionResult Finish()
        {
            //va chercher l'id de la commande
            int idOrder = (int)HttpContext.Session.GetInt32("IdOrder");
            var deliveryOrderList = DeliveryOrderListManager.GetDeliveryFromOrder(idOrder);
            //change le statut de la commande
            deliveryOrderList.NumStatut = 3;
            DeliveryOrderListManager.ModifyStatut(deliveryOrderList);

            return Index();
        }
        public ActionResult Active()
        {
            //va chercher l'id du livreur
            int id = (int)HttpContext.Session.GetInt32("IdDeliveryMan");
            //va changer son statut de travail
            DeliveryManManager.ChangeIsWorking(id, 1);

            return Index();
        }
        public ActionResult Desactive()
        {
            //va chercher l'id du livreur
            int id = (int)HttpContext.Session.GetInt32("IdDeliveryMan");
            //va changer son statut de travail
            DeliveryManManager.ChangeIsWorking(id,0);

            return Index();
        }


    }
}
