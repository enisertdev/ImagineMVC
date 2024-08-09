using Imagine.DataAccess.Config;
using Microsoft.EntityFrameworkCore;
using Imagine.DataAccess.Entities;

namespace Imagine.Database
{
    public class ApplicationDbContext : DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Category> Categories { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
            (
                new Category { Id = 1, Name = "Electronics", },
                new Category { Id = 2, Name = "Audio", },
                new Category { Id = 3, Name = "Cameras", },
                new Category { Id = 4, Name = "Entertainment" },
                new Category { Id = 5, Name = "Networking" },
                new Category { Id = 6, Name = "Office Equipment" },
                new Category { Id = 7, Name = "Computer Accessories" },
                new Category { Id = 8, Name = "Video Conferencing" },
                new Category { Id = 9, Name = "Smart Technology" },
                new Category { Id = 10, Name = "Personal Transport" },
                new Category { Id = 11, Name = "Fitness & Outdoor" },
                new Category { Id = 12, Name = "3D Printing & Lighting" },
                new Category { Id = 13, Name = "Kitchen Appliances" },
                new Category { Id = 14, Name = "Home Appliances" },
                new Category { Id = 15, Name = "Personal Care" },
                new Category { Id = 16, Name = "Cooking Appliances" },
                new Category { Id = 17, Name = "Major Appliances" },
                new Category { Id = 18, Name = "Home Cleaning & Cooking" }
            );

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.HasOne(c => c.Parent);

            });

        }
    }
}
