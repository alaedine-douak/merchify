namespace Merchify.Web.Extensions;

public static class CategoryMappingExtensions
{
   public static Category MapToCategoryEntity(this CategoryModel model) 
      => new ()
      {
         Id = model.Id, 
         Name = model.Name, 
         Description = model.Description
      };
   
   public static CategoryModel MapToCategoryModel(this Category category) 
      => new ()
      {
         Id = category.Id, 
         Name = category.Name, 
         Description = category.Description
      };

   public static IEnumerable<CategoryModel> MapToCategoryModels(this IEnumerable<Category> categories) 
      => categories.Select(c => c.MapToCategoryModel());
}