using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCommerce.Models
{
    public class Subcategory
    {
        [Key]
        public int subcategoryId { get; set; }
        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public string subcategoryName { get; set; }

    }
}

