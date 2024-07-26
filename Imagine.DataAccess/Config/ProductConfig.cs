using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imagine.DataAccess.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(

                 new Product { Id = 1, Name = "Smartphone", Description = "Latest model smartphone with high-end features", Price = 699.99m, Stock = 50, ImageUrl = "smartphone.jpg", CategoryId = 1 },
        new Product { Id = 2, Name = "Laptop", Description = "High-performance laptop for gaming and productivity", Price = 1199.99m, Stock = 30, ImageUrl = "laptop.jpg", CategoryId = 1 },
        new Product { Id = 3, Name = "Headphones", Description = "Noise-cancelling wireless headphones", Price = 199.99m, Stock = 100, ImageUrl = "headphones.jpg", CategoryId = 1 },
        new Product { Id = 4, Name = "Smartwatch", Description = "Smartwatch with fitness tracking and notifications", Price = 249.99m, Stock = 70, ImageUrl = "smartwatch.jpg", CategoryId = 1 },
        new Product { Id = 5, Name = "Camera", Description = "DSLR camera with high-resolution lens", Price = 899.99m, Stock = 20, ImageUrl = "camera.jpg", CategoryId = 1 },
        new Product { Id = 6, Name = "T-shirt", Description = "Cotton t-shirt available in various colors", Price = 19.99m, Stock = 200, ImageUrl = "tshirt.jpg", CategoryId = 2 },
        new Product { Id = 7, Name = "Jeans", Description = "Stylish denim jeans with a modern fit", Price = 39.99m, Stock = 150, ImageUrl = "jeans.jpg", CategoryId = 2 },
        new Product { Id = 8, Name = "Jacket", Description = "Warm winter jacket with a waterproof layer", Price = 89.99m, Stock = 80, ImageUrl = "jacket.jpg", CategoryId = 2 },
        new Product { Id = 9, Name = "Sneakers", Description = "Comfortable sneakers for everyday wear", Price = 59.99m, Stock = 100, ImageUrl = "sneakers.jpg", CategoryId = 2 },
        new Product { Id = 10, Name = "Watch", Description = "Elegant wristwatch with a leather strap", Price = 149.99m, Stock = 60, ImageUrl = "watch.jpg", CategoryId = 2 },
        new Product { Id = 11, Name = "Novel", Description = "Bestselling novel with gripping plot", Price = 15.99m, Stock = 300, ImageUrl = "novel.jpg", CategoryId = 3 },
        new Product { Id = 12, Name = "Textbook", Description = "Educational textbook for university students", Price = 79.99m, Stock = 40, ImageUrl = "textbook.jpg", CategoryId = 3 },
        new Product { Id = 13, Name = "Biography", Description = "Biography of a famous historical figure", Price = 25.99m, Stock = 150, ImageUrl = "biography.jpg", CategoryId = 3 },
        new Product { Id = 14, Name = "Cookbook", Description = "Cookbook with a variety of recipes", Price = 22.99m, Stock = 80, ImageUrl = "cookbook.jpg", CategoryId = 3 },
        new Product { Id = 15, Name = "Science Fiction", Description = "Science fiction novel with an intriguing story", Price = 18.99m, Stock = 70, ImageUrl = "scifi.jpg", CategoryId = 3 },
        new Product { Id = 16, Name = "Sofa", Description = "Comfortable 3-seater sofa for living rooms", Price = 499.99m, Stock = 25, ImageUrl = "sofa.jpg", CategoryId = 4 },
        new Product { Id = 17, Name = "Lamp", Description = "Elegant lamp with adjustable brightness", Price = 59.99m, Stock = 90, ImageUrl = "lamp.jpg", CategoryId = 4 },
        new Product { Id = 18, Name = "Rug", Description = "Soft and durable area rug", Price = 149.99m, Stock = 40, ImageUrl = "rug.jpg", CategoryId = 4 },
        new Product { Id = 19, Name = "Curtains", Description = "Stylish curtains available in multiple colors", Price = 89.99m, Stock = 60, ImageUrl = "curtains.jpg", CategoryId = 4 },
        new Product { Id = 20, Name = "Coffee Table", Description = "Modern coffee table with a glass top", Price = 199.99m, Stock = 35, ImageUrl = "coffee_table.jpg", CategoryId = 4 },
        new Product { Id = 21, Name = "Tennis Racket", Description = "Professional tennis racket with high tension strings", Price = 129.99m, Stock = 40, ImageUrl = "tennis_racket.jpg", CategoryId = 5 },
        new Product { Id = 22, Name = "Football", Description = "Standard size football for practice and games", Price = 29.99m, Stock = 80, ImageUrl = "football.jpg", CategoryId = 5 },
        new Product { Id = 23, Name = "Yoga Mat", Description = "Comfortable yoga mat for practice and exercise", Price = 39.99m, Stock = 100, ImageUrl = "yoga_mat.jpg", CategoryId = 5 },
        new Product { Id = 24, Name = "Dumbbells", Description = "Adjustable dumbbells for strength training", Price = 89.99m, Stock = 50, ImageUrl = "dumbbells.jpg", CategoryId = 5 },
        new Product { Id = 25, Name = "Bicycle", Description = "Mountain bicycle with 21-speed gear", Price = 399.99m, Stock = 20, ImageUrl = "bicycle.jpg", CategoryId = 5 },
        new Product { Id = 26, Name = "Tablet", Description = "Portable tablet with high-resolution display", Price = 299.99m, Stock = 40, ImageUrl = "tablet.jpg", CategoryId = 1 },
        new Product { Id = 27, Name = "Bluetooth Speaker", Description = "Portable Bluetooth speaker with high sound quality", Price = 89.99m, Stock = 60, ImageUrl = "bluetooth_speaker.jpg", CategoryId = 1 },
        new Product { Id = 28, Name = "External Hard Drive", Description = "1TB external hard drive for data storage", Price = 99.99m, Stock = 30, ImageUrl = "external_hard_drive.jpg", CategoryId = 1 },
        new Product { Id = 29, Name = "Desk Lamp", Description = "Adjustable desk lamp with LED light", Price = 49.99m, Stock = 70, ImageUrl = "desk_lamp.jpg", CategoryId = 4 },
        new Product { Id = 30, Name = "Wall Art", Description = "Beautiful wall art for home decoration", Price = 119.99m, Stock = 25, ImageUrl = "wall_art.jpg", CategoryId = 4 }
        );
        }
    }
}
