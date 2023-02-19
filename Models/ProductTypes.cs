using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class ProductTypes
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Product Type")]
        public string ProductType { get; set; }
    }
}
