using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Imagine.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    { 2, "Audio equipment and accessories", "Audio" },
                    { 3, "Digital and action cameras", "Cameras" },
                    { 4, "Television and gaming", "Entertainment" },
                    { 5, "Network devices and storage", "Networking" },
                    { 6, "Printers and monitors", "Office Equipment" },
                    { 7, "Keyboards and mice", "Computer Accessories" },
                    { 8, "Webcams and microphones", "Video Conferencing" },
                    { 9, "VR and smart home devices", "Smart Technology" },
                    { 10, "E-scooters and e-readers", "Personal Transport" },
                    { 11, "Drones and fitness devices", "Fitness & Outdoor" },
                    { 12, "3D printers and smart lights", "3D Printing & Lighting" },
                    { 13, "Coffee makers and kettles", "Kitchen Appliances" },
                    { 14, "Air purifiers and electric toothbrushes", "Home Appliances" },
                    { 15, "Hair dryers and shavers", "Personal Care" },
                    { 16, "Blenders and air fryers", "Cooking Appliances" },
                    { 17, "Washing machines and refrigerators", "Major Appliances" },
                    { 18, "Dishwashers, ovens, and microwaves", "Home Cleaning & Cooking" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "High-performance smartphone", "smartphone.jpg", "Smartphone", 8999.99m, 50 },
                    { 2, 1, "High-performance laptop for gaming and productivity", "laptop.jpg", "Laptop", 14999.99m, 30 },
                    { 3, 1, "Portable and lightweight tablet", "tablet.jpg", "Tablet", 4999.99m, 20 },
                    { 4, 2, "Wireless noise-cancelling headphones", "headphones.jpg", "Headphones", 1999.99m, 75 },
                    { 5, 2, "Advanced smartwatch with fitness tracking", "smartwatch.jpg", "Smartwatch", 2999.99m, 60 },
                    { 6, 2, "Portable Bluetooth speaker with rich sound", "bluetooth_speaker.jpg", "Bluetooth Speaker", 899.99m, 100 },
                    { 7, 3, "High-resolution digital camera", "camera.jpg", "Digital Camera", 7499.99m, 25 },
                    { 8, 3, "Waterproof action camera for adventure", "action_camera.jpg", "Action Camera", 1999.99m, 40 },
                    { 9, 4, "4K Ultra HD Smart TV", "tv.jpg", "Television", 10999.99m, 15 },
                    { 10, 4, "Next-gen gaming console", "gaming_console.jpg", "Gaming Console", 5999.99m, 35 },
                    { 11, 5, "High-speed wireless router", "router.jpg", "Router", 799.99m, 80 },
                    { 12, 5, "1TB external hard drive for backup", "external_hard_drive.jpg", "External Hard Drive", 599.99m, 70 },
                    { 13, 6, "All-in-one wireless printer", "printer.jpg", "Printer", 1299.99m, 55 },
                    { 14, 6, "27-inch Full HD monitor", "monitor.jpg", "Monitor", 2199.99m, 45 },
                    { 15, 7, "Mechanical gaming keyboard", "keyboard.jpg", "Keyboard", 599.99m, 90 },
                    { 16, 7, "Wireless ergonomic mouse", "mouse.jpg", "Mouse", 299.99m, 110 },
                    { 17, 8, "HD webcam for streaming", "webcam.jpg", "Webcam", 499.99m, 65 },
                    { 18, 8, "Professional USB microphone", "microphone.jpg", "Microphone", 899.99m, 50 },
                    { 19, 9, "Virtual reality headset for immersive gaming", "vr_headset.jpg", "VR Headset", 4499.99m, 30 },
                    { 20, 9, "Voice-controlled smart home assistant", "smart_home_assistant.jpg", "Smart Home Assistant", 1499.99m, 60 },
                    { 21, 10, "Foldable electric scooter for urban commuting", "electric_scooter.jpg", "Electric Scooter", 3299.99m, 20 },
                    { 22, 10, "Compact e-reader with e-ink display", "e_reader.jpg", "E-reader", 1299.99m, 40 },
                    { 23, 11, "Quadcopter drone with camera", "drone.jpg", "Drone", 3999.99m, 25 },
                    { 24, 11, "Fitness tracker with heart rate monitor", "fitness_tracker.jpg", "Fitness Tracker", 799.99m, 70 },
                    { 25, 12, "Desktop 3D printer for rapid prototyping", "3d_printer.jpg", "3D Printer", 5499.99m, 10 },
                    { 26, 12, "Color-changing smart light bulb", "smart_light_bulb.jpg", "Smart Light Bulb", 199.99m, 120 },
                    { 27, 13, "Automatic coffee maker with grinder", "coffee_maker.jpg", "Coffee Maker", 1599.99m, 50 },
                    { 28, 13, "Stainless steel electric kettle", "electric_kettle.jpg", "Electric Kettle", 499.99m, 80 },
                    { 29, 14, "HEPA air purifier for clean air", "air_purifier.jpg", "Air Purifier", 2499.99m, 30 },
                    { 30, 14, "Rechargeable electric toothbrush", "electric_toothbrush.jpg", "Electric Toothbrush", 699.99m, 60 },
                    { 31, 15, "Professional hair dryer with ionic technology", "hair_dryer.jpg", "Hair Dryer", 399.99m, 75 },
                    { 32, 15, "Electric shaver with precision blades", "shaver.jpg", "Shaver", 899.99m, 50 },
                    { 33, 16, "High-speed blender for smoothies", "blender.jpg", "Blender", 699.99m, 55 },
                    { 34, 16, "Digital air fryer for healthy cooking", "air_fryer.jpg", "Air Fryer", 1299.99m, 45 },
                    { 35, 17, "Front-loading washing machine", "washing_machine.jpg", "Washing Machine", 5499.99m, 20 },
                    { 36, 17, "Energy-efficient refrigerator with freezer", "refrigerator.jpg", "Refrigerator", 7499.99m, 15 },
                    { 37, 17, "Built-in dishwasher with multiple modes", "dishwasher.jpg", "Dishwasher", 4499.99m, 18 },
                    { 38, 18, "Electric oven with convection cooking", "oven.jpg", "Oven", 3999.99m, 22 },
                    { 39, 18, "Countertop microwave with sensor cooking", "microwave.jpg", "Microwave", 1999.99m, 30 },
                    { 40, 18, "Bagless vacuum cleaner with powerful suction", "vacuum_cleaner.jpg", "Vacuum Cleaner", 1299.99m, 40 }
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
