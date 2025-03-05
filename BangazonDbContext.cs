using Microsoft.EntityFrameworkCore;
using Bangazon.Models;

public class BangazonDbContext : DbContext
{

  public DbSet<Category> Category { get; set; }

  public DbSet<History> History { get; set; }

  public DbSet<Order> Order { get; set; }
  public DbSet<OrderItem> OrderItem { get; set; }
  public DbSet<Payment> Payment { get; set; }

  public DbSet<Product> Product { get; set; }

  public DbSet<Profile> Profile { get; set; }

  public DbSet<SellerDashboard> SellerDashboard { get; set; }
  public DbSet<User> User { get; set; }


  public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
  {

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

    modelBuilder.Entity<Category>().HasData(new Category[]
    {
        new Category { Id = 1, Name = "Technology", ProductCount = 0 },
        new Category { Id = 2, Name = "Health", ProductCount = 0 }

    });


    modelBuilder.Entity<Order>().HasData(new Order[]
    {
        new Order { Id = 1, CustomerId = 1, OrderDate = new DateTime(2025, 2, 4), Total = 799.99m, PaymentMethod = "Credit Card", OrderStatus = "Complete", IsOpen = false },
        new Order { Id = 2, CustomerId = 2, OrderDate = new DateTime(2025, 2, 3), Total = 9.99m, PaymentMethod = "PayPal", OrderStatus = "Complete", IsOpen = false }

    });

    modelBuilder.Entity<OrderItem>().HasData(new OrderItem[]
    {
        new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
        new OrderItem { Id = 2, OrderId = 2, ProductId = 2, Quantity = 2 }

    });


    modelBuilder.Entity<Payment>().HasData(new Payment[]
    {
        new Payment { Id = 1, OrderId = 1, PaymentMethod = "Credit Card", PaymentDate = new DateTime(2025, 2, 4), Total = 799.99m },
        new Payment { Id = 2, OrderId = 2, PaymentMethod = "PayPal", PaymentDate = new DateTime(2025, 2, 3), Total = 9.99m }

    });

    modelBuilder.Entity<Product>().HasData(new Product[]
    {
        new Product { Id = 1, Title = "Laptop", Description = "A laptop computer", PricePerUnit = 799.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },
        new Product { Id = 2, Title = "AA Batteries", Description = "A pair of batteries", PricePerUnit = 9.99m, UnitsAvailable = 100, SellerId = 2, CategoryId = 1 },
        new Product { Id = 4, Title = "Smartphone", Description = "A smartphone", PricePerUnit = 399.99m, UnitsAvailable = 50, SellerId = 1, CategoryId = 1 },
        new Product { Id = 5, Title = "Mouse", Description = "A computer mouse", PricePerUnit = 20.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },
        new Product { Id = 6, Title = "Keyboard", Description = "A computer keyboard", PricePerUnit = 49.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },
        new Product { Id = 7, Title = "Monitor", Description = "A computer monitor", PricePerUnit = 199.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },
        new Product { Id = 8, Title = "Headphones", Description = "A pair of headphones", PricePerUnit = 29.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },
        new Product { Id = 9, Title = "Webcam", Description = "A webcam", PricePerUnit = 49.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },
        new Product { Id = 10, Title = "Microphone", Description = "A microphone", PricePerUnit = 49.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },
        new Product { Id = 11, Title = "Watch", Description = "A wristwatch", PricePerUnit = 49.99m, UnitsAvailable = 50, SellerId = 1, CategoryId = 1 },
        new Product { Id = 12, Title = "Car", Description = "An entire car, yes.", PricePerUnit = 300000.99m, UnitsAvailable = 50, SellerId = 1, CategoryId = 1 },
        new Product { Id = 13, Title = "Blender", Description = "A blender", PricePerUnit = 50.99m, UnitsAvailable = 100, SellerId = 1, CategoryId = 1 },
        new Product { Id = 14, Title = "Treadmill", Description = "A treadmill", PricePerUnit = 499.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },

        new Product { Id = 15, Title = "Vitamins", Description = "A bottle of vitamins", PricePerUnit = 19.99m, UnitsAvailable = 100, SellerId = 2, CategoryId = 2 },
        new Product { Id = 16, Title = "Protein Powder", Description = "A container of protein powder", PricePerUnit = 49.99m, UnitsAvailable = 50, SellerId = 2, CategoryId = 2 },
        new Product { Id = 17, Title = "Protein Bars", Description = "A box of protein bars", PricePerUnit = 19.99m, UnitsAvailable = 100, SellerId = 2, CategoryId = 2 },
        new Product { Id = 18, Title = "Yoga Mat", Description = "A yoga mat", PricePerUnit = 29.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
        new Product { Id = 19, Title = "Resistance Bands", Description = "A set of resistance bands", PricePerUnit = 19.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
        new Product { Id = 20, Title = "Dumbbells", Description = "A pair of dumbbells", PricePerUnit = 49.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
        new Product { Id = 21, Title = "Kettlebell", Description = "A kettlebell", PricePerUnit = 49.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
        new Product { Id = 22, Title = "Jump Rope", Description = "A jump rope", PricePerUnit = 9.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
        new Product { Id = 23, Title = "Foam Roller", Description = "A foam roller", PricePerUnit = 19.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
        new Product { Id = 24, Title = "Water Bottle", Description = "A water bottle", PricePerUnit = 9.99m, UnitsAvailable = 50, SellerId = 2, CategoryId = 2 },
        new Product { Id = 25, Title = "Tennis Shoes", Description = "A pair of tennis shoes", PricePerUnit = 49.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
        new Product { Id = 26, Title = "A TEST ITEM", Description = "Pickup dry cleaning on Thursday", PricePerUnit = 19.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
    
  });

      modelBuilder.Entity<Profile>().HasData(new Profile[]
    {
      new Profile { Id = 1, UserId = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com", Address = "123 Main St", Phone = "555-555-5555", Picture = "https://example.com/johndoe.jpg" },
      new Profile { Id = 2, UserId = 2, FirstName = "Jane", LastName = "Smith", Email = "janesmith@example.com", Address = "456 Elm St", Phone = "555-555-5555", Picture = "https://example.com/janesmith.jpg" }

    });

    modelBuilder.Entity<User>().HasData(new User[]
    {
        new User { Id = 1, Name = "John", Email = "john.doe@example.com", Password = "password123"},
        new User { Id = 2, Name = "Jane", Email = "jane.smith@example.com", Password = "123password"}

    });

    // modelBuilder.Entity<History>().HasData(new History[]
    // {
    //     new History { Id = 1, UserId = 1, Date = new DateTime(2025, 2, 4) , Search = "Laptop" }
    // });

    // modelBuilder.Entity<SellerDashboard>().HasData(new SellerDashboard[]
    // {
    //     new SellerDashboard { Id = 1, SellerId = 1, TotalSales = 5 },
    //     new SellerDashboard { Id = 2, SellerId = 2, TotalSales = 2 }

    // });
    
  }
}




// OLD LISTS
// List<Users> users = new List<Users>
//     {
//         new Users { Id = 1, Name = "John", Email = "john.doe@example.com", Password = "password123"},
//         new Users { Id = 2, Name = "Jane", Email = "jane.smith@example.com", Password = "123password"}
//     };




// List<Categories> categories = new List<Categories>
//     {

//     };

// List<Product> product = new List<Product>
//     {
//         new Product { Id = 1, Title = "Laptop", Description = "A laptop computer", PricePerUnit = 799.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },
//         new Product { Id = 2, Title = "AA Batteries", Description = "A pair of batteries", PricePerUnit = 9.99m, UnitsAvailable = 100, SellerId = 2, CategoryId = 1 },
//         new Product { Id = 4, Title = "Smartphone", Description = "A smartphone", PricePerUnit = 399.99m, UnitsAvailable = 50, SellerId = 1, CategoryId = 1 },
//         new Product { Id = 5, Title = "Mouse", Description = "A computer mouse", PricePerUnit = 20.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },
//         new Product { Id = 6, Title = "Keyboard", Description = "A computer keyboard", PricePerUnit = 49.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },
//         new Product { Id = 7, Title = "Monitor", Description = "A computer monitor", PricePerUnit = 199.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },
//         new Product { Id = 8, Title = "Headphones", Description = "A pair of headphones", PricePerUnit = 29.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },
//         new Product { Id = 9, Title = "Webcam", Description = "A webcam", PricePerUnit = 49.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },
//         new Product { Id = 10, Title = "Microphone", Description = "A microphone", PricePerUnit = 49.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },
//         new Product { Id = 11, Title = "Watch", Description = "A wristwatch", PricePerUnit = 49.99m, UnitsAvailable = 50, SellerId = 1, CategoryId = 1 },
//         new Product { Id = 12, Title = "Car", Description = "An entire car, yes.", PricePerUnit = 300000.99m, UnitsAvailable = 50, SellerId = 1, CategoryId = 1 },
//         new Product { Id = 13, Title = "Blender", Description = "A blender", PricePerUnit = 50.99m, UnitsAvailable = 100, SellerId = 1, CategoryId = 1 },
//         new Product { Id = 14, Title = "Treadmill", Description = "A treadmill", PricePerUnit = 499.99m, UnitsAvailable = 10, SellerId = 1, CategoryId = 1 },

//         new Product { Id = 15, Title = "Vitamins", Description = "A bottle of vitamins", PricePerUnit = 19.99m, UnitsAvailable = 100, SellerId = 2, CategoryId = 2 },
//         new Product { Id = 16, Title = "Protein Powder", Description = "A container of protein powder", PricePerUnit = 49.99m, UnitsAvailable = 50, SellerId = 2, CategoryId = 2 },
//         new Product { Id = 17, Title = "Protein Bars", Description = "A box of protein bars", PricePerUnit = 19.99m, UnitsAvailable = 100, SellerId = 2, CategoryId = 2 },
//         new Product { Id = 18, Title = "Yoga Mat", Description = "A yoga mat", PricePerUnit = 29.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
//         new Product { Id = 19, Title = "Resistance Bands", Description = "A set of resistance bands", PricePerUnit = 19.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
//         new Product { Id = 20, Title = "Dumbbells", Description = "A pair of dumbbells", PricePerUnit = 49.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
//         new Product { Id = 21, Title = "Kettlebell", Description = "A kettlebell", PricePerUnit = 49.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
//         new Product { Id = 22, Title = "Jump Rope", Description = "A jump rope", PricePerUnit = 9.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
//         new Product { Id = 23, Title = "Foam Roller", Description = "A foam roller", PricePerUnit = 19.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
//         new Product { Id = 24, Title = "Water Bottle", Description = "A water bottle", PricePerUnit = 9.99m, UnitsAvailable = 50, SellerId = 2, CategoryId = 2 },
//         new Product { Id = 25, Title = "Tennis Shoes", Description = "A pair of tennis shoes", PricePerUnit = 49.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },
//         new Product { Id = 26, Title = "A TEST ITEM", Description = "Pickup dry cleaning on Thursday", PricePerUnit = 19.99m, UnitsAvailable = 10, SellerId = 2, CategoryId = 2 },

//     };

// List<Orders> orders = new List<Orders>
//     {
//         new Orders { Id = 1, CustomerId = 1, OrderDate = new DateTime(2025, 2, 4), Total = 799.99m, PaymentMethod = "Credit Card", OrderStatus = "Complete", IsOpen = false },
//         new Orders { Id = 2, CustomerId = 2, OrderDate = new DateTime(2025, 2, 3), Total = 9.99m, PaymentMethod = "PayPal", OrderStatus = "Complete", IsOpen = false }
//     };

// List<OrderItems> orderitems = new List<OrderItems>
//     {
//         new OrderItems { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
//         new OrderItems { Id = 2, OrderId = 2, ProductId = 2, Quantity = 2 }
//     };


// List<Payment> payments = new List<Payment>
//     {
//       new Payment { Id = 1, OrderId = 1, PaymentMethod = "Credit Card", PaymentDate = new DateTime(2025, 2, 4), Total = 799.99m },
//       new Payment { Id = 2, OrderId = 2, PaymentMethod = "PayPal", PaymentDate = new DateTime(2025, 2, 3), Total = 9.99m }
//     };

// List<Profile> profiles = new List<Profile>
//     {
//       new Profile { Id = 1, UserId = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com", Address = "123 Main St", Phone = "555-555-5555", Picture = "https://example.com/johndoe.jpg" },
//       new Profile { Id = 2, UserId = 2, FirstName = "Jane", LastName = "Smith", Email = "janesmith@example.com", Address = "456 Elm St", Phone = "555-555-5555", Picture = "https://example.com/janesmith.jpg" }
//     };

// List<History> history = new List<History>
//     {
//         new History { Id = 1, UserId = 1, Date = new DateTime(2025, 2, 4) , Search = "Laptop" },  
//     };

// List<SellerDashboard> sellerDashboard = new List<SellerDashboard>
//     {
//       new SellerDashboard { Id = 1, SellerId = 1, TotalSales = 5 },
//       new SellerDashboard { Id = 2, SellerId = 2, TotalSales = 2 }
//     };
