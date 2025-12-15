namespace Merchify.Web.Models;

public class Product
{
   public int Id { get; set; }
   public int? CategoryId { get; set; }
   public required string Name { get; set; }
   public int? Quantity { get; set; } = 0;
   public decimal? Price { get; set; } = decimal.Zero;
}
