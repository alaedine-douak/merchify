namespace Merchify.Web.Models;

public class CategoryRepository : ICategoryRepository
{

   private static readonly List<Category> _categories =
   [
      new () { Id = 1, Name = "Beverage", Description = "Beverage" },
      new () { Id = 2, Name = "Bakery", Description = "Bakery" },
      new () { Id = 3, Name = "Meat", Description = "Meat" }
   ];

   public List<CategoryDetailVm> GetCategories() =>
      _categories.Select(category => new CategoryDetailVm {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
         })
         .ToList();

   public CategoryDetailVm? GetCategoryById(int id)
   {
      var category = _categories.FirstOrDefault(x => x.Id == id);

      if (category is null) return null;

      return new CategoryDetailVm
      {
         Id = category.Id,
         Name = category.Name,
         Description = category.Description
      };
   }

   public void AddCategory(CreateCategoryVm model)
   {
      int categoryId = _categories is [] ? 1
         : _categories.Max(category => category.Id) + 1;

      Category category = new () 
      { 
         Id = categoryId, 
         Name = model.Name, 
         Description = model.Description 
      };

      _categories.Add(category);
   }

   public void UpdateCategory(int id, EditCategoryVm model)
   {
      var category = _categories.FirstOrDefault(x => x.Id == id);

      if (category is not { Id: var categoryId } || categoryId != id) return; 

      category.Name = model.Name;
      category.Description = model.Description;
   }

   public void DeleteCategory(int id)
   {
      var category = _categories.FirstOrDefault(x => x.Id == id);

      if (category is null) return;

      _categories.Remove(category);
   }
}
