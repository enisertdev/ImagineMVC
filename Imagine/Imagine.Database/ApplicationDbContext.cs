using Microsoft.EntityFrameworkCore;

namespace Imagine.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
       
        }
    }
}
