using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IRestaurantManager
    {
        Restaurant AddRestaurant(Restaurant restaurant);
        Restaurant ChangeAvailabilityRestaurant(int ID_Restaurant, int IsRestaurantAvailable);
        List<Dishes> GetDishesFromRestaurant(string restaurantName);
        Location GetLocationFromRestaurant(string restaurantName);
        Restaurant GetRestaurant(string RestaurantName);
        Restaurant GetRestaurantID(int ID_Restaurant);
        List<Restaurant> GetRestaurantIDLocation(int IdLocation);
        List<Restaurant> GetRestaurants();
        Restaurant ModifyAllRestaurant(Restaurant restaurant);
    }
}