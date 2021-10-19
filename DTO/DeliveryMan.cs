using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DeliveryMan
    {
        public int Id_Delivery { get; set; }

        public int ID_workLocation { get; set; }

        public int Wor_ID_workLocation { get; set; }
        public string NameDelivery { get; set; }
        public string FirstNameDelivery { get; set; }
        public string AdressDelivery { get; set; }
        public DateTime BirthDateDelivery { get; set; }
        public string PhoneNumberDelivery { get; set; }
        public string UsernameLoginDelivery { get; set; }
        public string PasswordDelivery { get; set; }
        public string ImageDelivery { get; set; }
        public string EmailDelivery { get; set; }
    }
}
