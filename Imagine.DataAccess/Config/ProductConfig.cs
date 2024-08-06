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
                new Product { Id = 1, Name = "Smartphone", Price = 8999.99m, ImageUrl = "smartphone.jpg", CategoryId = 1 },
                new Product { Id = 2, Name = "Laptop", Price = 14999.99m, ImageUrl = "laptop.jpg", CategoryId = 1 },
                new Product { Id = 3, Name = "Tablet", Price = 4999.99m, ImageUrl = "tablet.jpg", CategoryId = 1 },
                new Product { Id = 4, Name = "Headphones", Price = 1999.99m, ImageUrl = "headphones.jpg", CategoryId = 2 },
                new Product { Id = 5, Name = "Smartwatch", Price = 2999.99m, ImageUrl = "smartwatch.jpg", CategoryId = 2 },
                new Product { Id = 6, Name = "Bluetooth Speaker", Price = 899.99m, ImageUrl = "bluetooth_speaker.jpg", CategoryId = 2 },
                new Product { Id = 7, Name = "Digital Camera", Price = 7499.99m, ImageUrl = "camera.jpg", CategoryId = 3 },
                new Product { Id = 8, Name = "Action Camera", Price = 1999.99m, ImageUrl = "action_camera.jpg", CategoryId = 3 },
                new Product { Id = 9, Name = "Television", Price = 10999.99m, ImageUrl = "tv.jpg", CategoryId = 4 },
                new Product { Id = 10, Name = "Gaming Console", Price = 5999.99m, ImageUrl = "gaming_console.jpg", CategoryId = 4 },
                new Product { Id = 11, Name = "Router", Price = 799.99m, ImageUrl = "router.jpg", CategoryId = 5 },
                new Product { Id = 12, Name = "External Hard Drive", Price = 599.99m, ImageUrl = "external_hard_drive.jpg", CategoryId = 5 },
                new Product { Id = 13, Name = "Printer", Price = 1299.99m, ImageUrl = "printer.jpg", CategoryId = 6 },
                new Product { Id = 14, Name = "Monitor", Price = 2199.99m, ImageUrl = "monitor.jpg", CategoryId = 6 },
                new Product { Id = 15, Name = "Keyboard", Price = 599.99m, ImageUrl = "keyboard.jpg", CategoryId = 7 },
                new Product { Id = 16, Name = "Mouse", Price = 299.99m, ImageUrl = "mouse.jpg", CategoryId = 7 },
                new Product { Id = 17, Name = "Webcam", Price = 499.99m, ImageUrl = "webcam.jpg", CategoryId = 8 },
                new Product { Id = 18, Name = "Microphone", Price = 899.99m, ImageUrl = "microphone.jpg", CategoryId = 8 },
                new Product { Id = 19, Name = "VR Headset", Price = 4499.99m, ImageUrl = "vr_headset.jpg", CategoryId = 9 },
                new Product { Id = 20, Name = "Smart Home Assistant", Price = 1499.99m, ImageUrl = "smart_home_assistant.jpg", CategoryId = 9 },
                new Product { Id = 21, Name = "Electric Scooter", Price = 3299.99m, ImageUrl = "electric_scooter.jpg", CategoryId = 10 },
                new Product { Id = 22, Name = "E-reader", Price = 1299.99m, ImageUrl = "e_reader.jpg", CategoryId = 10 },
                new Product { Id = 23, Name = "Drone", Price = 3999.99m, ImageUrl = "drone.jpg", CategoryId = 11 },
                new Product { Id = 24, Name = "Fitness Tracker", Price = 799.99m, ImageUrl = "fitness_tracker.jpg", CategoryId = 11 },
                new Product { Id = 25, Name = "3D Printer", Price = 5499.99m, ImageUrl = "3d_printer.jpg", CategoryId = 12 },
                new Product { Id = 26, Name = "Smart Light Bulb", Price = 199.99m, ImageUrl = "smart_light_bulb.jpg", CategoryId = 12 },
                new Product { Id = 27, Name = "Coffee Maker", Price = 1599.99m, ImageUrl = "coffee_maker.jpg", CategoryId = 13 },
                new Product { Id = 28, Name = "Electric Kettle", Price = 499.99m, ImageUrl = "electric_kettle.jpg", CategoryId = 13 },
                new Product { Id = 29, Name = "Air Purifier", Price = 2499.99m, ImageUrl = "air_purifier.jpg", CategoryId = 14 },
                new Product { Id = 30, Name = "Electric Toothbrush", Price = 699.99m, ImageUrl = "electric_toothbrush.jpg", CategoryId = 14 },
                new Product { Id = 31, Name = "Hair Dryer", Price = 399.99m, ImageUrl = "hair_dryer.jpg", CategoryId = 15 },
                new Product { Id = 32, Name = "Shaver", Price = 899.99m, ImageUrl = "shaver.jpg", CategoryId = 15 },
                new Product { Id = 33, Name = "Blender", Price = 699.99m, ImageUrl = "blender.jpg", CategoryId = 16 },
                new Product { Id = 34, Name = "Air Fryer", Price = 1299.99m, ImageUrl = "air_fryer.jpg", CategoryId = 16 },
                new Product { Id = 35, Name = "Washing Machine", Price = 5499.99m, ImageUrl = "washing_machine.jpg", CategoryId = 17 },
                new Product { Id = 36, Name = "Refrigerator", Price = 7499.99m, ImageUrl = "refrigerator.jpg", CategoryId = 17 },
                new Product { Id = 37, Name = "Dishwasher", Price = 4499.99m, ImageUrl = "dishwasher.jpg", CategoryId = 17 },
                new Product { Id = 38, Name = "Oven", Price = 3999.99m, ImageUrl = "oven.jpg", CategoryId = 18 },
                new Product { Id = 39, Name = "Microwave", Price = 1999.99m, ImageUrl = "microwave.jpg", CategoryId = 18 },
                new Product { Id = 40, Name = "Vacuum Cleaner", Price = 1299.99m, ImageUrl = "vacuum_cleaner.jpg", CategoryId = 18 }
            );
        }
    }

}
