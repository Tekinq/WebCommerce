using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebCommerce.Models
{
    public class Stock
    {
        [Key]
        public int stockId { get; set; }
        public int productId { get; set; }
        [ForeignKey("productId")]
        public int productStock { get; set; }
        
    }
}
