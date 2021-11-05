using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRestaurantDB
    {
        List<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(string RestaurantName);
        Restaurant GetRestaurantID(int ID_Restaurant);
        Restaurant AddRestaurant(Restaurant restaurant);
        Restaurant ChangeAvailabilityRestaurant(int ID_Restaurant, int isRestaurantAvailable);
        List<Restaurant> GetRestaurantIDLocation(int IdLocation);
        Restaurant ModifyAllRestaurant(Restaurant restaurant);
    }
}
