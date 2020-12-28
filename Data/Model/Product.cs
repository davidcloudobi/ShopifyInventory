using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
   public class Product : ModelBaseClass
    {
        public Product()
        {
            ProductPictures = new HashSet<ProductPicture>();
            Inventories = new HashSet<Inventory>();
            SellItems = new HashSet<SellItem>();
        }

        [Required(ErrorMessage = "Product Name must not be empty")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Product Price must not be empty")]
        public decimal Price { get; set; }
        public DateTime? ManufacturedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid BusinessId { get; set; }
        public Business Business { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductPicture> ProductPictures { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<SellItem> SellItems { get; set; }
    }
}
