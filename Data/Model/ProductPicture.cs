using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
   public class ProductPicture : ModelBaseClass
    {
        //[Url(ErrorMessage = "Invalid Url")]
        //[Required(ErrorMessage = "Url must not be empty")]
        public string Url { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
