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

        public IActionResult Search(string search)
        {
            return View(_productService.GetProducts(p => p.Name.Contains(search)));
        }
    }
}
