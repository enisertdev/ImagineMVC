using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;

namespace Imagine.Business.Services.OrderItemService
{
    public interface IOrderItemService
    {
        void Create(OrderItem  item);
        IEnumerable<OrderItem> GetOrders(Expression<Func<OrderItem, bool>> filter);
    }
}
