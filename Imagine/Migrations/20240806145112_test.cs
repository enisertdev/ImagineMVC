using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Imagine.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Products",
                newName: "Storage");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Processor");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Products",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Ram",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Discriminator", "ImageUrl", "Name", "Price", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, 1, "Product", "smartphone.jpg", "Smartphone", 8999.99m, null },
                    { 2, 1, "Product", "laptop.jpg", "Laptop", 14999.99m, null },
                    { 3, 1, "Product", "tablet.jpg", "Tablet", 4999.99m, null },
                    { 4, 2, "Product", "headphones.jpg", "Headphones", 1999.99m, null },
                    { 5, 2, "Product", "smartwatch.jpg", "Smartwatch", 2999.99m, null },
                    { 6, 2, "Product", "bluetooth_speaker.jpg", "Bluetooth Speaker", 899.99m, null },
                    { 7, 3, "Product", "camera.jpg", "Digital Camera", 7499.99m, null },
                    { 8, 3, "Product", "action_camera.jpg", "Action Camera", 1999.99m, null },
                    { 9, 4, "Product", "tv.jpg", "Television", 10999.99m, null },
                    { 10, 4, "Product", "gaming_console.jpg", "Gaming Console", 5999.99m, null },
                    { 11, 5, "Product", "router.jpg", "Router", 799.99m, null },
                    { 12, 5, "Product", "external_hard_drive.jpg", "External Hard Drive", 599.99m, null },
                    { 13, 6, "Product", "printer.jpg", "Printer", 1299.99m, null },
                    { 14, 6, "Product", "monitor.jpg", "Monitor", 2199.99m, null },
                    { 15, 7, "Product", "keyboard.jpg", "Keyboard", 599.99m, null },
                    { 16, 7, "Product", "mouse.jpg", "Mouse", 299.99m, null },
                    { 17, 8, "Product", "webcam.jpg", "Webcam", 499.99m, null },
                    { 18, 8, "Product", "microphone.jpg", "Microphone", 899.99m, null },
                    { 19, 9, "Product", "vr_headset.jpg", "VR Headset", 4499.99m, null },
                    { 20, 9, "Product", "smart_home_assistant.jpg", "Smart Home Assistant", 1499.99m, null },
                    { 21, 10, "Product", "electric_scooter.jpg", "Electric Scooter", 3299.99m, null },
                    { 22, 10, "Product", "e_reader.jpg", "E-reader", 1299.99m, null },
                    { 23, 11, "Product", "drone.jpg", "Drone", 3999.99m, null },
                    { 24, 11, "Product", "fitness_tracker.jpg", "Fitness Tracker", 799.99m, null },
                    { 25, 12, "Product", "3d_printer.jpg", "3D Printer", 5499.99m, null },
                    { 26, 12, "Product", "smart_light_bulb.jpg", "Smart Light Bulb", 199.99m, null },
                    { 27, 13, "Product", "coffee_maker.jpg", "Coffee Maker", 1599.99m, null },
                    { 28, 13, "Product", "electric_kettle.jpg", "Electric Kettle", 499.99m, null },
                    { 29, 14, "Product", "air_purifier.jpg", "Air Purifier", 2499.99m, null },
                    { 30, 14, "Product", "electric_toothbrush.jpg", "Electric Toothbrush", 699.99m, null },
                    { 31, 15, "Product", "hair_dryer.jpg", "Hair Dryer", 399.99m, null },
                    { 32, 15, "Product", "shaver.jpg", "Shaver", 899.99m, null },
                    { 33, 16, "Product", "blender.jpg", "Blender", 699.99m, null },
                    { 34, 16, "Product", "air_fryer.jpg", "Air Fryer", 1299.99m, null },
                    { 35, 17, "Product", "washing_machine.jpg", "Washing Machine", 5499.99m, null },
                    { 36, 17, "Product", "refrigerator.jpg", "Refrigerator", 7499.99m, null },
                    { 37, 17, "Product", "dishwasher.jpg", "Dishwasher", 4499.99m, null },
                    { 38, 18, "Product", "oven.jpg", "Oven", 3999.99m, null },
                    { 39, 18, "Product", "microwave.jpg", "Microwave", 1999.99m, null },
                    { 40, 18, "Product", "vacuum_cleaner.jpg", "Vacuum Cleaner", 1299.99m, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Storage",
                table: "Products",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "Processor",
                table: "Products",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "High-performance smartphone", 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "High-performance laptop for gaming and productivity", 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Portable and lightweight tablet", 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Wireless noise-cancelling headphones", 75 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Advanced smartwatch with fitness tracking", 60 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Portable Bluetooth speaker with rich sound", 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "High-resolution digital camera", 25 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Waterproof action camera for adventure", 40 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "4K Ultra HD Smart TV", 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Next-gen gaming console", 35 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "High-speed wireless router", 80 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "1TB external hard drive for backup", 70 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "All-in-one wireless printer", 55 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "27-inch Full HD monitor", 45 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Mechanical gaming keyboard", 90 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Wireless ergonomic mouse", 110 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "HD webcam for streaming", 65 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Professional USB microphone", 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Virtual reality headset for immersive gaming", 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Voice-controlled smart home assistant", 60 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Foldable electric scooter for urban commuting", 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Compact e-reader with e-ink display", 40 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Quadcopter drone with camera", 25 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Fitness tracker with heart rate monitor", 70 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Desktop 3D printer for rapid prototyping", 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Color-changing smart light bulb", 120 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Automatic coffee maker with grinder", 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Stainless steel electric kettle", 80 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "HEPA air purifier for clean air", 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Rechargeable electric toothbrush", 60 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Professional hair dryer with ionic technology", 75 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Electric shaver with precision blades", 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "High-speed blender for smoothies", 55 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Digital air fryer for healthy cooking", 45 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Front-loading washing machine", 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Energy-efficient refrigerator with freezer", 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Built-in dishwasher with multiple modes", 18 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Electric oven with convection cooking", 22 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Countertop microwave with sensor cooking", 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Bagless vacuum cleaner with powerful suction", 40 });
        }
    }
}
