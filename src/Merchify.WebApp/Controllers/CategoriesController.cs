using Merchify.WebApp.Models;

using Microsoft.AspNetCore.Mvc;

namespace Merchify.WebApp.Controllers;

[Route("[controller]")]
public class CategoriesController(
   ICategoryRepository categoryRepo
   ) : Controller
{
   private readonly ICategoryRepository _categoryRepo = categoryRepo;

   [HttpGet]
   public IActionResult Index()
   {
      return View(_categoryRepo.GetCategories());
   }

   [HttpGet("{id:int}")]
   public IActionResult Edit(int id)
   {
      var category = _categoryRepo.GetCategoryById(id);

      return View(category);
   }

   [HttpPost("{id:int}")]
   public IActionResult Edit(int id, Category category /* TODO: create dto */)
   {
      if (!ModelState.IsValid) return View(category);

      _categoryRepo.UpdateCategory(id, category);

      return RedirectToAction(nameof(Index));
   }

}