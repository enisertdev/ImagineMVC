using Microsoft.EntityFrameworkCore;
using Imagine.DataAccess.Entities;

namespace Imagine.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
       
        }
    }
}
