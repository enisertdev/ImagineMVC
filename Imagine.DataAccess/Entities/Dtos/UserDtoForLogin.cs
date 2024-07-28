using Imagine.DataAccess.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Imagine.DataAccess.Entities.Dtos
{
    public class UserDtoForLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }   
}
