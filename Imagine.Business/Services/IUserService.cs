using Imagine.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.Business.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        User GetUser(Expression<Func<User,bool>> filter);
        void UpdateUser(User user);
    }
}
