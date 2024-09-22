using System.Security.Claims;
using AutoMapper;
using Imagine.Business.Services.CategoryService;
using Imagine.Business.Services.ProductService;
using Imagine.Business.Services.UserService.UserService;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Imagine.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ProductController(ICategoryService categoryService, IProductService productService, IUserService userService, IMapper mapper)
        {
            _categoryService = categoryService;
            _productService = productService;
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetCategories();
            return View();
        }
        public async Task<JsonResult> GetSubCategories(int categoryId)
        {
            var subCategories = _categoryService.getAllCategories()
                .Where(c => c.ParentId == categoryId)
                .Select(c => new { c.Id, c.Name });

            return Json(subCategories);
        }

        [HttpPost]
        public IActionResult GetSelectedCategory(int categoryId)
        {
            return NotFound("test");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDtoForInsertion product, IFormFile file)
        {
            ViewBag.Categories = _categoryService.getAllCategories();


            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                try
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    product.ImageUrl = file.FileName;
                    var createdProduct = _mapper.Map<Product>(product);
                    _productService.AddProduct(createdProduct);
                    return RedirectToAction("Index","Dashboard");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred: " + ex.Message);
                }
            }
            ModelState.AddModelError("", "Fill all spaces");
            return View(product);
        }


        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _categoryService.GetCategoriesWithParent();
            var product = _productService.GetOneProductForUpdate(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(ProductDtoForUpdate product)
        {
            if (User.FindFirstValue(ClaimTypes.Email) == "admin@admin.com")
            {
                return NotFound("You cannot edit items");
            }
            if (ModelState.IsValid)
            {
                var updatedProduct = _mapper.Map<Product>(product);
                _productService.UpdateProduct(updatedProduct);
                return RedirectToAction("Index","Dashboard");
            }
            return View(product);
        }
        public IActionResult Delete(int id)
        {
            if (User.FindFirstValue(ClaimTypes.Email) == "admin@admin.com")
            {
                return NotFound("You cannot remove items");
            }
            _productService.RemoveProductById(id);
            return RedirectToAction("Index","Dashboard");
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
