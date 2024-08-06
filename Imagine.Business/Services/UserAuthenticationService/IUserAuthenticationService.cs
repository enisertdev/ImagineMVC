using Imagine.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.Business.Services.UserAuthenticationService
{
    public interface IUserAuthenticationService
    {
        Task SignInUserAsync(User user);
        Task SignOutUserAsync();
    }
}
