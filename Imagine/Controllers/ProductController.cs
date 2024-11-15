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

        public IActionResult Details(int id)
        {
            Product product = _productService.GetProductWithCategory(id);
            if (product == null)
            {
                return NotFound("Null");
            }

            return View(product);
        }

        public IActionResult ProductsByCategory(int categoryId, int page = 1, int pageSize = 4)
        {

            IEnumerable<Product> products = _productService.GetProductsWithCategory(p => p.CategoryId == categoryId || p.Category.ParentId == categoryId);

            IPagedList<Product> model = products.ToPagedList(page, pageSize);

            ViewData["CategoryId"] = categoryId;


            return View(model);
        }
        public IActionResult ProductsFromBreadCrumbs(int categoryId, int parentId, int page = 1, int pageSize = 4)
        {

            IEnumerable<Product> products = _productService.GetProductsWithCategory(p => p.CategoryId == categoryId && p.Category.ParentId == parentId);

            IPagedList<Product> model = products.ToPagedList(page, pageSize);

            ViewData["CategoryId"] = categoryId;


            return View("ProductsByCategory", model);
        }


        public IActionResult Search(string search)
        {
            return RedirectToAction("SearchResults", new { query = search ?? string.Empty });
        }

        public IActionResult SearchResults(string query, int page = 1, int pageSize = 4)
        {
            if (string.IsNullOrEmpty(query))
            {
                var getAllProducts = _productService.GetAllProducts();
                var allProductsModel = getAllProducts.ToPagedList(page, pageSize);
                return View(allProductsModel);
            }

            var products = _productService.GetProductsWithCategory(p =>
                p.Name.Contains(query) || p.Brand.Contains(query) || p.Category.Name.Contains(query));

            if (products.Count() == 0)
            {
                TempData["NotFound"] = "No product found with this keyword.";
            }
            var model = products.ToPagedList(page, pageSize);

            return View(model);
        }
    }
}
