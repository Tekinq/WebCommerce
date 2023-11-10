using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebCommerce.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; } // Product sınıfına olan ilişkiyi temsil eder

        public int Quantity { get; set; }
    }

}