using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class AccountVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string PhoneNumber { get; set; }



        [Required]
        public string City { get; set; }
        [Required]
        public int NPA { get; set; }
        [Required]
        public string WorkCity { get; set; }
        [Required]
        public int WorkNPA { get; set; }

    }
}
