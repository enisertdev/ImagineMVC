using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryViewComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<Category> categories = _categoryRepository.GetCategoriesWithParent().Where(c=>c.ParentId == null);
            return View(categories);
        }
    }
}
