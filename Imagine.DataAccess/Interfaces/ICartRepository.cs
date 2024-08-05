using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;

namespace Imagine.DataAccess.Interfaces
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        IEnumerable<Cart> GetManyItems(Expression<Func<Cart, bool>> filter);
    }
}
