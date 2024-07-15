using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using Imagine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.DataAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
