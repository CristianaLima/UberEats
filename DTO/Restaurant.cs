using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Restaurant
    {
        public int ID_restaurant { get; set; }
        public int ID_location { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantImage { get; set; }

        public override string ToString()
        {
            return  " ID_Restaurant " + ID_restaurant +
                    " ID_Location " + ID_location +
                    " Restaurant Name " + RestaurantName +
                    " Restaurant Address " + RestaurantAddress +
                    " Restaurant Image " + RestaurantImage;
        }
    }
}
