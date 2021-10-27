using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Dishes
    {
        public int ID_Dishes { get; set; }
        public string DishesName { get; set; }
        public string DishesDescription { get; set; }
        public int DishesPrice { get; set; }
        public string DishImage { get; set; }
        public int isDishAvailable { get; set; }

        public override string ToString()
        {
            return " ID_Dishes: " + ID_Dishes +
                    " Name: " + DishesName +
                    " Description: " + DishesDescription +
                    " Price: " + DishesPrice +
                    " Image: " + DishImage +
                    " Available: " + isDishAvailable;
        }
    }
}
