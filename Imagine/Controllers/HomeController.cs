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

        public IActionResult Details(int id)
        {
            Product product = _productService.GetProductWithCategory(id);
            return View(product);
        }

    }
}
