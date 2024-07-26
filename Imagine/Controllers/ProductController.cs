using System.Collections;
using Imagine.Business.Services;
using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Components.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult ProductsByCategory(int categoryId)
        {
            IEnumerable<Product> products = _productService.GetProducts(p => p.CategoryId == categoryId);
            return View(products);
        }

        public IActionResult Search(string? search)
        {
            var products = _productService.GetProducts(p => p.Name.Contains(search));
                if (products.Count() == 0 && string.IsNullOrEmpty(search)) 
                return View(_productService.GetAllProducts());
                if(products.Count() == 0 && !string.IsNullOrEmpty(search))
            {
                TempData["NotFound"] = "No product found with this keyword.";
            }
            return View(products);
        }
    }
}
