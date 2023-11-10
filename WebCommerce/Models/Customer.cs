using System.ComponentModel.DataAnnotations;

namespace WebCommerce.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
        public string Address { get; set; }

    }

}
