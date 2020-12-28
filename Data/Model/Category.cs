using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
   public class Category : ModelBaseClass
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Required(ErrorMessage = "Name must not be empty")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        //public Guid BusinessTypeId { get; set; }
        //public BusinessType BusinessType { get; set; }



        //#############################################################

        public Guid BusinessId { get; set; }
        public Business Business { get; set; }
    }
}
