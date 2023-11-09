using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCommerce.Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        public int customerId { get; set; }
        [ForeignKey("customerId")]
        public int adressId { get; set; }
        [ForeignKey("adressId")]
        public string orderDetail { get; set; }

    }
}
