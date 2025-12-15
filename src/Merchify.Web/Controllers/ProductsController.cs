namespace Merchify.Web.Controllers;

public class ProductsController(
   IProductRepository productRepository
   ): BaseController
{

   private readonly IProductRepository _productRepository = productRepository;

   public IActionResult Index()
      => View(_productRepository.GetProducts());

   [Route("[action]")]
   public IActionResult Create() 
      => View();

   [HttpPost("[action]")]
   [ValidateAntiForgeryToken]
   public IActionResult Create(CreateProductViewModel model)
   {
      if (ModelState is { IsValid: false }) return View(model);

      _productRepository.CreateProduct(model);

      return RedirectToAction(nameof(Index));
   }

   [HttpGet("{id:int}/[action]")]
   public IActionResult Edit(int id)
   {
      var productItemVm = _productRepository.GetProductById(id);

      if (productItemVm is null) return NotFound();

      EditProductViewModel editProductVm = new()
      {
         Id = productItemVm.Id,
         Name = productItemVm.Name,
         Quantity = productItemVm.Quantity,
         Price = productItemVm.Price,
      };

      return View(editProductVm);
   }

   [HttpPost("{id:int}/[action]")]
   [ValidateAntiForgeryToken]
   public IActionResult Edit(int id, EditProductViewModel model)
   {
      if (ModelState is { IsValid: false })
         return View(model);

      _productRepository.UpdateProduct(id, model);

      return RedirectToAction(nameof(Index));
   }

   [HttpGet("{id:int}/[action]")]
   public IActionResult Delete(int id) 
   {
      _productRepository.DeleteProduct(id);
      return RedirectToAction(nameof(Index));
   }
}
