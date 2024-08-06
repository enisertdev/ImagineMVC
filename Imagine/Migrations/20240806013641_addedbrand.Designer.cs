﻿// <auto-generated />
using System;
using Imagine.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Imagine.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240806013641_addedbrand")]
    partial class addedbrand
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Imagine.DataAccess.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Imagine.DataAccess.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Devices and gadgets",
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Audio equipment and accessories",
                            Name = "Audio"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Digital and action cameras",
                            Name = "Cameras"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Television and gaming",
                            Name = "Entertainment"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Network devices and storage",
                            Name = "Networking"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Printers and monitors",
                            Name = "Office Equipment"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Keyboards and mice",
                            Name = "Computer Accessories"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Webcams and microphones",
                            Name = "Video Conferencing"
                        },
                        new
                        {
                            Id = 9,
                            Description = "VR and smart home devices",
                            Name = "Smart Technology"
                        },
                        new
                        {
                            Id = 10,
                            Description = "E-scooters and e-readers",
                            Name = "Personal Transport"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Drones and fitness devices",
                            Name = "Fitness & Outdoor"
                        },
                        new
                        {
                            Id = 12,
                            Description = "3D printers and smart lights",
                            Name = "3D Printing & Lighting"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Coffee makers and kettles",
                            Name = "Kitchen Appliances"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Air purifiers and electric toothbrushes",
                            Name = "Home Appliances"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Hair dryers and shavers",
                            Name = "Personal Care"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Blenders and air fryers",
                            Name = "Cooking Appliances"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Washing machines and refrigerators",
                            Name = "Major Appliances"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Dishwashers, ovens, and microwaves",
                            Name = "Home Cleaning & Cooking"
                        });
                });

            modelBuilder.Entity("Imagine.DataAccess.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "High-performance smartphone",
                            ImageUrl = "smartphone.jpg",
                            Name = "Smartphone",
                            Price = 8999.99m,
                            Stock = 50
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "High-performance laptop for gaming and productivity",
                            ImageUrl = "laptop.jpg",
                            Name = "Laptop",
                            Price = 14999.99m,
                            Stock = 30
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Portable and lightweight tablet",
                            ImageUrl = "tablet.jpg",
                            Name = "Tablet",
                            Price = 4999.99m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Wireless noise-cancelling headphones",
                            ImageUrl = "headphones.jpg",
                            Name = "Headphones",
                            Price = 1999.99m,
                            Stock = 75
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Advanced smartwatch with fitness tracking",
                            ImageUrl = "smartwatch.jpg",
                            Name = "Smartwatch",
                            Price = 2999.99m,
                            Stock = 60
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "Portable Bluetooth speaker with rich sound",
                            ImageUrl = "bluetooth_speaker.jpg",
                            Name = "Bluetooth Speaker",
                            Price = 899.99m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "High-resolution digital camera",
                            ImageUrl = "camera.jpg",
                            Name = "Digital Camera",
                            Price = 7499.99m,
                            Stock = 25
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = "Waterproof action camera for adventure",
                            ImageUrl = "action_camera.jpg",
                            Name = "Action Camera",
                            Price = 1999.99m,
                            Stock = 40
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 4,
                            Description = "4K Ultra HD Smart TV",
                            ImageUrl = "tv.jpg",
                            Name = "Television",
                            Price = 10999.99m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 4,
                            Description = "Next-gen gaming console",
                            ImageUrl = "gaming_console.jpg",
                            Name = "Gaming Console",
                            Price = 5999.99m,
                            Stock = 35
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 5,
                            Description = "High-speed wireless router",
                            ImageUrl = "router.jpg",
                            Name = "Router",
                            Price = 799.99m,
                            Stock = 80
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 5,
                            Description = "1TB external hard drive for backup",
                            ImageUrl = "external_hard_drive.jpg",
                            Name = "External Hard Drive",
                            Price = 599.99m,
                            Stock = 70
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 6,
                            Description = "All-in-one wireless printer",
                            ImageUrl = "printer.jpg",
                            Name = "Printer",
                            Price = 1299.99m,
                            Stock = 55
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 6,
                            Description = "27-inch Full HD monitor",
                            ImageUrl = "monitor.jpg",
                            Name = "Monitor",
                            Price = 2199.99m,
                            Stock = 45
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 7,
                            Description = "Mechanical gaming keyboard",
                            ImageUrl = "keyboard.jpg",
                            Name = "Keyboard",
                            Price = 599.99m,
                            Stock = 90
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 7,
                            Description = "Wireless ergonomic mouse",
                            ImageUrl = "mouse.jpg",
                            Name = "Mouse",
                            Price = 299.99m,
                            Stock = 110
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 8,
                            Description = "HD webcam for streaming",
                            ImageUrl = "webcam.jpg",
                            Name = "Webcam",
                            Price = 499.99m,
                            Stock = 65
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 8,
                            Description = "Professional USB microphone",
                            ImageUrl = "microphone.jpg",
                            Name = "Microphone",
                            Price = 899.99m,
                            Stock = 50
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 9,
                            Description = "Virtual reality headset for immersive gaming",
                            ImageUrl = "vr_headset.jpg",
                            Name = "VR Headset",
                            Price = 4499.99m,
                            Stock = 30
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 9,
                            Description = "Voice-controlled smart home assistant",
                            ImageUrl = "smart_home_assistant.jpg",
                            Name = "Smart Home Assistant",
                            Price = 1499.99m,
                            Stock = 60
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 10,
                            Description = "Foldable electric scooter for urban commuting",
                            ImageUrl = "electric_scooter.jpg",
                            Name = "Electric Scooter",
                            Price = 3299.99m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 10,
                            Description = "Compact e-reader with e-ink display",
                            ImageUrl = "e_reader.jpg",
                            Name = "E-reader",
                            Price = 1299.99m,
                            Stock = 40
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 11,
                            Description = "Quadcopter drone with camera",
                            ImageUrl = "drone.jpg",
                            Name = "Drone",
                            Price = 3999.99m,
                            Stock = 25
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 11,
                            Description = "Fitness tracker with heart rate monitor",
                            ImageUrl = "fitness_tracker.jpg",
                            Name = "Fitness Tracker",
                            Price = 799.99m,
                            Stock = 70
                        },
                        new
                        {
                            Id = 25,
                            CategoryId = 12,
                            Description = "Desktop 3D printer for rapid prototyping",
                            ImageUrl = "3d_printer.jpg",
                            Name = "3D Printer",
                            Price = 5499.99m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 26,
                            CategoryId = 12,
                            Description = "Color-changing smart light bulb",
                            ImageUrl = "smart_light_bulb.jpg",
                            Name = "Smart Light Bulb",
                            Price = 199.99m,
                            Stock = 120
                        },
                        new
                        {
                            Id = 27,
                            CategoryId = 13,
                            Description = "Automatic coffee maker with grinder",
                            ImageUrl = "coffee_maker.jpg",
                            Name = "Coffee Maker",
                            Price = 1599.99m,
                            Stock = 50
                        },
                        new
                        {
                            Id = 28,
                            CategoryId = 13,
                            Description = "Stainless steel electric kettle",
                            ImageUrl = "electric_kettle.jpg",
                            Name = "Electric Kettle",
                            Price = 499.99m,
                            Stock = 80
                        },
                        new
                        {
                            Id = 29,
                            CategoryId = 14,
                            Description = "HEPA air purifier for clean air",
                            ImageUrl = "air_purifier.jpg",
                            Name = "Air Purifier",
                            Price = 2499.99m,
                            Stock = 30
                        },
                        new
                        {
                            Id = 30,
                            CategoryId = 14,
                            Description = "Rechargeable electric toothbrush",
                            ImageUrl = "electric_toothbrush.jpg",
                            Name = "Electric Toothbrush",
                            Price = 699.99m,
                            Stock = 60
                        },
                        new
                        {
                            Id = 31,
                            CategoryId = 15,
                            Description = "Professional hair dryer with ionic technology",
                            ImageUrl = "hair_dryer.jpg",
                            Name = "Hair Dryer",
                            Price = 399.99m,
                            Stock = 75
                        },
                        new
                        {
                            Id = 32,
                            CategoryId = 15,
                            Description = "Electric shaver with precision blades",
                            ImageUrl = "shaver.jpg",
                            Name = "Shaver",
                            Price = 899.99m,
                            Stock = 50
                        },
                        new
                        {
                            Id = 33,
                            CategoryId = 16,
                            Description = "High-speed blender for smoothies",
                            ImageUrl = "blender.jpg",
                            Name = "Blender",
                            Price = 699.99m,
                            Stock = 55
                        },
                        new
                        {
                            Id = 34,
                            CategoryId = 16,
                            Description = "Digital air fryer for healthy cooking",
                            ImageUrl = "air_fryer.jpg",
                            Name = "Air Fryer",
                            Price = 1299.99m,
                            Stock = 45
                        },
                        new
                        {
                            Id = 35,
                            CategoryId = 17,
                            Description = "Front-loading washing machine",
                            ImageUrl = "washing_machine.jpg",
                            Name = "Washing Machine",
                            Price = 5499.99m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 36,
                            CategoryId = 17,
                            Description = "Energy-efficient refrigerator with freezer",
                            ImageUrl = "refrigerator.jpg",
                            Name = "Refrigerator",
                            Price = 7499.99m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 37,
                            CategoryId = 17,
                            Description = "Built-in dishwasher with multiple modes",
                            ImageUrl = "dishwasher.jpg",
                            Name = "Dishwasher",
                            Price = 4499.99m,
                            Stock = 18
                        },
                        new
                        {
                            Id = 38,
                            CategoryId = 18,
                            Description = "Electric oven with convection cooking",
                            ImageUrl = "oven.jpg",
                            Name = "Oven",
                            Price = 3999.99m,
                            Stock = 22
                        },
                        new
                        {
                            Id = 39,
                            CategoryId = 18,
                            Description = "Countertop microwave with sensor cooking",
                            ImageUrl = "microwave.jpg",
                            Name = "Microwave",
                            Price = 1999.99m,
                            Stock = 30
                        },
                        new
                        {
                            Id = 40,
                            CategoryId = 18,
                            Description = "Bagless vacuum cleaner with powerful suction",
                            ImageUrl = "vacuum_cleaner.jpg",
                            Name = "Vacuum Cleaner",
                            Price = 1299.99m,
                            Stock = 40
                        });
                });

            modelBuilder.Entity("Imagine.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Imagine.DataAccess.Entities.Cart", b =>
                {
                    b.HasOne("Imagine.DataAccess.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Imagine.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Imagine.DataAccess.Entities.Product", b =>
                {
                    b.HasOne("Imagine.DataAccess.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
