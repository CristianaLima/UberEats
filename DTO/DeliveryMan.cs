using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //To have all informations about a deliveryman
    public class DeliveryMan
    {
        public int Id_Delivery { get; set; }

        public int ID_Location { get; set; }

        public int ID_workLocation { get; set; }
        public string NameDelivery { get; set; }
        public string FirstNameDelivery { get; set; }
        public string AddressDelivery { get; set; }
        public DateTime BirthDateDelivery { get; set; }
        public string PhoneNumberDelivery { get; set; }
        public string PasswordDelivery { get; set; }
        public string ImageDelivery { get; set; }
        public string EmailDelivery { get; set; }

        public int IsWorking { get; set; }

        public int nbDeliveries { get; set; }

        //To write the informations of the deliveryman
        public override string ToString()
        {
            return " IdUser: " + Id_Delivery +
                   " LastName: " + NameDelivery +
                   " Firsname: " + FirstNameDelivery +
                   " IdLocation: " + ID_Location +
                   " Address: " + AddressDelivery +
                   " IdWorkLocation: " + ID_workLocation +
                   " Birthday: " + BirthDateDelivery +
                   " PhoneNumber: " + PhoneNumberDelivery +
                   " Email: " + EmailDelivery +
                   " Image: " + ImageDelivery +
                   " Is working ?: " + IsWorking +
                   " nb Deliveries : " + nbDeliveries;
                
        }
    }
}
