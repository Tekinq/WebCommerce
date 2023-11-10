using System.ComponentModel.DataAnnotations;

namespace WebCommerce.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public List<Subcategory> Subcategories { get; set; } // Brand sınıfının Subcategory koleksiyonu

    }
}
