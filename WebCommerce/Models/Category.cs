using System.ComponentModel.DataAnnotations;

namespace WebCommerce.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        public string categoryName { get; set; }

    }
}
