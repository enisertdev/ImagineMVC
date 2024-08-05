using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied()
        {
                    ViewBag.CustomMessage = "You do not have the necessary permissions to view this page.";

            return View();
        }
    }
}
