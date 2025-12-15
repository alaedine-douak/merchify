using Merchify.Web.Models;

using Microsoft.AspNetCore.Mvc;

namespace Merchify.Web.Controllers;

[Route("[controller]")]
public class CategoriesController(ICategoryRepository categoryRepo) : Controller
{

   private readonly ICategoryRepository _categoryRepo = categoryRepo;

   [HttpGet]
   public IActionResult Index() => View(_categoryRepo.GetCategories());

   [HttpGet("[action]")]
   public IActionResult Add() 
   {
      return View();
   }

   [HttpPost("[action]")]
   public IActionResult Add(CreateCategoryVm model)
   {
      if (ModelState is { IsValid: false }) return View(model);

      _categoryRepo.AddCategory(model);

      return RedirectToAction(nameof(Index));
   }

   [HttpGet("{id:int}/[action]")]
   public IActionResult Edit(int id)
   {
      var categoryVM = _categoryRepo.GetCategoryById(id);

      if (categoryVM is null) return NotFound();

      return View(categoryVM);
   }

   [HttpPost("{id:int}/[action]")]
   public IActionResult Edit(int id, EditCategoryVm model)
   {
      if (ModelState is { IsValid: false }) return View();

      _categoryRepo.UpdateCategory(id, model);

      return RedirectToAction(nameof(Index));
   }

   [HttpGet("{id:int}/[action]")]
   public IActionResult Delete(int id)
   {
      _categoryRepo.DeleteCategory(id);

      return RedirectToAction(nameof(Index));
   }
}
