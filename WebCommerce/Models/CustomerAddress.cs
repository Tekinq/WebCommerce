using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCommerce.Models
{
    public class CustomerAddress
    {
        [Key, ForeignKey(nameof(Customer))]
        public int AdressId { get; set; }

        public string AdressText { get; set; }
        //public Customer Customer { get; set; }


    }
}
