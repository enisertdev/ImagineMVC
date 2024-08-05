using Microsoft.AspNetCore.Mvc;

namespace Imagine.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ErrorController : Controller
    {
        public IActionResult StatusCode(int code)
        {
            switch (code)
            {
                case 403:
                    return RedirectToAction("AccessDenied", "Error", new { area = "" });
                case 404:
                    return RedirectToAction("NotFound", "Error", new { area = "" });
                default:
                    return View("Error");
            }
        }
        [Route("Error/AccessDenied")]

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}
