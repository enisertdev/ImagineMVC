﻿// <auto-generated />
using System;
using Imagine.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Imagine.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Audio"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cameras"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Entertainment"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Networking"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Office Equipment"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Computer Accessories"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Video Conferencing"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Smart Technology"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Personal Transport"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Fitness & Outdoor"
                        },
                        new
                        {
                            Id = 12,
                            Name = "3D Printing & Lighting"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Kitchen Appliances"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Home Appliances"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Personal Care"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Cooking Appliances"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Major Appliances"
                        },
                        new
                        {
                            Id = 18,
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

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ImageUrl = "smartphone.jpg",
                            Name = "Smartphone",
                            Price = 8999.99m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            ImageUrl = "laptop.jpg",
                            Name = "Laptop",
                            Price = 14999.99m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            ImageUrl = "tablet.jpg",
                            Name = "Tablet",
                            Price = 4999.99m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            ImageUrl = "headphones.jpg",
                            Name = "Headphones",
                            Price = 1999.99m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            ImageUrl = "smartwatch.jpg",
                            Name = "Smartwatch",
                            Price = 2999.99m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            ImageUrl = "bluetooth_speaker.jpg",
                            Name = "Bluetooth Speaker",
                            Price = 899.99m
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            ImageUrl = "camera.jpg",
                            Name = "Digital Camera",
                            Price = 7499.99m
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            ImageUrl = "action_camera.jpg",
                            Name = "Action Camera",
                            Price = 1999.99m
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 4,
                            ImageUrl = "tv.jpg",
                            Name = "Television",
                            Price = 10999.99m
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 4,
                            ImageUrl = "gaming_console.jpg",
                            Name = "Gaming Console",
                            Price = 5999.99m
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 5,
                            ImageUrl = "router.jpg",
                            Name = "Router",
                            Price = 799.99m
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 5,
                            ImageUrl = "external_hard_drive.jpg",
                            Name = "External Hard Drive",
                            Price = 599.99m
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 6,
                            ImageUrl = "printer.jpg",
                            Name = "Printer",
                            Price = 1299.99m
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 6,
                            ImageUrl = "monitor.jpg",
                            Name = "Monitor",
                            Price = 2199.99m
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 7,
                            ImageUrl = "keyboard.jpg",
                            Name = "Keyboard",
                            Price = 599.99m
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 7,
                            ImageUrl = "mouse.jpg",
                            Name = "Mouse",
                            Price = 299.99m
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 8,
                            ImageUrl = "webcam.jpg",
                            Name = "Webcam",
                            Price = 499.99m
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 8,
                            ImageUrl = "microphone.jpg",
                            Name = "Microphone",
                            Price = 899.99m
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 9,
                            ImageUrl = "vr_headset.jpg",
                            Name = "VR Headset",
                            Price = 4499.99m
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 9,
                            ImageUrl = "smart_home_assistant.jpg",
                            Name = "Smart Home Assistant",
                            Price = 1499.99m
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 10,
                            ImageUrl = "electric_scooter.jpg",
                            Name = "Electric Scooter",
                            Price = 3299.99m
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 10,
                            ImageUrl = "e_reader.jpg",
                            Name = "E-reader",
                            Price = 1299.99m
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 11,
                            ImageUrl = "drone.jpg",
                            Name = "Drone",
                            Price = 3999.99m
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 11,
                            ImageUrl = "fitness_tracker.jpg",
                            Name = "Fitness Tracker",
                            Price = 799.99m
                        },
                        new
                        {
                            Id = 25,
                            CategoryId = 12,
                            ImageUrl = "3d_printer.jpg",
                            Name = "3D Printer",
                            Price = 5499.99m
                        },
                        new
                        {
                            Id = 26,
                            CategoryId = 12,
                            ImageUrl = "smart_light_bulb.jpg",
                            Name = "Smart Light Bulb",
                            Price = 199.99m
                        },
                        new
                        {
                            Id = 27,
                            CategoryId = 13,
                            ImageUrl = "coffee_maker.jpg",
                            Name = "Coffee Maker",
                            Price = 1599.99m
                        },
                        new
                        {
                            Id = 28,
                            CategoryId = 13,
                            ImageUrl = "electric_kettle.jpg",
                            Name = "Electric Kettle",
                            Price = 499.99m
                        },
                        new
                        {
                            Id = 29,
                            CategoryId = 14,
                            ImageUrl = "air_purifier.jpg",
                            Name = "Air Purifier",
                            Price = 2499.99m
                        },
                        new
                        {
                            Id = 30,
                            CategoryId = 14,
                            ImageUrl = "electric_toothbrush.jpg",
                            Name = "Electric Toothbrush",
                            Price = 699.99m
                        },
                        new
                        {
                            Id = 31,
                            CategoryId = 15,
                            ImageUrl = "hair_dryer.jpg",
                            Name = "Hair Dryer",
                            Price = 399.99m
                        },
                        new
                        {
                            Id = 32,
                            CategoryId = 15,
                            ImageUrl = "shaver.jpg",
                            Name = "Shaver",
                            Price = 899.99m
                        },
                        new
                        {
                            Id = 33,
                            CategoryId = 16,
                            ImageUrl = "blender.jpg",
                            Name = "Blender",
                            Price = 699.99m
                        },
                        new
                        {
                            Id = 34,
                            CategoryId = 16,
                            ImageUrl = "air_fryer.jpg",
                            Name = "Air Fryer",
                            Price = 1299.99m
                        },
                        new
                        {
                            Id = 35,
                            CategoryId = 17,
                            ImageUrl = "washing_machine.jpg",
                            Name = "Washing Machine",
                            Price = 5499.99m
                        },
                        new
                        {
                            Id = 36,
                            CategoryId = 17,
                            ImageUrl = "refrigerator.jpg",
                            Name = "Refrigerator",
                            Price = 7499.99m
                        },
                        new
                        {
                            Id = 37,
                            CategoryId = 17,
                            ImageUrl = "dishwasher.jpg",
                            Name = "Dishwasher",
                            Price = 4499.99m
                        },
                        new
                        {
                            Id = 38,
                            CategoryId = 18,
                            ImageUrl = "oven.jpg",
                            Name = "Oven",
                            Price = 3999.99m
                        },
                        new
                        {
                            Id = 39,
                            CategoryId = 18,
                            ImageUrl = "microwave.jpg",
                            Name = "Microwave",
                            Price = 1999.99m
                        },
                        new
                        {
                            Id = 40,
                            CategoryId = 18,
                            ImageUrl = "vacuum_cleaner.jpg",
                            Name = "Vacuum Cleaner",
                            Price = 1299.99m
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
