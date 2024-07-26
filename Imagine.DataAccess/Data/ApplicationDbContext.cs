using Imagine.DataAccess.Config;
using Microsoft.EntityFrameworkCore;
using Imagine.DataAccess.Entities;

namespace Imagine.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
                (
                 new Category { Id = 1, Name = "Electronics", Description = "Devices and gadgets" },
                new Category { Id = 2, Name = "Clothing", Description = "Apparel and fashion items" },
                new Category { Id = 3, Name = "Books", Description = "Literature and educational materials" },
                new Category { Id = 4, Name = "Home Decor", Description = "Items for interior decoration" },
                new Category { Id = 5, Name = "Sports Equipment", Description = "Gear and supplies for sports" }
                );
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }
    }
}
