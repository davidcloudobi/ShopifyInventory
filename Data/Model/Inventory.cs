using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
   public class Inventory : ModelBaseClass
    {
        [Required(ErrorMessage = "Quantity must not be empty")]
        public long Quantity { get; set; }

        public Guid BusinessId { get; set; }
        public Business Business { get; set; }
        public Guid OutletId { get; set; }
        public Outlet Outlet { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
