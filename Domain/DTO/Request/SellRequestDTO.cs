using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace Domain.DTO.Request
{
   public class SellRequestDTO
    {
        [Required(ErrorMessage = "Total Cost must not be empty")]
        public decimal TotalCost { get; set; }
        public decimal Discount { get; set; }
        [Required(ErrorMessage = "Transaction Date must not be empty")]
        public DateTime TransactionDate { get; set; }
        public ICollection<SellItemDTO> SellItems { get; set; }
        public string PaymentType { get; set; }
        public Guid CustomerId { get; set; }
        public Guid OutletId { get; set; }
       // public string ApplicationUserId { get; set; }


    }

   public class SellItemDTO
   {
       [Required(ErrorMessage = "Quantity must not be empty")]
       public int Quantity { get; set; }
       [Required(ErrorMessage = "Price Sold must not be empty")]
       public decimal PriceSold { get; set; }
       [Required(ErrorMessage = "Product Id  must not be empty")]
        public Guid ProductId { get; set; }
        public decimal Discount { get; set; }
        //public ProductDTO Product { get; set; }
    }
  //public class  ProductDTO
  // {
  //     [Required(ErrorMessage = "Product Id must not be empty")]
  //     public string ProductId { get; set; }
  //     public decimal Discount { get; set; }
  //  }
}
