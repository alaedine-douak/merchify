namespace Merchify.Web.Controllers;

public class ProductsController(
   IRepository<Product> productRepo) : Controller
{
   private readonly IRepository<Product> _productRepo = productRepo;

   [HttpGet]
   public IActionResult Index()
   {
      var products = _productRepo.GetAll();

      return products is { Count: > 0 }
         ? View((List<ProductModel>)[.. products.MapToProductsModel()])
         : View();
   }

   [HttpGet]
   public IActionResult Insert() 
      => View();

   [HttpPost]
   [ValidateAntiForgeryToken]
   public IActionResult Insert(InsertProductModel model)
   {
      if (ModelState is { IsValid: false }) return View(model);

      Product product = new() { Name = model.Name, Quantity = model.Qty, Price = model.Price };
      
      _productRepo.Insert(product);

      return RedirectToAction(nameof(Index));
   }

   [HttpGet("[controller]/{id:int}")]
   public IActionResult Edit(int id)
   {
      var product = _productRepo.GetById(id);

      if (product is null) return NotFound();

      ProductModel productModel = product.MapToProductModel();

      return View(productModel);
   }

   [HttpPost("[controller]/{id:int}")]
   [ValidateAntiForgeryToken]
   public IActionResult Edit(int id, ProductModel model)
   {
      if (id != model.Id) return BadRequest();
      
      if (ModelState is { IsValid: false }) return View(model);

      _productRepo.Update(model.MapToProductEntity());

      return RedirectToAction(nameof(Index));
   }

   [HttpGet("[controller]/{id:int}/delete")]
   public IActionResult Delete(int id) 
   {
      _productRepo.Delete(id);
      return RedirectToAction(nameof(Index));
   }
}
