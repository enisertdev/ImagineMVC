using System.Security.Claims;
using Imagine.Business.Services;
using Imagine.DataAccess.Entities;
using Imagine.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Components.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public CartController(IProductService productService, ICartService cartService, IUserService userService)
        {
            _productService = productService;
            _cartService = cartService;
            _userService = userService;
        }

        public IActionResult Cart()
        {
            User user = _userService.GetUser(u => u.Email == User.FindFirstValue(ClaimTypes.Email));
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }
            IEnumerable<Cart> items = _cartService.GetMany(u => u.UserId == user.Id);
            if (items == null)
            {
                ViewData["Empty"] = "Cart is empty";
                return View();
            }
            else
            {
                decimal total = 0;
                foreach (var item in items)
                {
                    total += item.Quantity * item.Product.Price;
                }
                ViewData["total"] = total.ToString("c");
                ViewData["items"] = items.Count();
            }
            return View(items);
        }

        [HttpPost]
        public IActionResult AddToCart(Product product, int Quantity = 1)
        {

            Product getProduct = _productService.GetProduct(p => p.Id == product.Id);
            if (getProduct == null)
            {
                return NotFound("invalid product");
            }
            if (!User.Identity.IsAuthenticated)
            {
                TempData["error"] = "You must login to purchase items.";
                return Redirect($"/Home/Details/{product.Id}");

            }

            User user = _userService.GetUser(u => u.Email == User.FindFirstValue(ClaimTypes.Email));
            _cartService.AddItem(getProduct, user.Id, Quantity);
            TempData["success"] = "Item has been added to your cart.";
            return RedirectToAction("Cart", "Cart");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            Cart item = _cartService.GetItem(p => p.ProductId == productId);
            if (item == null)
            {
                return NotFound("invalid item");
            }

            if (item.Quantity > 1)
            {
                item.Quantity -= 1;
                _cartService.UpdateItem(item);
            }
            else
            {
                _cartService.RemoveItem(item);
            }

            return RedirectToAction("Cart", "Cart");
        }

        public IActionResult IncreaseItemQuantity(int productId)
        {
            Cart item = _cartService.GetItem(p=>p.ProductId == productId);
            if (item == null)
            {
                return NotFound("invalid item");
            }
            item.Quantity += 1;
            _cartService.UpdateItem(item);
            return RedirectToAction("Cart", "Cart");
        }
    }
}
