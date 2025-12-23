namespace Merchify.Core;

public class Product : BaseEntity
{
   public int CategoryId { get; set; }
   public string Name { get; set; } = null!;
   public int Quantity { get; set; } 
   public decimal Price { get; set; } 
}