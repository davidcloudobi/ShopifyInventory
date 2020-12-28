using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Data.Model.Identity;

namespace Data.Model
{
    public class Sell : ModelBaseClass
    {
        public Sell()
        {
            SellItems = new HashSet<SellItem>();
        }

        [Required(ErrorMessage = "Total Cost must not be empty")]
        public decimal TotalCost { get; set; }  
        public decimal Discount { get; set; }
        [Required(ErrorMessage = "Transaction Date must not be empty")]
        public DateTime TransactionDate { get; set; }
        public Guid BusinessId { get; set; }
        public Business Business { get; set; }
        public Guid OutletId { get; set; }
        public Outlet Outlet { get; set; }
        public Guid PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        //public Guid ApplicationUserId { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<SellItem> SellItems { get; set; }
       

    }
}
