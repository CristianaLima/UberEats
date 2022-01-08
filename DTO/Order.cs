using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //To have all informations about a order
    public class Order
    {
        public int ID_Order { get; set; }
        public int ID_person { get; set; }
        public DateTime DelaiLivraison { get; set; }       
        public DateTime OrderDate { get; set; }

        //To write the informations of the order
        public override string ToString()
        {
            return " ID_Order: " + ID_Order +
                    " ID_Person: " + ID_person +
                    " Date: " + OrderDate +
                    " Délai Livraison : " + DelaiLivraison;
        }
    }
}
