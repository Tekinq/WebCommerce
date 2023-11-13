using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCommerce.Models
{
    public class Subcategory
    {
        [Key]
        public int SubcategoryId { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        public string SubcategoryName { get; set; }

        //public Brand Brand { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
