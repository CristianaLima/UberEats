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
    public class RestaurantDishesManager : IRestaurantDishesManager
    {
        private IRestaurantDishesDB RestaurantDishesDB { get; }

        public RestaurantDishesManager(IRestaurantDishesDB restaurantDishesDB)
        {
            RestaurantDishesDB = restaurantDishesDB;
        }

        public List<RestaurantDishes> GetDishes(int ID_restaurant)
        {
            return RestaurantDishesDB.GetDishes(ID_restaurant);
        }

        public RestaurantDishes GetRestaurant(int ID_dish)
        {
            return RestaurantDishesDB.GetRestaurant(ID_dish);
        }

        public RestaurantDishes AddRestaurantDishes(RestaurantDishes restaurantDishes)
        {
            return RestaurantDishesDB.AddRestaurantDishes(restaurantDishes);
        }
    }
}
