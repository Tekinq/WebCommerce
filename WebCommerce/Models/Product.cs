using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCommerce.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public int subcategoryId { get; set; }
        [ForeignKey("subcategoryId")]
        public string productName { get; set; }
        public int productPrice { get; set; }
        public bool productStock { get; set; }
        public string productPicture { get; set; }
    }
}
