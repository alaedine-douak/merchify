namespace Merchify.Web.Models;

public class CategoriesRepository : ICategoryRepository
{

   private static readonly List<Category> _categories =
   [
      new () { Id = 1, Name = "Beverage", Description = "Beverage" },
      new () { Id = 2, Name = "Bakery", Description = "Bakery" },
      new () { Id = 3, Name = "Meat", Description = "Meat" }
   ];

   public List<Category> GetCategories() => _categories;

   public Category? GetCategoryById(int id)
   {
      var category = _categories.FirstOrDefault(x => x.Id == id);

      if (category is null) return null;

      return new()
      {
         Id = category.Id,
         Name = category.Name,
         Description = category.Description,
      };
   }

   public void AddCategory(Category category)
   {
      int id = _categories is [] ? 1
         : _categories.Max(x => x.Id) + 1;

      category.Id = id;

      _categories.Add(category);
   }

   public void UpdateCategory(int id, Category category)
   {
      if (id != category.Id) return;

      var categoryToUpdate = _categories.FirstOrDefault(x => x.Id == id);

      if (categoryToUpdate is null) return;

      categoryToUpdate.Name = category.Name;
      categoryToUpdate.Description = category.Description;
   }

   public void DeleteCategory(int id)
   {
      var category = _categories.FirstOrDefault(x => x.Id == id);

      if (category is null) return;

      _categories.Remove(category);
   }
}
