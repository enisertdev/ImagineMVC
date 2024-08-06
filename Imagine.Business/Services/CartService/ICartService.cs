using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;

namespace Imagine.Business.Services.CartService
{
    public interface ICartService
    {
        void AddItem(Product product, int userId, int Quantity = 1);
        IEnumerable<Cart> GetAllItems();
        Cart GetItem(Expression<Func<Cart, bool>> filter);
        IEnumerable<Cart> GetMany(Expression<Func<Cart, bool>> filter);
        void RemoveItem(Cart item);
        void UpdateItem(Cart item);
    }
}
