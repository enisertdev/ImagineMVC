using Imagine.DataAccess.Entities;
using System.Linq.Expressions;

namespace Imagine.DataAccess.Interfaces
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        IEnumerable<OrderItem> GetOrders(Expression<Func<OrderItem, bool>> filter);
        OrderItem GetOneOrderItemById(int id);
        OrderItem GetOneOrderItem(Expression<Func<OrderItem, bool>> filter);
    }
}
