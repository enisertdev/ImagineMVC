﻿using System.Security.Claims;
using Imagine.Business.Services.CartService;
using Imagine.Business.Services.EmailService;
using Imagine.Business.Services.OrderItemService;
using Imagine.Business.Services.OrderService;
using Imagine.Business.Services.UserService;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using Imagine.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace Imagine.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IEmailService _emailService;

        public PaymentController(ICartService cartService, IUserService userService, IOrderService orderService, IOrderItemService orderItemService, IEmailService emailService)
        {
            _cartService = cartService;
            _userService = userService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            User user = _userService.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email));
            IEnumerable<Cart> items = _cartService.GetMany(i => i.UserId == user.Id);
            if (!items.Any())
            {
                return NotFound();
            }

            int totalquantity = items.Sum(p => p.Quantity);
            TempData["itemcount"] = totalquantity;

            decimal totalprice = items.Sum(p => p.Product.Price * p.Quantity);


            PaymentViewModel model = new PaymentViewModel()
            {
                Email = user.Email,
                Price = totalprice
            };

            string confirmUrl = Url.Action("ConfirmWithQR", "Payment", new { userId = user.Id, totalquantity = totalquantity }, Request.Scheme);

            byte[] qrCodeImage;
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(confirmUrl, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                qrCodeImage = qrCode.GetGraphic(20);
            }

            string base64Image = Convert.ToBase64String(qrCodeImage);
            string imageSrc = string.Format("data:image/png;base64,{0}", base64Image);

            ViewBag.QRCodeImage = imageSrc;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmPayment()
        {
            User user = _userService.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (user.Address == null)
            {
                return NotFound("You have to add your address.");
            }
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
        [HttpPost]
        public async Task<IActionResult> ConfirmPaymentWithWallet(PaymentViewModel paymentViewModel)
        {
            User user = _userService.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (user.Address == null)
            {
                return NotFound("You have to add your address.");
            }

            IEnumerable<Cart> items = _cartService.GetMany(i => i.UserId == user.Id);
            if (!items.Any())
            {
                return NotFound();
            }

            int totalQuantity = items.Sum(p => p.Quantity);
            int itemCountFromTempData = Convert.ToInt32(TempData["itemcount"]);

            if (paymentViewModel.Price >= user.Amount)
            {
                return NotFound("Not enough wallet amount to pay.");
            }

            if (totalQuantity != itemCountFromTempData)
            {
                return RedirectToAction("Error");
            }

            user.Amount -= paymentViewModel.Price;
            _userService.UpdateUser(user);

            return RedirectToAction("Success");
        }

        [HttpGet]
        [Authorize]
        public IActionResult ConfirmWithQR(int userId, int totalquantity)
        {
            User user = _userService.GetUser(u => u.Id == userId);
            if (user.Email != User.FindFirstValue(ClaimTypes.Email))
            {
                return NotFound("This cart does not belong to you!");
            }

            IEnumerable<Cart> items = _cartService.GetMany(i => i.UserId == user.Id);
            if (!items.Any())
            {
                return NotFound();
            }

            int totalitems = items.Sum(p => p.Quantity);
            decimal totalprice = items.Sum(p => p.Product.Price * p.Quantity);
            if (totalprice >= user.Amount)
            {
                return NotFound("Not enough wallet amount to pay.");
            }

            if (totalquantity == totalitems)
            {
                user.Amount -= totalprice;
                _userService.UpdateUser(user);
                return RedirectToAction("Success");
            }

            return RedirectToAction("Error");
        }


        public async Task<IActionResult> Success()
        {
            User user = _userService.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email));
            IEnumerable<Cart> items = _cartService.GetMany(i => i.UserId == user.Id).ToList();
            if (!items.Any())
            {
                return NotFound("?");
            }

            await _orderService.CreateOrdersAsync(user);

            _cartService.RemoveItems(items);

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
