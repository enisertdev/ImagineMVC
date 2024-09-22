using System.Linq.Expressions;
using Imagine.DataAccess.Entities;

namespace Imagine.DataAccess.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<Order> GetOrders(Expression<Func<Order,bool>> filter);
        IEnumerable<Order> GetAllOrders();
        void RemoveOrder(Order order);
        Order GetOneOrder(int id);
    }
}
