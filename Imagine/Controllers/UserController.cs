using Imagine.Business.Services;
using Imagine.DataAccess.Entities;
using Imagine.Views.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Imagine.DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Imagine.Components.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        public UserController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
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
            ModelState.Remove("Name");

            if (ModelState.IsValid)
            {
                User userExists = _userService.GetUser(u => u.Email == model.Email && u.Password == model.Password);
                if (userExists != null)
                {
                    if (userExists.IsConfirmed is false)
                    {
                        return NotFound("Your email has not confirmed, check your email.");
                    }
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email,userExists.Email),
                        new Claim(ClaimTypes.Name, userExists.Name),
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

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel user)
        {
            if (user.ValidatePassword == null)
            {
                ModelState.AddModelError("", "You have to validate the password.");
            }
            if (ModelState.IsValid)
            {
                User newUser = new User { Name = user.Name, Email = user.Email, Password = user.Password };
                _userService.AddUser(newUser);
                var confirmationLink = Url.Action("ConfirmEmail", "User", new { email = user.Email }, Request.Scheme);
                await _emailService.SendEmailAsync(user.Email, "Welcome", confirmationLink);
                return RedirectToAction("Login");
            }
            return View(user);
        }
        public async Task<IActionResult> ConfirmEmail(string email)
        {
            User user = _userService.GetUser(u => u.Email == email);
            if (user == null)
            {
                return NotFound("User not found");
            }
            if (user.IsConfirmed)
            {
                return NotFound("you already confirmed your email.");
            }
            user.IsConfirmed = true;
            _userService.UpdateUser(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.Name)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return View("ConfirmEmail");
        }
        [Authorize]
        public IActionResult Profile()
        {
            var email = GetUserEmail();
            User user = _userService.GetUser(u => u.Email == email);
            if (user is null)
                return NotFound("user not found");
            return View(user);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Profile(User user)
        {
            var email = GetUserEmail();

            User updateUser = _userService.GetUser(u => u.Email == email);
            updateUser.Name = user.Name;
            updateUser.PhoneNumber = user.PhoneNumber;
            updateUser.Address = user.Address;
            updateUser.UserName = user.UserName;
            _userService.UpdateUser(updateUser);
            return RedirectToAction("Profile");
        }

    }
}
