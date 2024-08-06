using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Imagine.Migrations
{
    /// <inheritdoc />
    public partial class removeseed : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, 1, "smartphone.jpg", "Smartphone", 8999.99m },
                    { 2, null, 1, "laptop.jpg", "Laptop", 14999.99m },
                    { 3, null, 1, "tablet.jpg", "Tablet", 4999.99m },
                    { 4, null, 2, "headphones.jpg", "Headphones", 1999.99m },
                    { 5, null, 2, "smartwatch.jpg", "Smartwatch", 2999.99m },
                    { 6, null, 2, "bluetooth_speaker.jpg", "Bluetooth Speaker", 899.99m },
                    { 7, null, 3, "camera.jpg", "Digital Camera", 7499.99m },
                    { 8, null, 3, "action_camera.jpg", "Action Camera", 1999.99m },
                    { 9, null, 4, "tv.jpg", "Television", 10999.99m },
                    { 10, null, 4, "gaming_console.jpg", "Gaming Console", 5999.99m },
                    { 11, null, 5, "router.jpg", "Router", 799.99m },
                    { 12, null, 5, "external_hard_drive.jpg", "External Hard Drive", 599.99m },
                    { 13, null, 6, "printer.jpg", "Printer", 1299.99m },
                    { 14, null, 6, "monitor.jpg", "Monitor", 2199.99m },
                    { 15, null, 7, "keyboard.jpg", "Keyboard", 599.99m },
                    { 16, null, 7, "mouse.jpg", "Mouse", 299.99m },
                    { 17, null, 8, "webcam.jpg", "Webcam", 499.99m },
                    { 18, null, 8, "microphone.jpg", "Microphone", 899.99m },
                    { 19, null, 9, "vr_headset.jpg", "VR Headset", 4499.99m },
                    { 20, null, 9, "smart_home_assistant.jpg", "Smart Home Assistant", 1499.99m },
                    { 21, null, 10, "electric_scooter.jpg", "Electric Scooter", 3299.99m },
                    { 22, null, 10, "e_reader.jpg", "E-reader", 1299.99m },
                    { 23, null, 11, "drone.jpg", "Drone", 3999.99m },
                    { 24, null, 11, "fitness_tracker.jpg", "Fitness Tracker", 799.99m },
                    { 25, null, 12, "3d_printer.jpg", "3D Printer", 5499.99m },
                    { 26, null, 12, "smart_light_bulb.jpg", "Smart Light Bulb", 199.99m },
                    { 27, null, 13, "coffee_maker.jpg", "Coffee Maker", 1599.99m },
                    { 28, null, 13, "electric_kettle.jpg", "Electric Kettle", 499.99m },
                    { 29, null, 14, "air_purifier.jpg", "Air Purifier", 2499.99m },
                    { 30, null, 14, "electric_toothbrush.jpg", "Electric Toothbrush", 699.99m },
                    { 31, null, 15, "hair_dryer.jpg", "Hair Dryer", 399.99m },
                    { 32, null, 15, "shaver.jpg", "Shaver", 899.99m },
                    { 33, null, 16, "blender.jpg", "Blender", 699.99m },
                    { 34, null, 16, "air_fryer.jpg", "Air Fryer", 1299.99m },
                    { 35, null, 17, "washing_machine.jpg", "Washing Machine", 5499.99m },
                    { 36, null, 17, "refrigerator.jpg", "Refrigerator", 7499.99m },
                    { 37, null, 17, "dishwasher.jpg", "Dishwasher", 4499.99m },
                    { 38, null, 18, "oven.jpg", "Oven", 3999.99m },
                    { 39, null, 18, "microwave.jpg", "Microwave", 1999.99m },
                    { 40, null, 18, "vacuum_cleaner.jpg", "Vacuum Cleaner", 1299.99m }
                });
        }
    }
}
