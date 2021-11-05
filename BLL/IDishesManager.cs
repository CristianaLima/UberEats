using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IDishesManager
    {
        Dishes AddDish(Dishes dish);
        Dishes ChangeAvailabilityDish(int ID_Dish, int isDishAvailable);
        List<Dishes> GetDish(string DishName);
        List<Dishes> GetDishes();
        Dishes GetDishIP(int ID_Dishes);
        List<Restaurant> GetRestaurantFromDish(string DishName);
        Dishes MofifyAllDishes(Dishes dish);
    }
}