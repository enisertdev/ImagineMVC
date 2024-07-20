using Imagine.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.Business.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(Expression<Func<Product,bool>> expression);
        IEnumerable<Product> GetAllProductsWithCategory();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void RemoveProduct(Product product);
        void RemoveProductById(int id);
        IEnumerable<Product> GetProducts(Expression<Func<Product,bool>> filter);
    }
}
