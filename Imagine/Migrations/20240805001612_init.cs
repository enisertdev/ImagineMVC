using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Imagine.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Devices and gadgets", "Electronics" },
                    { 2, "Apparel and fashion items", "Clothing" },
                    { 3, "Literature and educational materials", "Books" },
                    { 4, "Items for interior decoration", "Home Decor" },
                    { 5, "Gear and supplies for sports", "Sports Equipment" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Latest model smartphone with high-end features", "smartphone.jpg", "Smartphone", 699.99m, 50 },
                    { 2, 1, "High-performance laptop for gaming and productivity", "laptop.jpg", "Laptop", 1199.99m, 30 },
                    { 3, 1, "Noise-cancelling wireless headphones", "headphones.jpg", "Headphones", 199.99m, 100 },
                    { 4, 1, "Smartwatch with fitness tracking and notifications", "smartwatch.jpg", "Smartwatch", 249.99m, 70 },
                    { 5, 1, "DSLR camera with high-resolution lens", "camera.jpg", "Camera", 899.99m, 20 },
                    { 6, 2, "Cotton t-shirt available in various colors", "tshirt.jpg", "T-shirt", 19.99m, 200 },
                    { 7, 2, "Stylish denim jeans with a modern fit", "jeans.jpg", "Jeans", 39.99m, 150 },
                    { 8, 2, "Warm winter jacket with a waterproof layer", "jacket.jpg", "Jacket", 89.99m, 80 },
                    { 9, 2, "Comfortable sneakers for everyday wear", "sneakers.jpg", "Sneakers", 59.99m, 100 },
                    { 10, 2, "Elegant wristwatch with a leather strap", "watch.jpg", "Watch", 149.99m, 60 },
                    { 11, 3, "Bestselling novel with gripping plot", "novel.jpg", "Novel", 15.99m, 300 },
                    { 12, 3, "Educational textbook for university students", "textbook.jpg", "Textbook", 79.99m, 40 },
                    { 13, 3, "Biography of a famous historical figure", "biography.jpg", "Biography", 25.99m, 150 },
                    { 14, 3, "Cookbook with a variety of recipes", "cookbook.jpg", "Cookbook", 22.99m, 80 },
                    { 15, 3, "Science fiction novel with an intriguing story", "scifi.jpg", "Science Fiction", 18.99m, 70 },
                    { 16, 4, "Comfortable 3-seater sofa for living rooms", "sofa.jpg", "Sofa", 499.99m, 25 },
                    { 17, 4, "Elegant lamp with adjustable brightness", "lamp.jpg", "Lamp", 59.99m, 90 },
                    { 18, 4, "Soft and durable area rug", "rug.jpg", "Rug", 149.99m, 40 },
                    { 19, 4, "Stylish curtains available in multiple colors", "curtains.jpg", "Curtains", 89.99m, 60 },
                    { 20, 4, "Modern coffee table with a glass top", "coffee_table.jpg", "Coffee Table", 199.99m, 35 },
                    { 21, 5, "Professional tennis racket with high tension strings", "tennis_racket.jpg", "Tennis Racket", 129.99m, 40 },
                    { 22, 5, "Standard size football for practice and games", "football.jpg", "Football", 29.99m, 80 },
                    { 23, 5, "Comfortable yoga mat for practice and exercise", "yoga_mat.jpg", "Yoga Mat", 39.99m, 100 },
                    { 24, 5, "Adjustable dumbbells for strength training", "dumbbells.jpg", "Dumbbells", 89.99m, 50 },
                    { 25, 5, "Mountain bicycle with 21-speed gear", "bicycle.jpg", "Bicycle", 399.99m, 20 },
                    { 26, 1, "Portable tablet with high-resolution display", "tablet.jpg", "Tablet", 299.99m, 40 },
                    { 27, 1, "Portable Bluetooth speaker with high sound quality", "bluetooth_speaker.jpg", "Bluetooth Speaker", 89.99m, 60 },
                    { 28, 1, "1TB external hard drive for data storage", "external_hard_drive.jpg", "External Hard Drive", 99.99m, 30 },
                    { 29, 4, "Adjustable desk lamp with LED light", "desk_lamp.jpg", "Desk Lamp", 49.99m, 70 },
                    { 30, 4, "Beautiful wall art for home decoration", "wall_art.jpg", "Wall Art", 119.99m, 25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
