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
    public class RestaurantManager
    {
        private IRestaurantDB RestaurantDB { get; }

        public RestaurantManager(IConfiguration conf)
        {
            RestaurantDB = new RestaurantDB(conf);
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
    }
}
