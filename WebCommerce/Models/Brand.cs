using System.ComponentModel.DataAnnotations;

namespace WebCommerce.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public ICollection<Subcategory> Subcategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
