using Imagine.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.DataAccess.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        void RemoveById(int id);
        public IEnumerable<Category> GetCategoriesWithParent();

    }
}
