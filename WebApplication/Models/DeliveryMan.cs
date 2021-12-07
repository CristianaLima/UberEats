using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class DeliveryMan
    {
        public int Id_Delivery { get; set; }
        [Required]

        public int ID_Location { get; set; }
        [Required]
        public int ID_workLocation { get; set; }

        public string NameDelivery { get; set; }
        [Required]
        public string FirstNameDelivery { get; set; }
        [Required]
        public string AddressDelivery { get; set; }
        [Required]
        public DateTime BirthDateDelivery { get; set; }
        [Required]
        public string PhoneNumberDelivery { get; set; }
        [Required]
        public string UsernameLoginDelivery { get; set; }
        [Required]
        public string PasswordDelivery { get; set; }
        [Required]
        public string ImageDelivery { get; set; }
        public string EmailDelivery { get; set; }
        [EmailAddress]
        [Required]

        public int IsWorking { get; set; }

        public int nbDeliveries { get; set; }
    }
}
