using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Imagine.DataAccess.Entities.Dtos;
using AutoMapper;
using Imagine.Business.Services.EmailService;
using Imagine.Business.Services.UserAuthenticationService;
using Imagine.Business.Services.UserService.UserService;

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
        public IActionResult Login(string? returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
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

            //if inputs are not match any user
            if (user == null)
            {
                ModelState.AddModelError("", "Email or Password is wrong");
                return View(model);
            }

            //if user hasn't confirmed email
            if (!user.IsConfirmed)
            {
                TempData["Error"] = "You have not confirmed your email.Please check your email before logging in.";
                return View(model);
            }

            await _userAuthenticationService.SignInUserAsync(user);
            string returnUrl = TempData["returnUrl"].ToString();
            return LocalRedirect(returnUrl ?? Url.Action("Index", "Home"));
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
                var result =await _userService.RegisterUserAsync(user);
                if (!result.success)
                {
                    TempData["Error"] = result.errorMessage;
                    return View(user);
                }

                await _emailService.SendEmailAsync(
                    email: user.Email,
                    subject: "Welcome",
                    confirmUrl: Url.Action("ConfirmEmail", "User", new { email = user.Email }, "https", "smart-tops-pelican.ngrok-free.app"));

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
            User existingUser = _userService.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email));
            existingUser = _mapper.Map(user, existingUser);

            _userService.UpdateUser(existingUser);

            TempData["Success"] = "Profile succesfully updated.";

            return RedirectToAction("Profile");
        }
    }
}
