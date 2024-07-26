using Imagine.Business.Services;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using Imagine.DataAccess.Repositories;
using Imagine.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Imagine.Components.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public HomeController(IProductService productService, IUserService userService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _userService = userService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> products = _productService.GetAllProductsWithCategory();
            return View(products);
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

        public IActionResult Details(int id)
        {
            Product product = _productService.GetProductWithCategory(id);
            return View(product);
        }

        private bool UserIsAdmin()
        {
            var email = GetUserEmail();
            User user = _userService.GetUser(u => u.Email == email);
            return user.IsAdmin;
        }
    }
}
