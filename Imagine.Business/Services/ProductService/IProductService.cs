using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.Business.Services.ProductService
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(Expression<Func<Product, bool>> expression);
        IEnumerable<Product> GetAllProductsWithCategory();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void RemoveProduct(Product product);
        void RemoveProductById(int id);
        IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> filter);
        Product GetProductWithCategory(int id);
        IEnumerable<Product> GetProductsWithCategory(Expression<Func<Product, bool>> filter);
        ProductDtoForUpdate GetOneProductForUpdate(int id);
    }
}
