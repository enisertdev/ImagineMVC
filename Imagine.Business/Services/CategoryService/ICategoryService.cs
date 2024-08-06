using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;

namespace Imagine.Business.Services.CategoryService
{
    public interface ICategoryService
    {
        IEnumerable<Category> getAllCategories();
        void CreateCategory(Category category);
        void RemoveCategory(int id);
        public IEnumerable<Category> GetCategoriesWithParent();

    }
}
