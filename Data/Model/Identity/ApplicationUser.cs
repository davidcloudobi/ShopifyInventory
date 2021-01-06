using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Data.Model.Identity
{
   public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            //Sells = new HashSet<Sell>();
            Outlets = new HashSet<Outlet>();
        }

        [Required(ErrorMessage = "Full name must not be empty")]
        public string FullName { get; set; }
        public string PictureURL { get; set; }
        public Guid BusinessId { get; set; }
        public Business Business { get; set; }
       // public ICollection<Sell> Sells { get; set; }
        public ICollection<Outlet> Outlets { get; set; }
        // public string Username { get; set; }
        // Id, Username, Full Name, Email, Picture URL, Password Hash
    }
}
