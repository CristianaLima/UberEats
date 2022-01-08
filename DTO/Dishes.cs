using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //To have all informations about a dish
    public class Dishes
    {
        public int ID_Dishes { get; set; }
        public string DishesName { get; set; }
        public string DishesDescription { get; set; }
        public int DishesPrice { get; set; }
        public string DishImage { get; set; }
        public int isDishAvailable { get; set; }

        //To write the informations of the dish
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
