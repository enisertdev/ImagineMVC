using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imagine.Database;
using Microsoft.EntityFrameworkCore;

namespace Imagine.DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetOrders(Expression<Func<Order, bool>> filter)
        {
            return _context.Orders.Include(o => o.User).Where(filter).ToList();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.Include(o => o.User).ToList();
        }

        public void RemoveOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public Order GetOneOrder(int id)
        {
            return _context.Orders.Include(o => o.User).FirstOrDefault(o=>o.Id == id);
        }
    }
}
