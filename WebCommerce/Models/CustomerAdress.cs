using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCommerce.Models
{
    public class CustomerAdress
    {
        [Key]
        public int adressId { get; set; }
        public int customerId { get; set; }
        [ForeignKey("customerId")]
        public String adressText { get; set; }
    }
}
