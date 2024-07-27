using Imagine.Business.Services;
using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public DashboardController(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }

        public IActionResult ListProducts()
        {
            return View(_productService.GetAllProductsWithCategory());
        }

        public IActionResult ListUsers()
        {
            return View(_userService.GetAllUsers());
        }
        public IActionResult EditUser(int id)
        {
            User user = _userService.GetUser(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(User user, bool isChecked)
        {
            User getUser = _userService.GetUser(u=>u.Id == user.Id);
            if (getUser == null)
            {
                return NotFound("User not found");
            }
            getUser.IsAdmin = isChecked ? true : false;
            _userService.UpdateUser(getUser);
            return RedirectToAction("ListUsers");

        }
    }
}
