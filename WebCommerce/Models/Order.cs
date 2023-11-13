using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCommerce.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public string OrderDetail { get; set; }
        //public Customer Customer { get; set; } // Customer sınıfına olan ilişkiyi temsil eder
        //public Product Product { get; set; }    
    }

}
