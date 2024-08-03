using Imagine.Business.Services;
using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Imagine.DataAccess.Entities.Dtos;
using AutoMapper;

namespace Imagine.Components.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IUserAuthenticationService _userAuthenticationService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IEmailService emailService, IUserAuthenticationService userAuthenticationService, IMapper mapper)
        {
            _userService = userService;
            _emailService = emailService;
            _userAuthenticationService = userAuthenticationService;
            _mapper = mapper;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(UserDtoForLogin model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User user = _mapper.Map<User>(model);
            user = _userService.CheckCredentials(user);

            if (user == null)
            {
                ModelState.AddModelError("", "Email or Password is wrong");
                return View(model);
            }

            if (!user.IsConfirmed)
            {
                TempData["Error"] = "You have not confirmed your email.Please check your email before logging in.";
                return View(model);
            }

            await _userAuthenticationService.SignInUserAsync(user);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(UserDtoForRegister user)
        {
            if (ModelState.IsValid)
            {
                User checkExistingUser = _userService.GetUser(u => u.Email == user.Email);

                if (checkExistingUser != null)
                {
                    ViewData["Exists"] = "An account with this email already exists.";
                    return View(user);
                }

                User newUser = _mapper.Map<User>(user);
                _userService.AddUser(newUser);

                var confirmationLink = Url.Action("ConfirmEmail", "User", new { email = newUser.Email }, Request.Scheme);
                await _emailService.SendEmailAsync(user.Email, "Welcome", confirmationLink);

                TempData["Message"] = "A confirmation email has been sent. Please confirm your email address before logging in.";

                return RedirectToAction("Login");
            }
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await _userAuthenticationService.SignOutUserAsync();
            return RedirectToAction("Index", "Home");
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

            await _userAuthenticationService.SignInUserAsync(user);

            return View("ConfirmEmail");
        }

        [Authorize]
        public IActionResult Profile()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = _userService.GetOneUserToUpdate(email);
            if (user is null)
                return NotFound("user not found");
            return View(user);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Profile(UserDtoForUpdate user)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            User existingUser = _userService.GetUser(u => u.Email == email);
            existingUser = _mapper.Map(user, existingUser);
            _userService.UpdateUser(existingUser);
            TempData["Success"] = "Profile succesfully updated.";
            return RedirectToAction("Profile");
        }
    }
}
