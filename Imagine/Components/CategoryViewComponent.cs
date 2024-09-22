using Imagine.Business.Services.CategoryService;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;

        public CategoryViewComponent(ICategoryRepository categoryRepository, ICategoryService categoryService)
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<Category> categories =
                _categoryService.getAllCategories().Where(p => p.ParentId == null).ToList();
            return View(categories);
        }
    }
}
