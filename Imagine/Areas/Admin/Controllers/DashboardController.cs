using AutoMapper;
using Imagine.Business.Services.CategoryService;
using Imagine.Business.Services.OrderService;
using Imagine.Business.Services.ProductService;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Imagine.Business.Services.UserService;

namespace Imagine.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;

        public DashboardController(IProductService productService, IUserService userService, IMapper mapper, ICategoryService categoryService, IOrderService orderService)
        {
            _productService = productService;
            _userService = userService;
            _mapper = mapper;
            _categoryService = categoryService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _productService.GetAllProductsWithCategory();

            ViewBag.productCount = _productService.GetAllProducts().Count();
            ViewBag.userCount = _userService.GetAllUsers().Count();
            ViewBag.categoryCount = _categoryService.getAllCategories().Count();
            ViewBag.orderCount = _orderService.GetAllOrders().Count();

            return View(products);
        }

        public IActionResult ListProducts()
        {
            return View(_productService.GetAllProductsWithCategory());
        }


        public IActionResult ListUsers()
        {
            if (User.FindFirstValue(ClaimTypes.Email) == "admin@admin.com")
                return NotFound("you cannot view users.");

            return View(_userService.GetAllUsers());
        }
        public IActionResult EditUser(int id)
        {
            User user = _userService.GetUser(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUser(User user, bool isChecked)
        {
            if (User.FindFirstValue(ClaimTypes.Email) == "admin@admin.com")
            {
                return NotFound("You cannot edit users");
            }
            User getUser = _userService.GetUser(u => u.Id == user.Id);
            if (getUser == null)
            {
                return NotFound("User not found");
            }

            if (getUser.Email == "admin@admin.com")
            {
                return NotFound("you cannot revoke rights of this account.");
            }
            getUser.IsAdmin = isChecked ? true : false;
            _userService.UpdateUser(getUser);
            return RedirectToAction("ListUsers");
        }
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(UserDtoForInsertion user, bool isCheckedAdmin, bool isCheckedConfirmed)
        {
            if (ModelState.IsValid)
            {
                user.IsAdmin = isCheckedAdmin ? true : false;
                user.IsConfirmed = isCheckedConfirmed ? true : false;
                var createdUser = _mapper.Map<User>(user);
                _userService.AddUser(createdUser);

                return RedirectToAction("ListUsers");
            }
            return View(user);
        }

        public IActionResult DeleteUser(int id)
        {
            if (User.FindFirstValue(ClaimTypes.Email) == "admin@admin.com")
            {
                return NotFound("You cannot remove users");
            }
            User user = _userService.GetUser(u => u.Id == id);
            if (user == null)
                return NotFound("not found");
            if (user.IsAdmin)
            {
                return NotFound("You cannot remove admin");
            }
            _userService.RemoveUser(user);
            return RedirectToAction("ListUsers");
        }
    }
}
