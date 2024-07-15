﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Imagine.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "High-performance laptop with SSD storage", "laptop.jpg", "Laptop", 1099.99m, 10 },
                    { 2, 1, "Latest smartphone model with OLED display", "phone.jpg", "Smartphone", 899.99m, 15 },
                    { 3, 2, "Comfortable running shoes with breathable fabric", "shoes.jpg", "Running Shoes", 79.99m, 20 },
                    { 4, 3, "Wooden bookshelf with adjustable shelves", "bookshelf.jpg", "Bookshelf", 149.99m, 5 },
                    { 5, 1, "Mirrorless digital camera with 4K video recording", "camera.jpg", "Digital Camera", 699.99m, 8 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "IsAdmin", "Name", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown", "john.doe@example.com", false, "John Doe", "password123", "555-123-4567", "john_doe" },
                    { 2, "456 Elm St, Othertown", "jane.smith@example.com", true, "Jane Smith", "smith456", "555-987-6543", "jane_smith" },
                    { 3, "789 Oak St, Anothercity", "admin@example.com", true, "Admin User", "adminPass", "555-222-3333", "admin_user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
