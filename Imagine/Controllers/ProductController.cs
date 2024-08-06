using System.Collections;
using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;
using X.PagedList;
using Imagine.Business.Services.ProductService;

namespace Imagine.Components.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult ProductsByCategory(int categoryId, int page = 1, int pageSize = 4)
        {
            IEnumerable<Product> products = _productService.GetProductsWithCategory(p => p.CategoryId == categoryId);

            IPagedList<Product> model = products.ToPagedList(page, pageSize);

            ViewData["CategoryId"] = categoryId;


            return View(model);
        }


        public IActionResult Search(string search)
        {
           return RedirectToAction("SearchResults", new {query = search ?? string.Empty});
        }
        public IActionResult SearchResults(string query, int page = 1, int pageSize = 4)
        {
            var products = _productService.GetProductsWithCategory(p => p.Name.Contains(query));
            if(string.IsNullOrEmpty(query))
            {
                return View(_productService.GetAllProducts());
            }
            if (products.Count() == 0)
            {
                TempData["NotFound"] = "No product found with this keyword.";
            }
            IPagedList<Product> model = products.ToPagedList(page, pageSize);

            return View(model);
        }
    }
}
