using Imagine.DataAccess.Entities;
using System.Security.Claims;
using Imagine.Business.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Components
{
    public class UserAmountViewComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public UserAmountViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        public string Invoke()
        {
            if (User.Identity.IsAuthenticated)
            {
                User? user = _userService.GetUser(u => u.Email == UserClaimsPrincipal.FindFirstValue(ClaimTypes.Email));
                string userAMount = user.Amount.ToString();
                if (user.Amount == 0)
                {
                    return "0";
                }
                return userAMount;
            }
            return null;
        }
    }
}
