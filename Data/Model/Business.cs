using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Data.Model.Identity;

namespace Data.Model
{
   public class Business : ModelBaseClass
    {
        public Business()
        {
            Outlets = new HashSet<Outlet>();
            Products = new HashSet<Product>();
            ApplicationUsers = new HashSet<ApplicationUser>();
            Inventories = new HashSet<Inventory>();
            Sells = new HashSet<Sell>();
            Customers = new HashSet<Customer>();
            Brands = new HashSet<Brand>();
            Categories = new HashSet<Category>();
        }

        [Required(ErrorMessage = "Business Name must not be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Contact Name of user must not be empty")]
        public string ContactName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "Email must not be empty")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Required(ErrorMessage = "Phone number must not be empty")]
        public string Phone { get; set; }
        public string Website { get; set; }
        [Url(ErrorMessage = "Invalid Url")]
       // [Required(ErrorMessage = "LogoUrl must not be empty")]
        public string LogoUrl { get; set; }

        public Guid BusinessTypeId { get; set; }
        public BusinessType BusinessType { get; set; }
        public  ICollection<Outlet> Outlets { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers  { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<Sell> Sells { get; set; }
        public ICollection<Customer> Customers { get; set; }


        //############################################################

        public ICollection<Brand> Brands { get; set; }
        public ICollection<Category> Categories { get; set; }

    }
}
