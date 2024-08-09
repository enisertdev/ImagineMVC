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
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<OrderItem> GetOrders(Expression<Func<OrderItem, bool>> filter)
        {
            return _context.OrderItems.Include(o => o.Order)
                .Include(p => p.Product)
                .Where(filter)
                .ToList();
        }
    }
}
