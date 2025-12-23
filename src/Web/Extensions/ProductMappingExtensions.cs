namespace Merchify.Web.Extensions;

public static class ProductMappingExtensions
{
   public static Product MapToProductEntity(this ProductModel model) 
      => new ()
      {
         Id = model.Id, 
         Name = model.Name, 
         Quantity = model.Qty, 
         Price = model.Price
      };
   
   public static ProductModel MapToProductModel(this Product product) 
      => new ()
      {
         Id = product.Id, 
         Name = product.Name, 
         Qty = product.Quantity, 
         Price = product.Price
      };

   public static IEnumerable<ProductModel> MapToProductsModel(this IEnumerable<Product> products) 
      => products.Select(p => p.MapToProductModel());
}