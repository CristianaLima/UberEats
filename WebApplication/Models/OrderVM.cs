using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class OrderVM
    {
        public List<string> DishesName { get; set; }
        public List<int> DishesId { get; set; }
        public List<int> DishesUnitePrice { get; set; }
        public List<int> DishesTotalPrice { get; set; }
        public List<int> Quantity { get; set; }
        public int TotalPrice { get; set; }

        public String Name { get; set; }
        public String FirstName { get; set; }
        public String PhoneNumber { get; set; }
        public String Address { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime DelaiLivraison { get; set; }
        public List<DateTime> ListPossibleDate { get; set; }

        public int NPA { get; set; }
        public String City { get; set; }
        public String Canton { get; set; }
    }
}
