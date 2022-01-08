using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //To link a deliveryman to him/her orders
    public class DeliveryOrderList
    {
        public int ID_Order { get; set; }

        public int Id_Delivery { get; set; }

        public int NumStatut { get; set; }

        //To write the informations of the deliveryOrderList
        public override string ToString()
        {
            return " ID_Order: " + ID_Order +
                    " ID_Delivery: " + Id_Delivery +
                    " NumStatut: " + NumStatut;
        }
    }
}
