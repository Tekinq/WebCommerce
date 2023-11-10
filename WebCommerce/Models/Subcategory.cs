using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCommerce.Models
{
    public class Subcategory
    {
        [Key]
        public int SubcategoryId { get; set; }

        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; } // Category sınıfına olan ilişkiyi temsil eder

        public string SubcategoryName { get; set; }

    }
}
