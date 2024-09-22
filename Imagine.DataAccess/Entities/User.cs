using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal Amount { get; set; } = 0;
        public bool IsAdmin { get; set; } = false;
        public bool IsConfirmed { get; set; } = false;
    }
}
