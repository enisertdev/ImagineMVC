using System.Drawing;
using Imagine.Business.Services.UserService.UserService;
using Imagine.DataAccess.Entities;
using Imagine.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace Imagine.Controllers
{
    public class WalletController : Controller
    {
        private readonly IUserService _userService;

        public WalletController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddAmount(AmountViewModel amountViewModel)
        {
            return View("AddAmount", amountViewModel);
        }

        public IActionResult ConfirmAddAmount(AmountViewModel amountViewModel)
        {
            User user = _userService.GetUser(u => u.Email == amountViewModel.Email);
            user.Amount += amountViewModel.Amount;
            _userService.UpdateUser(user);
            return RedirectToAction("Index","Home");
        }
    }
}
