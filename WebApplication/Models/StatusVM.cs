﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class StatusVM
    {
        public List<Order> orders { get; set; }
        public List<int> status { get; set; }

        public int deliveryStatut { get; set; }

    }
}
