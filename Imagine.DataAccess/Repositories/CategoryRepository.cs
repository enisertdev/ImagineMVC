using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using Imagine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Imagine.DataAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void RemoveById(int id)
        {
            Category category = _context.Categories.FirstOrDefault(p => p.Id == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetCategoriesWithParent()
        {
            return _context.Categories.Include(p=>p.Parent).Where(c=>c.ParentId !=  null).ToList();
        }
    }
}
