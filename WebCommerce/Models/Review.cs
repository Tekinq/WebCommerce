using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCommerce.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public string ReviewText { get; set; }
        //public Product Product { get; set; } // Product sınıfına olan ilişkiyi temsil eder
        //public Customer Customer { get; set; } // Customer sınıfına olan ilişkiyi temsil eder
    }
}