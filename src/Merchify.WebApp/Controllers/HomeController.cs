using Microsoft.AspNetCore.Mvc;

namespace Merchify.WebApp.Controllers;

public class HomeController : Controller
{
   public IActionResult Index() => View();
}