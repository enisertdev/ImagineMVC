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

              new Product { Id = 1, Name = "Smartphone", Description = "High-performance smartphone", Price = 8999.99m, Stock = 50, ImageUrl = "smartphone.jpg", CategoryId = 1 },
    new Product { Id = 2, Name = "Laptop", Description = "High-performance laptop for gaming and productivity", Price = 14999.99m, Stock = 30, ImageUrl = "laptop.jpg", CategoryId = 1 },
    new Product { Id = 3, Name = "Tablet", Description = "Portable and lightweight tablet", Price = 4999.99m, Stock = 20, ImageUrl = "tablet.jpg", CategoryId = 1 },
    new Product { Id = 4, Name = "Headphones", Description = "Wireless noise-cancelling headphones", Price = 1999.99m, Stock = 75, ImageUrl = "headphones.jpg", CategoryId = 2 },
    new Product { Id = 5, Name = "Smartwatch", Description = "Advanced smartwatch with fitness tracking", Price = 2999.99m, Stock = 60, ImageUrl = "smartwatch.jpg", CategoryId = 2 },
    new Product { Id = 6, Name = "Bluetooth Speaker", Description = "Portable Bluetooth speaker with rich sound", Price = 899.99m, Stock = 100, ImageUrl = "bluetooth_speaker.jpg", CategoryId = 2 },
    new Product { Id = 7, Name = "Digital Camera", Description = "High-resolution digital camera", Price = 7499.99m, Stock = 25, ImageUrl = "camera.jpg", CategoryId = 3 },
    new Product { Id = 8, Name = "Action Camera", Description = "Waterproof action camera for adventure", Price = 1999.99m, Stock = 40, ImageUrl = "action_camera.jpg", CategoryId = 3 },
    new Product { Id = 9, Name = "Television", Description = "4K Ultra HD Smart TV", Price = 10999.99m, Stock = 15, ImageUrl = "tv.jpg", CategoryId = 4 },
    new Product { Id = 10, Name = "Gaming Console", Description = "Next-gen gaming console", Price = 5999.99m, Stock = 35, ImageUrl = "gaming_console.jpg", CategoryId = 4 },
    new Product { Id = 11, Name = "Router", Description = "High-speed wireless router", Price = 799.99m, Stock = 80, ImageUrl = "router.jpg", CategoryId = 5 },
    new Product { Id = 12, Name = "External Hard Drive", Description = "1TB external hard drive for backup", Price = 599.99m, Stock = 70, ImageUrl = "external_hard_drive.jpg", CategoryId = 5 },
    new Product { Id = 13, Name = "Printer", Description = "All-in-one wireless printer", Price = 1299.99m, Stock = 55, ImageUrl = "printer.jpg", CategoryId = 6 },
    new Product { Id = 14, Name = "Monitor", Description = "27-inch Full HD monitor", Price = 2199.99m, Stock = 45, ImageUrl = "monitor.jpg", CategoryId = 6 },
    new Product { Id = 15, Name = "Keyboard", Description = "Mechanical gaming keyboard", Price = 599.99m, Stock = 90, ImageUrl = "keyboard.jpg", CategoryId = 7 },
    new Product { Id = 16, Name = "Mouse", Description = "Wireless ergonomic mouse", Price = 299.99m, Stock = 110, ImageUrl = "mouse.jpg", CategoryId = 7 },
    new Product { Id = 17, Name = "Webcam", Description = "HD webcam for streaming", Price = 499.99m, Stock = 65, ImageUrl = "webcam.jpg", CategoryId = 8 },
    new Product { Id = 18, Name = "Microphone", Description = "Professional USB microphone", Price = 899.99m, Stock = 50, ImageUrl = "microphone.jpg", CategoryId = 8 },
    new Product { Id = 19, Name = "VR Headset", Description = "Virtual reality headset for immersive gaming", Price = 4499.99m, Stock = 30, ImageUrl = "vr_headset.jpg", CategoryId = 9 },
    new Product { Id = 20, Name = "Smart Home Assistant", Description = "Voice-controlled smart home assistant", Price = 1499.99m, Stock = 60, ImageUrl = "smart_home_assistant.jpg", CategoryId = 9 },
    new Product { Id = 21, Name = "Electric Scooter", Description = "Foldable electric scooter for urban commuting", Price = 3299.99m, Stock = 20, ImageUrl = "electric_scooter.jpg", CategoryId = 10 },
    new Product { Id = 22, Name = "E-reader", Description = "Compact e-reader with e-ink display", Price = 1299.99m, Stock = 40, ImageUrl = "e_reader.jpg", CategoryId = 10 },
    new Product { Id = 23, Name = "Drone", Description = "Quadcopter drone with camera", Price = 3999.99m, Stock = 25, ImageUrl = "drone.jpg", CategoryId = 11 },
    new Product { Id = 24, Name = "Fitness Tracker", Description = "Fitness tracker with heart rate monitor", Price = 799.99m, Stock = 70, ImageUrl = "fitness_tracker.jpg", CategoryId = 11 },
    new Product { Id = 25, Name = "3D Printer", Description = "Desktop 3D printer for rapid prototyping", Price = 5499.99m, Stock = 10, ImageUrl = "3d_printer.jpg", CategoryId = 12 },
    new Product { Id = 26, Name = "Smart Light Bulb", Description = "Color-changing smart light bulb", Price = 199.99m, Stock = 120, ImageUrl = "smart_light_bulb.jpg", CategoryId = 12 },
    new Product { Id = 27, Name = "Coffee Maker", Description = "Automatic coffee maker with grinder", Price = 1599.99m, Stock = 50, ImageUrl = "coffee_maker.jpg", CategoryId = 13 },
    new Product { Id = 28, Name = "Electric Kettle", Description = "Stainless steel electric kettle", Price = 499.99m, Stock = 80, ImageUrl = "electric_kettle.jpg", CategoryId = 13 },
    new Product { Id = 29, Name = "Air Purifier", Description = "HEPA air purifier for clean air", Price = 2499.99m, Stock = 30, ImageUrl = "air_purifier.jpg", CategoryId = 14 },
    new Product { Id = 30, Name = "Electric Toothbrush", Description = "Rechargeable electric toothbrush", Price = 699.99m, Stock = 60, ImageUrl = "electric_toothbrush.jpg", CategoryId = 14 },
    new Product { Id = 31, Name = "Hair Dryer", Description = "Professional hair dryer with ionic technology", Price = 399.99m, Stock = 75, ImageUrl = "hair_dryer.jpg", CategoryId = 15 },
    new Product { Id = 32, Name = "Shaver", Description = "Electric shaver with precision blades", Price = 899.99m, Stock = 50, ImageUrl = "shaver.jpg", CategoryId = 15 },
    new Product { Id = 33, Name = "Blender", Description = "High-speed blender for smoothies", Price = 699.99m, Stock = 55, ImageUrl = "blender.jpg", CategoryId = 16 },
    new Product { Id = 34, Name = "Air Fryer", Description = "Digital air fryer for healthy cooking", Price = 1299.99m, Stock = 45, ImageUrl = "air_fryer.jpg", CategoryId = 16 },
    new Product { Id = 35, Name = "Washing Machine", Description = "Front-loading washing machine", Price = 5499.99m, Stock = 20, ImageUrl = "washing_machine.jpg", CategoryId = 17 },
    new Product { Id = 36, Name = "Refrigerator", Description = "Energy-efficient refrigerator with freezer", Price = 7499.99m, Stock = 15, ImageUrl = "refrigerator.jpg", CategoryId = 17 },
    new Product { Id = 37, Name = "Dishwasher", Description = "Built-in dishwasher with multiple modes", Price = 4499.99m, Stock = 18, ImageUrl = "dishwasher.jpg", CategoryId = 17 },
    new Product { Id = 38, Name = "Oven", Description = "Electric oven with convection cooking", Price = 3999.99m, Stock = 22, ImageUrl = "oven.jpg", CategoryId = 18 },
    new Product { Id = 39, Name = "Microwave", Description = "Countertop microwave with sensor cooking", Price = 1999.99m, Stock = 30, ImageUrl = "microwave.jpg", CategoryId = 18 },
    new Product { Id = 40, Name = "Vacuum Cleaner", Description = "Bagless vacuum cleaner with powerful suction", Price = 1299.99m, Stock = 40, ImageUrl = "vacuum_cleaner.jpg", CategoryId = 18 }
        );
        }
    }
}
