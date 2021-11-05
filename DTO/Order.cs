using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Order
    {
        public int ID_Order { get; set; }
        public int ID_person { get; set; }
        
        public DateTime OrderDate { get; set; }
        public override string ToString()
        {
            return " ID_Order: " + ID_Order +
                    " ID_Person: " + ID_person +
                    " Date: " + OrderDate;
        }
    }
}
