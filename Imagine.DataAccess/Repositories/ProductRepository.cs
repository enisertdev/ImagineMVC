using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using Imagine.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProductsWithCategory()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        public void RemoveById(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product GetProductWithCategory(Expression<Func<Product, bool>> filter)
        {
           return _context.Products.Include(p => p.Category).FirstOrDefault(filter);
        }
        public IEnumerable<Product> GetProductsWithCategory(Expression<Func<Product, bool>> filter)
        {
            return _context.Products.Include(p => p.Category).Where(filter).ToList();
        }
    }
}
