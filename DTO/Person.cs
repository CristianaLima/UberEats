using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Person
    {
        public int ID_person { get; set; }

        public int ID_location { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string MailAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public int isRestaurant { get; set; }
        public string PasswordLogin { get; set; }
        public string PersonImage { get; set; }

        public override string ToString()
        {
            return  " ID_person " + ID_person +
                    " ID_location " + ID_location +
                    " Person Address " + Address +
                    " Person LastName " + Name +
                    " Person FirstName " + FirstName +
                    " Person MailAddress " + MailAddress + 
                    " Person BirthDate " + BirthDate +
                    " Person PhoneNumber " + PhoneNumber +
                    " is this a Restaurant ? " + isRestaurant +
                    " Person Image " + PersonImage;
        }
    }
}
