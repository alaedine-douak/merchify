using Microsoft.AspNetCore.Mvc;

namespace Merchify.Web.Controllers;

public class HomeController : Controller
{
   public IActionResult Index() => View();
}