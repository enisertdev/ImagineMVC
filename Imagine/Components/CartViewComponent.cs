using System.Security.Claims;
using Imagine.Business.Services.CartService;
using Imagine.Business.Services.UserService;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Components
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly IUserService _userService;
        public CartViewComponent(ICartService cartService, IUserService userService)
        {
            _cartService = cartService;
            _userService = userService;
        }

        public string Invoke()
        {
            if (User.Identity.IsAuthenticated)
            {
                User? user = _userService.GetUser(u => u.Email == UserClaimsPrincipal.FindFirstValue(ClaimTypes.Email));
                string cartItems = _cartService.GetMany(i => i.UserId == user.Id).Count().ToString();
                return $"({cartItems})";
            }

            return "";
        }
    }
}