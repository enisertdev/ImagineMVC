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
            modelBuilder.Entity<User>().HasData
                (
                 new User
                 {
                     Id = 1,
                     UserName = "john_doe",
                     Password = "password123",
                     Email = "john.doe@example.com",
                     Name = "John Doe",
                     Address = "123 Main St, Anytown",
                     PhoneNumber = "555-123-4567",
                     IsAdmin = false
                 },
                new User
                {
                    Id = 2,
                    UserName = "jane_smith",
                    Password = "smith456",
                    Email = "jane.smith@example.com",
                    Name = "Jane Smith",
                    Address = "456 Elm St, Othertown",
                    PhoneNumber = "555-987-6543",
                    IsAdmin = true
                },
                new User
                {
                    Id = 3,
                    UserName = "admin_user",
                    Password = "adminPass",
                    Email = "admin@example.com",
                    Name = "Admin User",
                    Address = "789 Oak St, Anothercity",
                    PhoneNumber = "555-222-3333",
                    IsAdmin = true
                }
                );
            modelBuilder.Entity<Product>().HasData
                (
                 new Product
                 {
                     Id = 1,
                     Name = "Laptop",
                     Description = "High-performance laptop with SSD storage",
                     Price = 1099.99m,
                     Stock = 10,
                     ImageUrl = "laptop.jpg",
                     CategoryId = 1, // Assuming Category with Id 1 exists

                 },
                new Product
                {
                    Id = 2,
                    Name = "Smartphone",
                    Description = "Latest smartphone model with OLED display",
                    Price = 899.99m,
                    Stock = 15,
                    ImageUrl = "phone.jpg",
                    CategoryId = 1, // Assuming Category with Id 1 exists
  
                },
                new Product
                {
                    Id = 3,
                    Name = "Running Shoes",
                    Description = "Comfortable running shoes with breathable fabric",
                    Price = 79.99m,
                    Stock = 20,
                    ImageUrl = "shoes.jpg",
                    CategoryId = 2, // Assuming Category with Id 2 exists
 
                },
                new Product
                {
                    Id = 4,
                    Name = "Bookshelf",
                    Description = "Wooden bookshelf with adjustable shelves",
                    Price = 149.99m,
                    Stock = 5,
                    ImageUrl = "bookshelf.jpg",
                    CategoryId = 3, // Assuming Category with Id 3 exists

                },
                new Product
                {
                    Id = 5,
                    Name = "Digital Camera",
                    Description = "Mirrorless digital camera with 4K video recording",
                    Price = 699.99m,
                    Stock = 8,
                    ImageUrl = "camera.jpg",
                    CategoryId = 1, // Assuming Category with Id 1 exists
                }
                );
        }
    }
}
