using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
   public class Customer : ModelBaseClass
    {
        public Customer()
        {
           Businesses = new HashSet<Business>();
            Sells = new HashSet<Sell>();
        }

        [Required(ErrorMessage = "FirstName must not be empty")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName must not be empty")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid EmailAddress")]
        [Required(ErrorMessage = "Email must not be empty")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid Phone number")]
        [Required(ErrorMessage = "Phone must not be empty")]
        public string Phone { get; set; }
        public ICollection<Sell> Sells { get; set; }
        public ICollection<Business> Businesses { get; set; }

    }

}
