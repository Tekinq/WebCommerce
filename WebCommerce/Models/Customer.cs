using System.ComponentModel.DataAnnotations;

namespace WebCommerce.Models
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; }
        public string customerName { get; set; }
        public string customerSurname { get; set; }
        public string customerPhone { get; set; }
        public string customerEmail { get; set; }
        public string customerPassword { get; set; }
    }

}
