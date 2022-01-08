﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //To link a order with its dishes
    public class OrderDishes
    {
        public int ID_Order { get; set; }
        public int ID_Dishes { get; set; }
        public int Quantity { get; set; }

        //To write the informations of the orderDishes
        public override string ToString()
        {
            return " ID_Order: " + ID_Order +
                    " ID_Dishes: " + ID_Dishes +
                    " Quantity: " + Quantity;
        }
    }
}
