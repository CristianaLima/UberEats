using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    //for all the persons need to see them orders
    public class StatusVM
    {
        public List<Order> orders { get; set; }
        public List<int> status { get; set; }

        public int deliveryStatut { get; set; }

    }
}
