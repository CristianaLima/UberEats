using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //To link the restaurant with its dishes
    public class RestaurantDishes
    {
        public int ID_Dishes { get; set; }
        public int ID_restaurant { get; set; }

        //To write the informations of the RestaurantDishes
        public override string ToString()
        {
            return  " ID_Dishes " + ID_Dishes +
                    " ID_Restaurant " + ID_restaurant;
        }
    }
}
