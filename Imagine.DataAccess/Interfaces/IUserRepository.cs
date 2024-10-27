using Imagine.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.DataAccess.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetUsers(Expression<Func<User, bool>> filter);
    }
}
