namespace Merchify.WebApp.Models;

public interface ICategoryRepository
{
   void AddCategory(Category category);
   void DeleteCategory(int id);
   List<Category> GetCategories();
   Category? GetCategoryById(int id);
   void UpdateCategory(int id, Category category);
}