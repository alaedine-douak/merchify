using System.ComponentModel.DataAnnotations;

namespace Merchify.Web.ViewModels.Product;

public sealed record EditProductViewModel
{
   public int Id { get; set; }

   [Required]
   [StringLength(60, MinimumLength = 3)]
   public required string Name { get; set; }

   [Required]
   [Range(0, int.MaxValue)]
   public int? Quantity { get; set; }

   [Required]
   [DataType(DataType.Currency)]
   [Range(0, double.MaxValue)]
   public decimal? Price { get; set; } = 0.00M;
}
