using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;

namespace Imagine.Business.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> getAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public void CreateCategory(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void RemoveCategory(int id)
        {
            _categoryRepository.RemoveById(id);
        }

        public IEnumerable<Category> GetCategoriesWithParent()
        {
           return _categoryRepository.GetCategoriesWithParent();
        }
    }
}
