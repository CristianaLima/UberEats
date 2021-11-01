using System;
using System.IO;
using BLL;
using Microsoft.Extensions.Configuration;
using DTO;


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
            // Test de lire une liste
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
            //DishesManager.ChangeAvailabilityDish(5, 0);


        }
    }
}
