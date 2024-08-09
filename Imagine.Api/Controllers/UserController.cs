using Imagine.Business.Services.UserService.UserService;
using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            
            IEnumerable<User> users = _userService.GetAllUsers();
            return Ok(users.Select(u=> new UserViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Address = u.Address,
                PhoneNumber = u.PhoneNumber,
                IsAdmin = u.IsAdmin,
                IsConfirmed = u.IsConfirmed
            }));
        }
    }
}
