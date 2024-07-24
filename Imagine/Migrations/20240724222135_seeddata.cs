using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Imagine.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { "High quality bookshelf", "bookshelf1.jpg", "Bookshelf 1", 149.99m, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 2, "Durable laptop", "laptop2.jpg", "Laptop 2", 799.99m, 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 3, "Portable smartphone", "smartphone3.jpg", "Smartphone 3", 499.99m, 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 1, "Lightweight tablet", "tablet4.jpg", "Tablet 4", 299.99m, 8 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 2, "Stylish headphones", "headphones5.jpg", "Headphones 5", 99.99m, 20 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 6, 3, "Advanced camera", "camera6.jpg", "Camera 6", 599.99m, 7 },
                    { 7, 1, "Efficient printer", "printer7.jpg", "Printer 7", 199.99m, 12 },
                    { 8, 2, "High quality monitor", "monitor8.jpg", "Monitor 8", 249.99m, 9 },
                    { 9, 3, "Ergonomic chair", "chair9.jpg", "Chair 9", 89.99m, 15 },
                    { 10, 1, "Stylish desk", "desk10.jpg", "Desk 10", 149.99m, 5 },
                    { 11, 2, "High quality bookshelf", "bookshelf11.jpg", "Bookshelf 11", 149.99m, 5 },
                    { 12, 3, "Durable laptop", "laptop12.jpg", "Laptop 12", 799.99m, 10 },
                    { 13, 1, "Portable smartphone", "smartphone13.jpg", "Smartphone 13", 499.99m, 15 },
                    { 14, 2, "Lightweight tablet", "tablet14.jpg", "Tablet 14", 299.99m, 8 },
                    { 15, 3, "Stylish headphones", "headphones15.jpg", "Headphones 15", 99.99m, 20 },
                    { 16, 1, "Advanced camera", "camera16.jpg", "Camera 16", 599.99m, 7 },
                    { 17, 2, "Efficient printer", "printer17.jpg", "Printer 17", 199.99m, 12 },
                    { 18, 3, "High quality monitor", "monitor18.jpg", "Monitor 18", 249.99m, 9 },
                    { 19, 1, "Ergonomic chair", "chair19.jpg", "Chair 19", 89.99m, 15 },
                    { 20, 2, "Stylish desk", "desk20.jpg", "Desk 20", 149.99m, 5 },
                    { 21, 3, "High quality bookshelf", "bookshelf21.jpg", "Bookshelf 21", 149.99m, 5 },
                    { 22, 1, "Durable laptop", "laptop22.jpg", "Laptop 22", 799.99m, 10 },
                    { 23, 2, "Portable smartphone", "smartphone23.jpg", "Smartphone 23", 499.99m, 15 },
                    { 24, 3, "Lightweight tablet", "tablet24.jpg", "Tablet 24", 299.99m, 8 },
                    { 25, 1, "Stylish headphones", "headphones25.jpg", "Headphones 25", 99.99m, 20 },
                    { 26, 2, "Advanced camera", "camera26.jpg", "Camera 26", 599.99m, 7 },
                    { 27, 3, "Efficient printer", "printer27.jpg", "Printer 27", 199.99m, 12 },
                    { 28, 1, "High quality monitor", "monitor28.jpg", "Monitor 28", 249.99m, 9 },
                    { 29, 2, "Ergonomic chair", "chair29.jpg", "Chair 29", 89.99m, 15 },
                    { 30, 3, "Stylish desk", "desk30.jpg", "Desk 30", 149.99m, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { "High-performance laptop with SSD storage", "laptop.jpg", "Laptop", 1099.99m, 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 1, "Latest smartphone model with OLED display", "phone.jpg", "Smartphone", 899.99m, 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 2, "Comfortable running shoes with breathable fabric", "shoes.jpg", "Running Shoes", 79.99m, 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 3, "Wooden bookshelf with adjustable shelves", "bookshelf.jpg", "Bookshelf", 149.99m, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 1, "Mirrorless digital camera with 4K video recording", "camera.jpg", "Digital Camera", 699.99m, 8 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "IsAdmin", "IsConfirmed", "Name", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown", "john.doe@example.com", false, false, "John Doe", "password123", "555-123-4567", "john_doe" },
                    { 2, "456 Elm St, Othertown", "jane.smith@example.com", true, false, "Jane Smith", "smith456", "555-987-6543", "jane_smith" },
                    { 3, "789 Oak St, Anothercity", "admin@example.com", true, false, "Admin User", "adminPass", "555-222-3333", "admin_user" }
                });
        }
    }
}
