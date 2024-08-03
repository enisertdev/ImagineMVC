using Microsoft.AspNetCore.Mvc;

namespace Imagine.Controllers
{
    public class LandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
  
    }
}
