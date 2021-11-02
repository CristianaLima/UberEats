using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Location
    {
        public int ID_location { get; set; }
        public int NPA { get; set; }
        public string City { get; set; }

        public string Canton { get; set; }

        public override string ToString()
        {
            return " ID_location: " + ID_location +
                    " NPA: " + NPA +
                    " City: " + City +
                    " Canton: " + Canton;
        }
    }
}
