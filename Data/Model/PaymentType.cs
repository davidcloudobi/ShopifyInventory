using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Model
{
   public class PaymentType : ModelBaseClass
    {
        public PaymentType()
        {
            Sells = new HashSet<Sell>();
        }

        [Required(ErrorMessage = "Name must not be empty")]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Sell> Sells { get; set; }
    }
}
