using Imagine.Business.Services.UserService;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Entities.Dtos;
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDtoForRegister user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RegisterUserAsync(user);
            if (!result.success)
                return BadRequest(new { error = result.errorMessage });

            return Ok(new { message = "User registered successfully." });
        }
    }
}
