using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class RestaurantDishesVM
    {
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantImage { get; set; }

        public string DishesName { get; set; }
        public string DishesDescription { get; set; }
        public int DishesPrice { get; set; }
        public string DishImage { get; set; }
    }
}
