using Imagine.Business.Services;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using Imagine.DataAccess.Repositories;
using Imagine.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Imagine.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public HomeController(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> products = _productService.GetAllProductsWithCategory();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public IActionResult Edit(int id)
        {
            if (!UserIsAdmin())
            {
                return Forbid();
            }
            Product product = _productService.GetProduct(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
           
            Product updatedProduct = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };
            _productService.UpdateProduct(updatedProduct);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (!UserIsAdmin())
            {
                return Forbid();
            }
            _productService.RemoveProductById(id);
            return RedirectToAction("Index");
        }

        private bool UserIsAdmin()
        {
            var email = GetUserEmail();
            User user = _userService.GetUser(u => u.Email == email);
            return user.IsAdmin;
        }
    }
}
