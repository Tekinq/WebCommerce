using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebCommerce.Models
{
    public class Stock
    {
        [Key,ForeignKey(nameof(Product))]
        public int StockId { get; set; }
        public int Quantity { get; set; }

        //public Product Product { get; set; } // Product sınıfına olan ilişkiyi temsil eder
    }

}