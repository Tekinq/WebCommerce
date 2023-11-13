using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCommerce.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        [ForeignKey(nameof(Subcategory))]
        public int SubcategoryId { get; set; }

        [ForeignKey(nameof(Stock))]
        public int StockId { get; set; }

        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public bool InStock { get; set; }
        public string ProductPicture { get; set; }

        //public Brand Brand { get; set; } // Category sınıfına olan ilişkiyi temsil eder
        //public Subcategory Subcategory { get; set; } // Subcategory sınıfına olan ilişkiyi temsil eder
        //public Stock Stock { get; set; }
        public ICollection<Review> Reviews { get; set;}
    }
}
