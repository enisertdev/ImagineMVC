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
    [Migration("20240724222544_upd")]
    partial class upd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                            Description = "Apparel and fashion items",
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Literature and educational materials",
                            Name = "Books"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Items for interior decoration",
                            Name = "Home Decor"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Gear and supplies for sports",
                            Name = "Sports Equipment"
                        });
                });

            modelBuilder.Entity("Imagine.DataAccess.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                            Description = "High quality bookshelf",
                            ImageUrl = "bookshelf1.jpg",
                            Name = "Bookshelf 1",
                            Price = 149.99m,
                            Stock = 5
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Durable laptop",
                            ImageUrl = "laptop2.jpg",
                            Name = "Laptop 2",
                            Price = 799.99m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Portable smartphone",
                            ImageUrl = "smartphone3.jpg",
                            Name = "Smartphone 3",
                            Price = 499.99m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "Lightweight tablet",
                            ImageUrl = "tablet4.jpg",
                            Name = "Tablet 4",
                            Price = 299.99m,
                            Stock = 8
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Stylish headphones",
                            ImageUrl = "headphones5.jpg",
                            Name = "Headphones 5",
                            Price = 99.99m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "Advanced camera",
                            ImageUrl = "camera6.jpg",
                            Name = "Camera 6",
                            Price = 599.99m,
                            Stock = 7
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Description = "Efficient printer",
                            ImageUrl = "printer7.jpg",
                            Name = "Printer 7",
                            Price = 199.99m,
                            Stock = 12
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Description = "High quality monitor",
                            ImageUrl = "monitor8.jpg",
                            Name = "Monitor 8",
                            Price = 249.99m,
                            Stock = 9
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Description = "Ergonomic chair",
                            ImageUrl = "chair9.jpg",
                            Name = "Chair 9",
                            Price = 89.99m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            Description = "Stylish desk",
                            ImageUrl = "desk10.jpg",
                            Name = "Desk 10",
                            Price = 149.99m,
                            Stock = 5
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 2,
                            Description = "High quality bookshelf",
                            ImageUrl = "bookshelf11.jpg",
                            Name = "Bookshelf 11",
                            Price = 149.99m,
                            Stock = 5
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            Description = "Durable laptop",
                            ImageUrl = "laptop12.jpg",
                            Name = "Laptop 12",
                            Price = 799.99m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 1,
                            Description = "Portable smartphone",
                            ImageUrl = "smartphone13.jpg",
                            Name = "Smartphone 13",
                            Price = 499.99m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 2,
                            Description = "Lightweight tablet",
                            ImageUrl = "tablet14.jpg",
                            Name = "Tablet 14",
                            Price = 299.99m,
                            Stock = 8
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 3,
                            Description = "Stylish headphones",
                            ImageUrl = "headphones15.jpg",
                            Name = "Headphones 15",
                            Price = 99.99m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 1,
                            Description = "Advanced camera",
                            ImageUrl = "camera16.jpg",
                            Name = "Camera 16",
                            Price = 599.99m,
                            Stock = 7
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 2,
                            Description = "Efficient printer",
                            ImageUrl = "printer17.jpg",
                            Name = "Printer 17",
                            Price = 199.99m,
                            Stock = 12
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 3,
                            Description = "High quality monitor",
                            ImageUrl = "monitor18.jpg",
                            Name = "Monitor 18",
                            Price = 249.99m,
                            Stock = 9
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 1,
                            Description = "Ergonomic chair",
                            ImageUrl = "chair19.jpg",
                            Name = "Chair 19",
                            Price = 89.99m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 2,
                            Description = "Stylish desk",
                            ImageUrl = "desk20.jpg",
                            Name = "Desk 20",
                            Price = 149.99m,
                            Stock = 5
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 3,
                            Description = "High quality bookshelf",
                            ImageUrl = "bookshelf21.jpg",
                            Name = "Bookshelf 21",
                            Price = 149.99m,
                            Stock = 5
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 1,
                            Description = "Durable laptop",
                            ImageUrl = "laptop22.jpg",
                            Name = "Laptop 22",
                            Price = 799.99m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 2,
                            Description = "Portable smartphone",
                            ImageUrl = "smartphone23.jpg",
                            Name = "Smartphone 23",
                            Price = 499.99m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 3,
                            Description = "Lightweight tablet",
                            ImageUrl = "tablet24.jpg",
                            Name = "Tablet 24",
                            Price = 299.99m,
                            Stock = 8
                        },
                        new
                        {
                            Id = 25,
                            CategoryId = 1,
                            Description = "Stylish headphones",
                            ImageUrl = "headphones25.jpg",
                            Name = "Headphones 25",
                            Price = 99.99m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 26,
                            CategoryId = 2,
                            Description = "Advanced camera",
                            ImageUrl = "camera26.jpg",
                            Name = "Camera 26",
                            Price = 599.99m,
                            Stock = 7
                        },
                        new
                        {
                            Id = 27,
                            CategoryId = 3,
                            Description = "Efficient printer",
                            ImageUrl = "printer27.jpg",
                            Name = "Printer 27",
                            Price = 199.99m,
                            Stock = 12
                        },
                        new
                        {
                            Id = 28,
                            CategoryId = 1,
                            Description = "High quality monitor",
                            ImageUrl = "monitor28.jpg",
                            Name = "Monitor 28",
                            Price = 249.99m,
                            Stock = 9
                        },
                        new
                        {
                            Id = 29,
                            CategoryId = 2,
                            Description = "Ergonomic chair",
                            ImageUrl = "chair29.jpg",
                            Name = "Chair 29",
                            Price = 89.99m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 30,
                            CategoryId = 3,
                            Description = "Stylish desk",
                            ImageUrl = "desk30.jpg",
                            Name = "Desk 30",
                            Price = 149.99m,
                            Stock = 5
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
