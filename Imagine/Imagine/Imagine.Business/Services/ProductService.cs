using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productrepository;

        public ProductService(IProductRepository productrepository)
        {
            _productrepository = productrepository;
        }

        public void AddProduct(Product product)
        {
            _productrepository.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productrepository.GetAll();
        }

        public Product GetProduct(Expression<Func<Product,bool>> filter)
        {
            return _productrepository.Get(filter);
        }

        public void RemoveProduct(Product product)
        {
            _productrepository.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            _productrepository.Update(product);
        }

        public IEnumerable<Product> GetAllProductsWithCategory()
        {
            return _productrepository.GetAllProductsWithCategory();
        }

        public void RemoveProductById(int id)
        {
            _productrepository.RemoveById(id);
        }
    }
}
