using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Imagine.Controllers
{
    public class BaseController : Controller
    {
        protected string GetUserEmail()
        {
            return User.FindFirstValue(ClaimTypes.Email);
        }

        protected string GetUserName()
        {
            return User.FindFirstValue(ClaimTypes.Name);
        }
    }
}
