using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IRestaurantDishesManager
    {
        RestaurantDishes AddRestaurantDishes(RestaurantDishes restaurantDishes);
        List<RestaurantDishes> GetDishes(int ID_restaurant);
        RestaurantDishes GetRestaurant(int ID_dish);
    }
}