namespace Merchify.Web.Models.Product;

public sealed record InsertProductModel
{
   [Required]
   public required string Name { get; init; }

   [Required]
   [Display(Name = "Quantity")]
   public int Qty { get; init; }
   
   [Required]
   public decimal Price { get; init; }
}