using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class RestaurantDishesVM
    {
        public string RestaurantName { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantImage { get; set; }

        public List<string> DishesName { get; set; }
        public List<int> DishesId { get; set; }
        public List<string> DishesDescription { get; set; }
        public List<int> DishesPrice { get; set; }
        public List<string> DishImage { get; set; }
    }
}
