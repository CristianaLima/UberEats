using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDishesDB
    {
        List<Dishes> GetDishes();
        List<Dishes> GetDish(string DishName);
        Dishes GetDishIP(int ID_Dishes);
        Dishes AddDish(Dishes dish);
        Dishes ChangeAvailabilityDish(int ID_Dish, int isDishAvailable);
        Dishes MofifyAllDishes(Dishes dish);
    }
}
