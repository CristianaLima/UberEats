using System;
using System.IO;
using BLL;
using Microsoft.Extensions.Configuration;
using DTO;
using System.Collections.Generic;

namespace UberEats
{
    class Program
    {

        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        static void Main(string[] args)
        {
            /* // Test de lire une liste
             Console.WriteLine("Exercise List of all worklocations");
             var workLocationManager = new WorkLocationManager(Configuration);
             var workLocations = workLocationManager.GetWorkLocations();

             foreach (var m in workLocations)
             {
                 Console.WriteLine(m.ToString());
             }

             // Test de lire une id
             Console.WriteLine(workLocationManager.GetWorkLocationID(1));

             // Exercise Add 
             //var newRestaurant = RestaurantManager.AddRestaurant(new Restaurant { ID_restaurant = 4, ID_location = 1 , RestaurantName = "3 Couronnes", RestaurantAddress = "Rue des Riches 66", RestaurantImage = "/moula/gucci/gang", IsRestaurantAvailable = 1 });

             // Test modifier une ligne
             //DishesManager.ChangeAvailabilityDish(5, 0);*/

            var OrderManager = new OrderManager(Configuration);
            var OrderDishesManager = new OrderDishesManager(Configuration);
            /*var ordersDishes = orderDishesManager.GetOrderDishes(2);

            foreach(var m in ordersDishes)
            {
                Console.WriteLine(m.ToString());
            }*/
            //var newOrderDishes = DishesManager.AddDish(new Dishes { DishesDescription = "La pizza classique", DishesName = "Margarita", DishesPrice = 15, DishImage = "image", isDishAvailable = 1 }) ;

            //Console.WriteLine(OrderManager.AddOrder(new Order { DelaiLivraison = DateTime.Now.AddMinutes(45), ID_person = 1, ID_Order = 2}));

            /*var newList = RestaurantManager.GetDishesFromRestaurant("Tservetta");
            foreach (var m in newList)
            {
                Console.WriteLine(m.ToString());
            }*/

            List<Order> orders = OrderManager.GetOrders();

            foreach (var m in orders)
            {
                Console.WriteLine(m.ToString());
            }
            //Order order = new Order { ID_Order = 5, ID_person = 1, DelaiLivraison = DateTime.Now.AddMinutes(45) };
            // OrderManager.AddOrder(order);

            //OrderDishes orderdish = new OrderDishes { ID_Dishes = 1, ID_Order = 5, Quantity = 10 };
            //           // Ne add pas dans la table
            // OrderDishesManager.AddOrderDishes(orderdish);

            //OrderManager.AssignDeliveryMan( OrderManager.GetOrderIDOrder(5));

            //var DeliveryManage = new DeliveryManManager(Configuration);
            //List<DeliveryMan> deliveryMen = DeliveryManage.GetDeliveryMen();

            var DeliveryOrderList = new DeliveryOrderListManager(Configuration);

            DeliveryOrderList.AddDeliveryOrderList(new DeliveryOrderList { Id_Delivery = 1, ID_Order = 5, NumStatut = 3 });
        }
    }
}
