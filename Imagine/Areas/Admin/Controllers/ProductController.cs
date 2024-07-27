using Imagine.Business.Services;
using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public ProductController(ICategoryService categoryService, IProductService productService, IUserService userService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _userService = userService;

        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _productService.GetAllProductsWithCategory();
            ViewBag.productCount = _productService.GetAllProducts().Count();
            ViewBag.userCount = _userService.GetAllUsers().Count();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.getAllCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(product);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Fill all spaces");
            return RedirectToAction("Create");
        }

        public IActionResult Edit(int id)
        {
            var product = _productService.GetProduct(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
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
            return View(product);
        }
        public IActionResult Delete(int id)
        {
            _productService.RemoveProductById(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var product = _productService.GetProductWithCategory(id);
            if (product == null)
                return NotFound("Product does not exist.");
            return View(product);
        }
    }
}
