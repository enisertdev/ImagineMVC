using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.DataAccess.Entities.Dtos
{
    public class UserDtoForRegister
    {
        public int Id { get; set; }
        [EmailAddress(ErrorMessage = "The email you entered is invalid.")]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [MinLength(8, ErrorMessage = "Password length must be minimum of 8 characters.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Validate Password field cannot be empty!")]
        public string ValidatePassword { get; set; }
    }
}
