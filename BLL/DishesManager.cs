using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DishesManager
    {
        private IDishesDB DishesDB { get; }
        private IRestaurantDishesDB RestaurantDishesDB { get; }
        private IRestaurantDB restaurantDB { get; }
        public DishesManager(IConfiguration conf)
        {
            DishesDB = new DishesDB(conf);
            RestaurantDishesDB = new RestaurantDishesDB(conf);
            restaurantDB = new RestaurantDB(conf);
        }

        public List<Dishes> GetDishes()
        {
            return DishesDB.GetDishes();
        }

        public Dishes GetDish(string DishName)
        {
            return DishesDB.GetDish(DishName);
        }

        public Dishes AddDish(Dishes dish)
        {
            return DishesDB.AddDish(dish);
        }

            public Dishes GetDishIP(int ID_Dishes)
        {
            return DishesDB.GetDishIP(ID_Dishes);
        }

        public Dishes ChangeAvailabilityDish(int ID_Dish, int isDishAvailable)
        {
            return DishesDB.ChangeAvailabilityDish(ID_Dish, isDishAvailable);
        }

        public List<Restaurant> GetRestaurantFromDish(string DishName)
        {
            
            Dishes dish = DishesDB.GetDish(DishName);
            var idDish = dish.ID_Dishes;
            var restaurantDishes = RestaurantDishesDB.GetRestaurant(idDish);
            var restaurants = new List<Restaurant>();

            foreach (var m in restaurantDishes)
            {
                var idRestaurant = m.ID_restaurant;
                Restaurant restaurant = restaurantDB.GetRestaurantID(idRestaurant);
                restaurants.Add(restaurant);
            }
            
            return restaurants;
        }
    }
}
