using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //To have the location where a person live or where a restaurant is
    public class Location
    {
        public int ID_location { get; set; }
        public int NPA { get; set; }
        public string City { get; set; }

        public string Canton { get; set; }

        //To write the informations of the location
        public override string ToString()
        {
            return " ID_location: " + ID_location +
                    " NPA: " + NPA +
                    " City: " + City +
                    " Canton: " + Canton;
        }
    }
}
