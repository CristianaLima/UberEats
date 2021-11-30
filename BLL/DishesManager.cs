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
    public class DishesManager : IDishesManager
    {
        private IDishesDB DishesDB { get; }
        private IRestaurantDishesDB RestaurantDishesDB { get; }
        private IRestaurantDB RestaurantDB { get; }
        public DishesManager(IDishesDB dishesDB, IRestaurantDishesDB restaurantDishesDB, IRestaurantDB restaurantDB)
        {
            DishesDB = dishesDB;
            RestaurantDishesDB = restaurantDishesDB;
            RestaurantDB = restaurantDB;
        }

        public List<Dishes> GetDishes()
        {
            return DishesDB.GetDishes();
        }

        public List<Dishes> GetDish(string DishName)
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

            List<Dishes> dishes = DishesDB.GetDish(DishName);
            var restaurants = new List<Restaurant>();
            foreach (var m in dishes)
            {
                var idDish = m.ID_Dishes;
                var restaurantDishes = RestaurantDishesDB.GetRestaurant(idDish);
                var idRestaurant = restaurantDishes.ID_restaurant;
                Restaurant restaurant = RestaurantDB.GetRestaurantID(idRestaurant);
                restaurants.Add(restaurant);
            }

            return restaurants;
        }

        public Dishes MofifyAllDishes(Dishes dish)
        {
            return DishesDB.MofifyAllDishes(dish);
        }
    }
}
