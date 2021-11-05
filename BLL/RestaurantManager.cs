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
    public class RestaurantManager : IRestaurantManager
    {
        private IRestaurantDB RestaurantDB { get; }
        private IDishesDB DishesDB { get; }
        private IRestaurantDishesDB RestaurantDishesDB { get; }
        private ILocationDB LocationDB { get; }

        public RestaurantManager(IConfiguration conf)
        {
            RestaurantDB = new RestaurantDB(conf);
            RestaurantDishesDB = new RestaurantDishesDB(conf);
            DishesDB = new DishesDB(conf);
            LocationDB = new LocationDB(conf);
        }

        public List<Restaurant> GetRestaurants()
        {
            return RestaurantDB.GetRestaurants();
        }

        public Restaurant GetRestaurant(string RestaurantName)
        {
            return RestaurantDB.GetRestaurant(RestaurantName);
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            return RestaurantDB.AddRestaurant(restaurant);
        }

        public Restaurant GetRestaurantID(int ID_Restaurant)
        {
            return RestaurantDB.GetRestaurantID(ID_Restaurant);
        }

        public Restaurant ChangeAvailabilityRestaurant(int ID_Restaurant, int IsRestaurantAvailable)
        {
            return RestaurantDB.ChangeAvailabilityRestaurant(ID_Restaurant, IsRestaurantAvailable);
        }

        public List<Restaurant> GetRestaurantIDLocation(int IdLocation)
        {
            return RestaurantDB.GetRestaurantIDLocation(IdLocation);
        }

        public List<Dishes> GetDishesFromRestaurant(string restaurantName)
        {
            //on a le nom du resto, on veut donc chercher l'ID du resto
            var restaurant = RestaurantDB.GetRestaurant(restaurantName);
            var restaurantID = restaurant.ID_restaurant;

            //on a l'ID du resto, on veut maintenant l'ID des Dishes 
            var restaurantDishes = RestaurantDishesDB.GetDishes(restaurantID);
            //on crée ensuite la variable de liste de dishes
            var dishes = new List<Dishes>();
            foreach (var m in restaurantDishes)
            {
                var dish = DishesDB.GetDishIP(m.ID_Dishes);
                dishes.Add(dish);
            }

            return dishes;
        }

        public Location GetLocationFromRestaurant(string restaurantName)
        {
            //on a le nom du resto, on veut donc chercher l'ID de la location
            var restaurantN = RestaurantDB.GetRestaurant(restaurantName);
            var locationID = restaurantN.ID_location;

            //on a l'id de la location, il reste qu'à get la location via l'ID

            var location = LocationDB.GetLocationID(locationID);

            return location;
        }

        public Restaurant ModifyAllRestaurant(Restaurant restaurant)
        {
            return RestaurantDB.ModifyAllRestaurant(restaurant);
        }
    }
}
