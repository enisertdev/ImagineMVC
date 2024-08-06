using System.Security.Claims;
using Imagine.Business.Services.UserService.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Imagine.Components
{
    public class UserViewComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public UserViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var name = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            return View("Default",name);
        }
    }
}
