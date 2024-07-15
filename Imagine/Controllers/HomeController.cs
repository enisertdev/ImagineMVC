using Imagine.Business.Services;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using Imagine.DataAccess.Repositories;
using Imagine.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Imagine.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _productService.GetAllProductsWithCategory();
            return View(products);
        }

        public IActionResult Edit(int id)
        {
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
            _productService.RemoveProductById(id);
            return RedirectToAction("Index");
        }
    }
}
