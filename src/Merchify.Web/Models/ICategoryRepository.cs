namespace Merchify.Web.Models;

public interface ICategoryRepository
{
   void AddCategory(CreateCategoryVm category);
   void DeleteCategory(int id);
   List<CategoryDetailVm> GetCategories();
   CategoryDetailVm? GetCategoryById(int id);
   void UpdateCategory(int id, EditCategoryVm category);
}