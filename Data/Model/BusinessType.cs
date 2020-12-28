using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Model
{
   public class BusinessType : ModelBaseClass
    {
        public BusinessType()
        {
            Businesses = new HashSet<Business>();
          //  Categories = new HashSet<Category>();
            // Brands = new HashSet<Brand>();
        }

        [Required(ErrorMessage = "Name must not be empty")]
        public string Name { get; set; }
        public ICollection<Business> Businesses { get; set; }
       // public ICollection<Category> Categories { get; set; }
       // public ICollection<Brand> Brands { get; set; }
    }
}
