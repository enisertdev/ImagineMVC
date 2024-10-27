using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using Imagine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers(Expression<Func<User, bool>> filter)
        {
            return _context.Users.Where(filter).ToList();
        }
    }
}
