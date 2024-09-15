using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;

namespace Imagine.Business.Services.OrderService
{
    public interface IOrderService
    {
        public void Create(Order  order);
        IEnumerable<Order> GetOrders(Expression<Func<Order, bool>> filter);
        Order GetOneOrder(Expression<Func<Order, bool>> filter);
        IEnumerable<Order> GetAllOrders();
        void UpdateOrder(Order order);
        void RemoveOrder(Order order);

    }
}
