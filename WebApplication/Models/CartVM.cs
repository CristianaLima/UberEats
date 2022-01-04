using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class CartVM
    {
        public List<string> DishesName { get; set; }
        public List<int> DishesId { get; set; }
        public List<int> DishesUnitePrice { get; set; }
        public List<int> DishesTotalPrice { get; set; }
        public List<int> Quantity { get; set; }
        public int TotalPrice { get; set; }
    }
}
