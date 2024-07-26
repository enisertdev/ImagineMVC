using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Imagine.Views.ViewModel
{
    public class UserViewModel
    {
        [EmailAddress(ErrorMessage = "The email you entered is invalid.")]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [MinLength(8,ErrorMessage = "Password length must be minimum of 8 characters.")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = "Passwords do not match.")]
        [DisplayName("Confirm Password")]
        public string ValidatePassword { get; set; }
    }
}
