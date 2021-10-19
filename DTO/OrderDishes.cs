using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDishes
    {
        public int ID_Order { get; set; }
        public int ID_Dishes { get; set; }
        public int Quantity { get; set; }
    }
}
