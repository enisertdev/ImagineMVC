﻿using Imagine.Business.Services;
using Imagine.DataAccess.Entities;
using Imagine.Views.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace Imagine.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            ModelState.Remove("ValidatePassword");
            if (ModelState.IsValid)
            {
                User userExists = _userService.GetUser(u => u.Email == model.Email && u.Password == model.Password);
                if (userExists != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email,model.Email)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Email or Password is wrong");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Index","Home");
        }

        [HttpPost]
        public IActionResult Register(UserViewModel user)
        {
            if(user.ValidatePassword == null)
            {
                ModelState.AddModelError("", "You have to validate the password.");
            }
            if (ModelState.IsValid)
            {
                User newUser = new User {  Email = user.Email, Password = user.Password };
                _userService.AddUser(newUser);

                return RedirectToAction("Login");
            }
            return View(user);
        }
    }
}