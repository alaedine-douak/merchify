using Merchify.Web.Models;

using Microsoft.AspNetCore.Mvc;

namespace Merchify.Web.Controllers;

[Route("[controller]")]
public class CategoriesController(
   ICategoryRepository categoryRepo
   ) : Controller
{
   private readonly ICategoryRepository _categoryRepo = categoryRepo;

   [HttpGet]
   public IActionResult Index() => 
      View(_categoryRepo.GetCategories());


   [HttpGet("[action]")]
   public IActionResult Add() => View();


   [HttpPost("[action]")]
   public IActionResult Add(Category category)
   {
      if (!ModelState.IsValid) return View(category);

      _categoryRepo.AddCategory(category);

      return RedirectToAction(nameof(Index));
   }

   [HttpGet("{id:int}/[action]")]
   public IActionResult Edit(int id)
   {
      var category = _categoryRepo.GetCategoryById(id);

      if (category is null) return NotFound();

      // TODO: map domain entity to view-model

      return View(category);
   }

   [HttpPost("{id:int}/[action]")]
   public IActionResult Edit(int id, Category category)
   {
      if (!ModelState.IsValid) return View(category);

      _categoryRepo.UpdateCategory(id, category);

      return RedirectToAction(nameof(Index));
   }

   [HttpGet("{id:int}/[action]")]
   public IActionResult Delete(int id)
   {
      _categoryRepo.DeleteCategory(id);

      return RedirectToAction(nameof(Index));
   }
}
