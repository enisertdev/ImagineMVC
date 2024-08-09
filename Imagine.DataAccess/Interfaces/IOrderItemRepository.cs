using Imagine.DataAccess.Entities;
using System.Linq.Expressions;

namespace Imagine.DataAccess.Interfaces
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        IEnumerable<OrderItem> GetOrders(Expression<Func<OrderItem, bool>> filter);
    }
}
