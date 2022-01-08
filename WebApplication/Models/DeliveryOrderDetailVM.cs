using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    //To have all informations that the deliveryman can delivery the order
    public class DeliveryOrderDetailVM
    {
        public List<string> DishesName { get; set; }
        public List<int> Quantity { get; set; }


        public List<string> RestaurantName { get; set; }
        public List<string> RestaurantAddress { get; set; }
        public List<int> RestaurantNPA { get; set; }
        public List<string> RestaurantsCity { get; set; }

        public int  NumStatut { get; set; }
        public string clientName { get; set; }
        public string clientFirstName { get; set; }
        public string clientAdress { get; set; }
        public int clientNPA { get; set; }
        public string clientCity { get; set; }
        public string clientTel { get; set; }
        public int clientPrixTotal { get; set; }


    }
}
