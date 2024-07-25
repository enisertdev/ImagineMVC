using Microsoft.AspNetCore.Mvc;

namespace Imagine.Components.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
