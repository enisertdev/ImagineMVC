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
        public DbSet<Cart> Carts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {   

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
                (
                    new Category { Id = 1, Name = "Electronics", Description = "Devices and gadgets" },
                    new Category { Id = 2, Name = "Audio", Description = "Audio equipment and accessories" },
                    new Category { Id = 3, Name = "Cameras", Description = "Digital and action cameras" },
                    new Category { Id = 4, Name = "Entertainment", Description = "Television and gaming" },
                    new Category { Id = 5, Name = "Networking", Description = "Network devices and storage" },
                    new Category { Id = 6, Name = "Office Equipment", Description = "Printers and monitors" },
                    new Category { Id = 7, Name = "Computer Accessories", Description = "Keyboards and mice" },
                    new Category { Id = 8, Name = "Video Conferencing", Description = "Webcams and microphones" },
                    new Category { Id = 9, Name = "Smart Technology", Description = "VR and smart home devices" },
                    new Category { Id = 10, Name = "Personal Transport", Description = "E-scooters and e-readers" },
                    new Category { Id = 11, Name = "Fitness & Outdoor", Description = "Drones and fitness devices" },
                    new Category { Id = 12, Name = "3D Printing & Lighting", Description = "3D printers and smart lights" },
                    new Category { Id = 13, Name = "Kitchen Appliances", Description = "Coffee makers and kettles" },
                    new Category { Id = 14, Name = "Home Appliances", Description = "Air purifiers and electric toothbrushes" },
                    new Category { Id = 15, Name = "Personal Care", Description = "Hair dryers and shavers" },
                    new Category { Id = 16, Name = "Cooking Appliances", Description = "Blenders and air fryers" },
                    new Category { Id = 17, Name = "Major Appliances", Description = "Washing machines and refrigerators" },
                    new Category { Id = 18, Name = "Home Cleaning & Cooking", Description = "Dishwashers, ovens, and microwaves" }
                );
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }
    }
}
