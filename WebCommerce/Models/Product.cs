using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCommerce.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; } // Category sınıfına olan ilişkiyi temsil eder

        public int SubcategoryId { get; set; }

        [ForeignKey("SubcategoryId")]
        public Subcategory Subcategory { get; set; } // Subcategory sınıfına olan ilişkiyi temsil eder

        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public bool InStock { get; set; }
        public string ProductPicture { get; set; }
    }

}
