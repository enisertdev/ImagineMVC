using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Imagine.Views.ViewModel
{
    public class UserViewModel
    {
        [EmailAddress(ErrorMessage = "The email you entered is invalid.")]
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = "Passwords do not match.")]
        [DisplayName("Confirm Password")]
        public string ValidatePassword { get; set; }
    }
}
