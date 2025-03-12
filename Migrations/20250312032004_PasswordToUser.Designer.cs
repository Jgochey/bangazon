﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bangazon.Migrations
{
    [DbContext(typeof(BangazonDbContext))]
    [Migration("20250312032004_PasswordToUser")]
    partial class PasswordToUser : Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bangazon.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Technology",
                            ProductCount = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Health",
                            ProductCount = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Home",
                            ProductCount = 0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Automotive",
                            ProductCount = 0
                        },
                        new
                        {
                            Id = 5,
                            Name = "Clothing",
                            ProductCount = 0
                        });
                });

            modelBuilder.Entity("Bangazon.Models.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Search")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("History");
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            IsOpen = false,
                            OrderDate = new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = "Complete",
                            PaymentMethod = "Credit Card",
                            Total = 799.99m
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            IsOpen = false,
                            OrderDate = new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = "Complete",
                            PaymentMethod = "PayPal",
                            Total = 9.99m
                        });
                });

            modelBuilder.Entity("Bangazon.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("OrderItem");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            Price = 0m,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 2,
                            Price = 0m,
                            ProductId = 2,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("text");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Payment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            PaymentDate = new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethod = "Credit Card",
                            Total = 799.99m
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 2,
                            PaymentDate = new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethod = "PayPal",
                            Total = 9.99m
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("numeric");

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UnitsAvailable")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "A laptop computer",
                            PricePerUnit = 799.99m,
                            SellerId = 1,
                            Title = "Laptop",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "A pair of batteries",
                            PricePerUnit = 9.99m,
                            SellerId = 2,
                            Title = "AA Batteries",
                            UnitsAvailable = 100
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "A smartphone",
                            PricePerUnit = 399.99m,
                            SellerId = 1,
                            Title = "Smartphone",
                            UnitsAvailable = 50
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "A computer mouse",
                            PricePerUnit = 20.99m,
                            SellerId = 1,
                            Title = "Mouse",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Description = "A computer keyboard",
                            PricePerUnit = 49.99m,
                            SellerId = 1,
                            Title = "Keyboard",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Description = "A computer monitor",
                            PricePerUnit = 199.99m,
                            SellerId = 1,
                            Title = "Monitor",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            Description = "A pair of headphones",
                            PricePerUnit = 29.99m,
                            SellerId = 1,
                            Title = "Headphones",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            Description = "A webcam",
                            PricePerUnit = 49.99m,
                            SellerId = 1,
                            Title = "Webcam",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            Description = "A microphone",
                            PricePerUnit = 49.99m,
                            SellerId = 1,
                            Title = "Microphone",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 1,
                            Description = "A wristwatch",
                            PricePerUnit = 49.99m,
                            SellerId = 1,
                            Title = "Watch",
                            UnitsAvailable = 50
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 4,
                            Description = "An entire car, yes.",
                            PricePerUnit = 300000.99m,
                            SellerId = 1,
                            Title = "Car",
                            UnitsAvailable = 50
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 1,
                            Description = "A blender",
                            PricePerUnit = 50.99m,
                            SellerId = 1,
                            Title = "Blender",
                            UnitsAvailable = 100
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 1,
                            Description = "A treadmill",
                            PricePerUnit = 499.99m,
                            SellerId = 1,
                            Title = "Treadmill",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 2,
                            Description = "A bottle of vitamins",
                            PricePerUnit = 19.99m,
                            SellerId = 2,
                            Title = "Vitamins",
                            UnitsAvailable = 100
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 2,
                            Description = "A container of protein powder",
                            PricePerUnit = 49.99m,
                            SellerId = 2,
                            Title = "Protein Powder",
                            UnitsAvailable = 50
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 2,
                            Description = "A box of protein bars",
                            PricePerUnit = 19.99m,
                            SellerId = 2,
                            Title = "Protein Bars",
                            UnitsAvailable = 100
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 2,
                            Description = "A yoga mat",
                            PricePerUnit = 29.99m,
                            SellerId = 2,
                            Title = "Yoga Mat",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 2,
                            Description = "A set of resistance bands",
                            PricePerUnit = 19.99m,
                            SellerId = 2,
                            Title = "Resistance Bands",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 2,
                            Description = "A pair of dumbbells",
                            PricePerUnit = 49.99m,
                            SellerId = 2,
                            Title = "Dumbbells",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 2,
                            Description = "A kettlebell",
                            PricePerUnit = 49.99m,
                            SellerId = 2,
                            Title = "Kettlebell",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 2,
                            Description = "A jump rope",
                            PricePerUnit = 9.99m,
                            SellerId = 2,
                            Title = "Jump Rope",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 2,
                            Description = "A foam roller",
                            PricePerUnit = 19.99m,
                            SellerId = 2,
                            Title = "Foam Roller",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 2,
                            Description = "A water bottle",
                            PricePerUnit = 9.99m,
                            SellerId = 2,
                            Title = "Water Bottle",
                            UnitsAvailable = 50
                        },
                        new
                        {
                            Id = 25,
                            CategoryId = 5,
                            Description = "A pair of tennis shoes",
                            PricePerUnit = 49.99m,
                            SellerId = 2,
                            Title = "Tennis Shoes",
                            UnitsAvailable = 10
                        },
                        new
                        {
                            Id = 26,
                            CategoryId = 3,
                            Description = "Pickup dry cleaning on Thursday",
                            PricePerUnit = 19.99m,
                            SellerId = 2,
                            Title = "A TEST ITEM",
                            UnitsAvailable = 10
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Profile");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            Email = "johndoe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Phone = "555-555-5555",
                            Picture = "https://example.com/johndoe.jpg",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St",
                            Email = "janesmith@example.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            Phone = "555-555-5555",
                            Picture = "https://example.com/janesmith.jpg",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Bangazon.Models.SellerDashboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalSales")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SellerDashboard");
                });

            modelBuilder.Entity("Bangazon.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsRegistered")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "john.doe@example.com",
                            IsRegistered = true,
                            Name = "John",
                            Password = "password123",
                            Uid = "1aBcD4EfGhIjKlMnOpQrStUvWxYz"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jane.smith@example.com",
                            IsRegistered = true,
                            Name = "Jane",
                            Password = "123password",
                            Uid = "2bCdE5FgHiJkLmNoPqRsTuVwXyZa"
                        });
                });
#pragma warning restore 612, 618
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
