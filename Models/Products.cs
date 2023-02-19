using MessagePack;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Models
{
    public class Products
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:c}")]
        //[ValidateNever]
        //[RegularExpression(@"^\d+(,\d{1,2})?$"), ErrorMessage = "Price must be in the correct format"]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string? Image { get; set; }
        [DisplayName("Product Color")]
        public string? ProductColor { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [DisplayName("Available")]
        public bool IsAvailable { get; set; }
        [DisplayName("Product Type")]
        [System.ComponentModel.DataAnnotations.Required]
        public int ProductTypeId { get; set; }
        [ForeignKey(nameof(ProductTypeId))]
        
        public virtual ProductTypes? ProductTypes { get; set; }
    }
}
