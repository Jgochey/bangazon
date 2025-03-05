using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProductCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Search = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    OrderStatus = table.Column<string>(type: "text", nullable: false),
                    IsOpen = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SellerId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "numeric", nullable: false),
                    UnitsAvailable = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Picture = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellerDashboard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SellerId = table.Column<int>(type: "integer", nullable: false),
                    TotalSales = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerDashboard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "ProductCount" },
                values: new object[,]
                {
                    { 1, "Technology", 0 },
                    { 2, "Health", 0 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "IsOpen", "OrderDate", "OrderStatus", "PaymentMethod", "Total" },
                values: new object[,]
                {
                    { 1, 1, false, new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Credit Card", 799.99m },
                    { 2, 2, false, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "PayPal", 9.99m }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 0m, 1, 1 },
                    { 2, 2, 0m, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "Id", "OrderId", "PaymentDate", "PaymentMethod", "Total" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit Card", 799.99m },
                    { 2, 2, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "PayPal", 9.99m }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "PricePerUnit", "SellerId", "Title", "UnitsAvailable" },
                values: new object[,]
                {
                    { 1, 1, "A laptop computer", 799.99m, 1, "Laptop", 10 },
                    { 2, 1, "A pair of batteries", 9.99m, 2, "AA Batteries", 100 },
                    { 4, 1, "A smartphone", 399.99m, 1, "Smartphone", 50 },
                    { 5, 1, "A computer mouse", 20.99m, 1, "Mouse", 10 },
                    { 6, 1, "A computer keyboard", 49.99m, 1, "Keyboard", 10 },
                    { 7, 1, "A computer monitor", 199.99m, 1, "Monitor", 10 },
                    { 8, 1, "A pair of headphones", 29.99m, 1, "Headphones", 10 },
                    { 9, 1, "A webcam", 49.99m, 1, "Webcam", 10 },
                    { 10, 1, "A microphone", 49.99m, 1, "Microphone", 10 },
                    { 11, 1, "A wristwatch", 49.99m, 1, "Watch", 50 },
                    { 12, 1, "An entire car, yes.", 300000.99m, 1, "Car", 50 },
                    { 13, 1, "A blender", 50.99m, 1, "Blender", 100 },
                    { 14, 1, "A treadmill", 499.99m, 1, "Treadmill", 10 },
                    { 15, 2, "A bottle of vitamins", 19.99m, 2, "Vitamins", 100 },
                    { 16, 2, "A container of protein powder", 49.99m, 2, "Protein Powder", 50 },
                    { 17, 2, "A box of protein bars", 19.99m, 2, "Protein Bars", 100 },
                    { 18, 2, "A yoga mat", 29.99m, 2, "Yoga Mat", 10 },
                    { 19, 2, "A set of resistance bands", 19.99m, 2, "Resistance Bands", 10 },
                    { 20, 2, "A pair of dumbbells", 49.99m, 2, "Dumbbells", 10 },
                    { 21, 2, "A kettlebell", 49.99m, 2, "Kettlebell", 10 },
                    { 22, 2, "A jump rope", 9.99m, 2, "Jump Rope", 10 },
                    { 23, 2, "A foam roller", 19.99m, 2, "Foam Roller", 10 },
                    { 24, 2, "A water bottle", 9.99m, 2, "Water Bottle", 50 },
                    { 25, 2, "A pair of tennis shoes", 49.99m, 2, "Tennis Shoes", 10 },
                    { 26, 2, "Pickup dry cleaning on Thursday", 19.99m, 2, "A TEST ITEM", 10 }
                });

            migrationBuilder.InsertData(
                table: "Profile",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "Phone", "Picture", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Main St", "johndoe@example.com", "John", "Doe", "555-555-5555", "https://example.com/johndoe.jpg", 1 },
                    { 2, "456 Elm St", "janesmith@example.com", "Jane", "Smith", "555-555-5555", "https://example.com/janesmith.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "password123" },
                    { 2, "jane.smith@example.com", "Jane", "123password" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "SellerDashboard");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
