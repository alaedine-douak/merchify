using Merchify.Web.ViewModels.Product;

namespace Merchify.Web.Models;

public static class ProductMapping
{
   public static ProductItemViewModel ProjectToVm(this Product p)
      => new ProductItemViewModel { Id = p.Id, Name = p.Name, Quantity = p.Quantity, Price = p.Price, CategoryId = p.CategoryId };

   public static ProductItemViewModel MapToViewModel(this Product p)
      => new ProductItemViewModel { Id = p.Id, Name = p.Name, Quantity = p.Quantity, Price = p.Price, CategoryId = p.CategoryId };

   public static Product MapToEntity(this CreateProductViewModel m, int id) 
      => new Product { Id = id, Name = m.Name, Quantity = m.Quantity, Price = m.Price, CategoryId = m.CategoryId };
}

public interface IProductRepository
{
   ProductListItemViewModel GetProducts();
   void CreateProduct(CreateProductViewModel model);
   ProductItemViewModel? GetProductById(int id);
   void UpdateProduct(int id, EditProductViewModel model);
   void DeleteProduct(int id);
}

public class ProductRepository : IProductRepository
{
   private static readonly List<Product> s_products =
   [
      new () { Id = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 2,  Price = 9.99M },
      new () { Id = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 2,  Price = 9.99M  },
      new () { Id = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 2,  Price = 9.99M  },
      new () { Id = 4, CategoryId = 2, Name = "White Bread", Quantity = 2,  Price = 9.99M  },
   ];

   public ProductListItemViewModel GetProducts()
      => new ProductListItemViewModel { Items = s_products.Select(p => p.ProjectToVm()).ToList() };

   public void CreateProduct(CreateProductViewModel model)
   {
      int productId = s_products is []
         ? 1
         : s_products.Max(p => p.Id) + 1;

      Product product = model.MapToEntity(productId);

      s_products.Add(product);
   }

   public ProductItemViewModel? GetProductById(int id)
   {
      var product = s_products.FirstOrDefault(p => p.Id == id);

      if (product is null) return null;

      ProductItemViewModel model = product.MapToViewModel();

      return model;
   }

   public void UpdateProduct(int id, EditProductViewModel model)
   {
      if (id != model.Id) return; /* TODO: ... */

      var productToUpdate = s_products.FirstOrDefault(p => p.Id == id);

      if (productToUpdate is null) return;  /* TODO: ... */

      productToUpdate.Name = model.Name;
      productToUpdate.Quantity = model.Quantity;
      productToUpdate.Price = model.Price;
   }

   public void DeleteProduct(int id)
   { 
      var product = s_products.FirstOrDefault(p => p.Id == id);

      if (product is not null)
      {
         s_products.Remove(product);
      }
   }
}
