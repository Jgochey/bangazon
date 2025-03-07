using Microsoft.AspNetCore.Mvc;
using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using MvcJsonOptions = Microsoft.AspNetCore.Mvc.JsonOptions; // Alias for clarity



var builder = WebApplication.CreateBuilder(args);

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<MvcJsonOptions>(options =>
{
   options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Use CORS policy
app.UseCors("AllowAll");


// var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Users
app.MapGet("/users", ([FromServices] BangazonDbContext db) =>
{
    return Results.Ok(db.User.ToList());
});

app.MapGet("/users/{id}", ([FromServices] BangazonDbContext db, int id) =>
{
  User user = db.User.FirstOrDefault(u => u.Id == id);
  if (user == null)
  {
    return Results.NotFound();
  }
  return Results.Ok(user);
});

app.MapPost("/users", ([FromServices] BangazonDbContext db, User user) =>
{
 user.Id = db.User.Max(u => u.Id) + 1;
 db.User.Add(user);
 db.SaveChanges();

 return Results.Ok(user);
});

app.MapPut("/users/{id}", ([FromServices] BangazonDbContext db, int id, User user) =>
{
    User userToUpdate = db.User.FirstOrDefault(u => u.Id == id);

    if (userToUpdate == null)
    {
        return Results.NotFound();
    }
    if (id != user.Id)
    {
        return Results.BadRequest();
    }

    // Update the user properties
    userToUpdate.Name = user.Name;
    userToUpdate.Email = user.Email;
    userToUpdate.Password = user.Password;

    db.SaveChanges();

    return Results.Ok(userToUpdate);
});


// // Orders
// app.MapGet("/orders", () =>
// {
//     return Results.Ok(orders);
// });

// app.MapPost("/orders", (Orders order) =>
// {
//  order.Id = orders.Max(o => o.Id) + 1;
//  orders.Add(order);

//  return Results.Ok(order);
// });

// app.MapPut("/orders/{id}", (int id, Orders order) =>
// {
// Orders orderToUpdate = orders.FirstOrDefault(u => u.Id == id);
// int orderIndex = orders.IndexOf(orderToUpdate);

// if (orderToUpdate == null)
//     {
//         return Results.NotFound();
//     }
//     if (id != order.Id)
//     {
//         return Results.BadRequest();
//     }
//     orders[orderIndex] = order;
//     return Results.Ok(orderToUpdate);
// });


// // OrderItems
// app.MapGet("/orderitems", () =>
// {
//     return Results.Ok(orderitems);
// });

// app.MapPost("/orderitems", (OrderItems orderitem) =>
// {
//  orderitem.Id = orderitems.Max(o => o.Id) + 1;
//  orderitems.Add(orderitem);

//  return Results.Ok(orderitem);
// });

// app.MapPut("/orderitems/{id}", (int id, OrderItems orderitem) =>
// {
// OrderItems orderItemToUpdate = orderitems.FirstOrDefault(u => u.Id == id);
// int orderItemIndex = orderitems.IndexOf(orderItemToUpdate);

// if (orderItemToUpdate == null)
//     {
//         return Results.NotFound();
//     }
//     if (id != orderitem.Id)
//     {
//         return Results.BadRequest();
//     }
//     orderitems[orderItemIndex] = orderitem;
//     return Results.Ok(orderItemToUpdate);
// });

// app.MapDelete("/orderitems/{id}", (int id) =>
// {
//     OrderItems item = orderitems.FirstOrDefault(st => st.Id == id);

//     orderitems.Remove(item);

//     return Results.Ok(item);
// });


// // Products
app.MapGet("/products", ([FromServices] BangazonDbContext db) =>
{
    return Results.Ok(db.Product.ToList());
});


// Get the 20 most recent products
app.MapGet("/products/recent", ([FromServices] BangazonDbContext db) =>
{
    return Results.Ok(db.Product.OrderByDescending(p => p.Id).Take(20));
});


app.MapGet("/products/{id}", ([FromServices] BangazonDbContext db, int id) =>
{
  Product product = db.Product.FirstOrDefault(u => u.Id == id);
  if (product == null)
  {
    return Results.NotFound();
  }
  return Results.Ok(product);
});

// // Get products by User Id
// app.MapGet("/products/seller/{id}", (int id) =>
// {
//   return Results.Ok(products.Where(p => p.SellerId == id));
// });


// // Search for Products by title, even a partial match should return results.
// app.MapGet("/products/search/{title}", (string title) =>
// {
//   var search = title.ToLower();

//   return Results.Ok(products.Where(p => p.Title.ToLower().Contains(search) || p.Description.ToLower().Contains(search)));
// });


// app.MapPost("/products", (Products product) =>
// {
//  product.Id = products.Max(st => st.Id) + 1;
//  products.Add(product);

//  return Results.Ok(product);
// });


// app.MapPut("/products/{id}", (int id, Products product) => {
// Products productToUpdate = products.FirstOrDefault(u => u.Id == id);
// int productIndex = products.IndexOf(productToUpdate);

// if (productToUpdate == null)
//     {
//         return Results.NotFound();
//     }
//     if (id != product.Id)
//     {
//         return Results.BadRequest();
//     }
//     products[productIndex] = product;
//     return Results.Ok(productToUpdate);
// });


// // Profiles
// app.MapGet("/profiles", () =>
// {
//     return Results.Ok(profiles);
// });

// app.MapPost("/profiles", (Profile profile) =>
// {
//  profile.Id = profiles.Max(st => st.Id) + 1;
//  profiles.Add(profile);

//  return Results.Ok(profile);
// });

// app.MapPut("/profiles/{id}", (int id, Profile profile) =>
// {
// Profile profileToUpdate = profiles.FirstOrDefault(u => u.Id == id);
// int profileIndex = profiles.IndexOf(profileToUpdate);

// if (profileToUpdate == null)
//     {
//         return Results.NotFound();
//     }
//     if (id != profile.Id)
//     {
//         return Results.BadRequest();
//     }
//     profiles[profileIndex] = profile;
//     return Results.Ok(profileToUpdate);
// });


// // Categories
// app.MapGet("/categories", () =>
// {
//     return Results.Ok(categories);
// });

// app.MapPost("/categories", (Categories category) =>
// {
//  category.Id = categories.Max(st => st.Id) + 1;
//  categories.Add(category);

//  return Results.Ok(category);
// });

// app.MapPut("/categories/{id}", (int id, Categories category) => {
// Categories categoryToUpdate = categories.FirstOrDefault(u => u.Id == id);
// int categoryIndex = categories.IndexOf(categoryToUpdate);

// if (categoryToUpdate == null)
// {
//     return Results.NotFound();
// }
// if (id != category.Id)
// {
//     return Results.BadRequest();
// }
// categories[categoryIndex] = category;
// return Results.Ok(categoryToUpdate);
// });


// // Payments
// app.MapGet("/payments", () =>
// {
//     return Results.Ok(payments);
// });

// app.MapPost("/payments", (Payment payment) =>
// {
//  payment.Id = payments.Max(st => st.Id) + 1;
//  payments.Add(payment);

//  return Results.Ok(payment);
// });

// app.MapPut("/payments/{id}", (int id, Payment payment) =>
// {
// Payment paymentToUpdate = payments.FirstOrDefault(u => u.Id == id);
// int paymentIndex = payments.IndexOf(paymentToUpdate);

// if (paymentToUpdate == null)
//     {
//         return Results.NotFound();
//     }
//     if (id != payment.Id)
//     {
//         return Results.BadRequest();
//     }
//     payments[paymentIndex] = payment;
//     return Results.Ok(paymentToUpdate);
// });


// History
// SellerDashboard


app.Run();
