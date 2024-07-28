using AutoMapper;
using Imagine.Business.Services;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Entities.Dtos;
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
        private readonly IMapper _mapper;

        public DashboardController(IProductService productService, IUserService userService, IMapper mapper)
        {
            _productService = productService;
            _userService = userService;
            _mapper = mapper;
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
        [ValidateAntiForgeryToken]
        public IActionResult EditUser(User user, bool isChecked)
        {
            User getUser = _userService.GetUser(u => u.Id == user.Id);
            if (getUser == null)
            {
                return NotFound("User not found");
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
             User user =_userService.GetUser(u=> u.Id == id);
            if (user == null)
                return NotFound("not found");
            _userService.RemoveUser(user);
            return RedirectToAction("ListUsers");
        }
    }
}
