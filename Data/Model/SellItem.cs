using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
   public class SellItem : ModelBaseClass
    {
        [Required(ErrorMessage = "Quantity must not be empty")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price Sold must not be empty")]
        public decimal PriceSold { get; set; }

        public Guid SellId { get; set; }
        public Sell Sell { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
