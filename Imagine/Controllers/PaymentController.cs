using System.Security.Claims;
using Imagine.Business.Services.CartService;
using Imagine.Business.Services.UserService.UserService;
using Imagine.DataAccess.Entities;
using Imagine.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IUserService _userService;

        public PaymentController(ICartService cartService, IUserService userService)
        {
            _cartService = cartService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            User user = _userService.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email));
            IEnumerable<Cart> items = _cartService.GetMany(i => i.UserId == user.Id);
            if (!items.Any())
            {
                return NotFound();
            }

            TempData["itemcount"] = items.Sum(p=>p.Quantity);
            decimal totalprice = items.Sum(p => p.Product.Price);

            PaymentViewModel model = new PaymentViewModel()
            {
                Email = user.Email,
                Price = totalprice
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ConfirmPayment()
        {
            User user = _userService.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email));
            IEnumerable<Cart> items = _cartService.GetMany(i => i.UserId == user.Id);
            if (!items.Any())
            {
                return NotFound();
            }
            int totalquantity = items.Sum(p => p.Quantity);
            if (totalquantity == Convert.ToInt32(TempData["itemcount"]))
            {
                return RedirectToAction("Success");
            }

            return RedirectToAction("Error");
        }

        public IActionResult Success()
        {
            User user = _userService.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email));
            IEnumerable<Cart> items = _cartService.GetMany(i => i.UserId == user.Id);
            if (!items.Any())
            {
                return NotFound();
            }
            _cartService.RemoveItems(items);
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
