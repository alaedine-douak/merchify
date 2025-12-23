namespace Merchify.Web.Controllers;

public class CategoriesController(
   IRepository<Category> categoryRepo) 
   : Controller
{
   private readonly IRepository<Category> _categoryRepo = categoryRepo;

   [HttpGet]
   public IActionResult Index()
   {
      var categories = _categoryRepo.GetAll();

      if (categories is { Count: 0 }) return View();

      List<CategoryModel> categoryList = [.. categories.MapToCategoryModels()];

      return View(categoryList);
   }

   [HttpGet]
   public IActionResult Insert() => View();

   [HttpPost]
   [ValidateAntiForgeryToken]
   public IActionResult Insert(InsertCategoryModel model)
   {
      if (!ModelState.IsValid) return View(model);

      Category category = new() { Name = model.Name, Description = model.Description };
      
      _categoryRepo.Insert(category);

      return RedirectToAction(nameof(Index));
   }
   
   
   [HttpGet("[controller]/{id:int}")]
   public IActionResult Edit(int id)
   {
      var category = _categoryRepo.GetById(id);

      if (category is null) return NotFound();

      CategoryModel categoryModel = category.MapToCategoryModel();
      
      return View(categoryModel);
   }
   
   
   [HttpPost("[controller]/{id:int}")]
   [ValidateAntiForgeryToken]
   public IActionResult Edit(int id, CategoryModel model)
   {
      if (id != model.Id) return BadRequest();
      
      if (!ModelState.IsValid) return View(model);
      
      _categoryRepo.Update(model.MapToCategoryEntity());

      return RedirectToAction(nameof(Index));
   }

      
   [HttpGet("[controller]/{id:int}/delete")]
   public IActionResult Delete(int id)
   {
      _categoryRepo.Delete(id);
      return RedirectToAction(nameof(Index));
   }
}