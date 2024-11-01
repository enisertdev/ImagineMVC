using Imagine.Business.Services.CategoryService;
using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.getAllCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            ViewBag.Categories = _categoryService.getAllCategories();
            if (ModelState.IsValid)
            {
                Category insertCategory = new Category()
                {
                    Name = category.Name,
                    ParentId = category.ParentId
                };

                _categoryService.CreateCategory(insertCategory);

                return RedirectToAction("Index", "Dashboard");
            }
            return View(category);
        }

        public IActionResult RemoveCategory(int id)
        {
            _categoryService.RemoveCategory(id);
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            return View(_categoryService.getAllCategories());

        }
    }
}
