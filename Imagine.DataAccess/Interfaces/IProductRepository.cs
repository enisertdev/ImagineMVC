using Imagine.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.DataAccess.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetAllProductsWithCategory();
        void RemoveById(int id);
        Product GetProductWithCategory(Expression<Func<Product, bool>> filter);
        IEnumerable<Product> GetProductsWithCategory(Expression<Func<Product, bool>> filter);

    }
}
