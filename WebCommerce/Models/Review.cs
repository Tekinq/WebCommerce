using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCommerce.Models
{
    public class Review
    {
        [Key]
        public int reviewId { get; set; }
        public int productId { get; set; }
        [ForeignKey("productId")]
        public int customertId { get; set; }
        [ForeignKey("customertId")]
        public string reviewText { get; set; }

    }
}
