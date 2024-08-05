using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using Imagine.Database;
using Microsoft.EntityFrameworkCore;

namespace Imagine.DataAccess.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Cart> GetManyItems(Expression<Func<Cart, bool>> filter)
        {
            return _context.Carts.Include(c => c.Product).Where(filter).ToList();
        }
    }
}
