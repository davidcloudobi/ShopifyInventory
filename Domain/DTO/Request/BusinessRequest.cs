using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Request
{
   public class BusinessRequest
    {
        [Required(ErrorMessage = "Business Name must not be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Contact Name of user must not be empty")]
        public string ContactName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "Email must not be empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password must not be empty")]
        public string Password { get; set; }
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Required(ErrorMessage = "Phone number must not be empty")]
        public string Phone { get; set; }
        public string Website { get; set; }
        [Url(ErrorMessage = "Invalid Url")]
        // [Required(ErrorMessage = "LogoUrl must not be empty")]
        public string LogoUrl { get; set; }

        [Required(ErrorMessage = "Business Type Name must not be empty")]
        public string BusinessTypeName { get; set; }    

    }
}
