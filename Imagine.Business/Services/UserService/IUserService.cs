using System.Linq.Expressions;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Entities.Dtos;

namespace Imagine.Business.Services.UserService
{
    public interface IUserService
    {
        void AddUser(User user);
        User GetUser(Expression<Func<User, bool>> filter);
        void UpdateUser(User user);
        IEnumerable<User> GetAllUsers();
        User CheckCredentials(User user);
        UserDtoForUpdate GetOneUserToUpdate(string email);
        void RemoveUser(User user);
        User GetUserByEmail(string? email);
        Task<(bool success, string errorMessage, string confirmUrl)> RegisterUserAsync(UserDtoForRegister user);
        IEnumerable<User> GetUsers(Expression<Func<User, bool>> filter);



    }
}
