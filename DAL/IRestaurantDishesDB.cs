
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRestaurantDishesDB
    {

        RestaurantDishes GetRestaurant(int ID_Dish);
        RestaurantDishes GetDishes(int ID_restaurant);
        RestaurantDishes AddRestaurantDishes(RestaurantDishes restaurantDishes);
    }
}
