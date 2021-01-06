using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
   public class Inventory : ModelBaseClass
    {
        public Inventory()
        {
            //Products = new HashSet<Product>();
           InventoryProducts = new HashSet<InventoryProduct>();
        }

        [Required(ErrorMessage = "Quantity must not be empty")]
        public long Quantity { get; set; }

        //public Guid BusinessId { get; set; }
        //public Business Business { get; set; }
        public Guid OutletId { get; set; }
        public Outlet Outlet { get; set; }
        //public Guid ProductId { get; set; }
        // public Product Product { get; set; }

        //##########################################
        public ICollection<InventoryProduct> InventoryProducts { get; set; }
    }

   public class InventoryProduct : ModelBaseClass
   {
       [Required]
       public int Quantity { get; set; }

       public Guid ProductId { get; set; }
       public Product Product { get; set; }
       public Guid InventoryId { get; set; }
        public Inventory Inventory{ get; set; }
    }
}
