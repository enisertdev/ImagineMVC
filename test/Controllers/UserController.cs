using Imagine.Business.Services.UserService.UserService;
using Imagine.DataAccess.Entities;
using Imagine.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
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
            return Ok(users);
        }
    }
}
