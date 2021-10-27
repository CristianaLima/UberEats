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
            Console.WriteLine("Exercise List of all dishes");
            var DishesManager = new DishesManager(Configuration);
            var dishes = DishesManager.GetDishes();

            foreach (var m in dishes)
            {
                Console.WriteLine(m.ToString());
            }

            // Test de lire une id
            Console.WriteLine(DishesManager.GetDishIP(1));

            // Exercise Add dish
            // var newDish = DishesManager.AddDish(new Dishes { ID_Dishes = 5, DishesDescription = "Pizza ANANAS MERGUEZ", DishesName = "Covid", DishesPrice = 18, DishImage = "/moche/pasDeGout/merguez", isDishAvailable = 1 });

            // Test modifier une ligne
            //DishesManager.ChangeAvailabilityDish(5, 0);


        }
    }
}
