using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Data.Model.Identity;

namespace Data.Model
{
   public class Outlet : ModelBaseClass
    {
        public Outlet()
        {
            Inventories = new HashSet<Inventory>();
            Sells = new HashSet<Sell>();
            ApplicationUsers = new HashSet<ApplicationUser>();
        }

        [Required(ErrorMessage = "Name must not be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Outlet Date must not be empty")]
        public DateTime DateAdded { get; set; }
        public Guid BusinessId { get; set; }
        public Business Business { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<Sell> Sells { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
