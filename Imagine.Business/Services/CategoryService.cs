using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;

namespace Imagine.Business.Services
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
    }
}
