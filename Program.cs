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

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Use CORS policy
// app.UseCors("AllowAll");
app.UseCors();

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

// Get a specific user by joining the user and product tables. The user should be retrieved from the product by the seller id.
app.MapGet("/users/{id}/byproduct", ([FromServices] BangazonDbContext db, int id) =>
{
    var product = db.Product.FirstOrDefault(p => p.Id == id);
    if (product == null)
    {
        return Results.NotFound();
    }

    var user = db.User.FirstOrDefault(u => u.Id == product.SellerId);
    if (user == null)
    {
        return Results.NotFound();
    }

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
    userToUpdate.Uid = user.Uid;
    userToUpdate.IsRegistered = true;

    db.SaveChanges();

    return Results.Ok(userToUpdate);
});

 app.MapPost("/checkuser", ([FromServices] BangazonDbContext db, string uid) =>
        {
            User? user = db.User.FirstOrDefault(u => u.Uid == uid);

            if (user == null)
            {
                return Results.NotFound("User does not have an account.");
            }

            return Results.Ok(user);
        });

app.MapPost("/users", ([FromServices] BangazonDbContext db, User newUser) =>
{
    if (db.User.Any(u => u.Id == newUser.Id))
    {
        return Results.BadRequest("User is already registered");
    }

    User addUser = new User
    {
        Name = newUser.Name,
        Email = newUser.Email,
        Password = newUser.Password,
        Uid = newUser.Uid,
        IsRegistered = true
    };

    db.User.Add(addUser);
    db.SaveChanges();
    return Results.Created("/users", addUser);
});

app.MapDelete("/users/{id}", ([FromServices] BangazonDbContext db, int id) =>
{
    User user = db.User.FirstOrDefault(u => u.Id == id);

    db.User.Remove(user);
    db.SaveChanges();

    return Results.Ok(user);
});

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
app.MapGet("/products/seller/{id}", ([FromServices] BangazonDbContext db, int id) =>
{
  return Results.Ok(db.Product.Where(p => p.SellerId == id));

});

app.MapPost("/products", ([FromServices] BangazonDbContext db, Product product) =>
{
product.Id = db.Product.Max(p => p.Id) + 1;
 db.Product.Add(product);
 db.SaveChanges();

 return Results.Ok(product);
});

app.MapPut("/products/{id}", ([FromServices] BangazonDbContext db, int id, Product product) =>
{
    Product productToUpdate = db.Product.FirstOrDefault(u => u.Id == id);

    if (productToUpdate == null)
    {
        return Results.NotFound();
    }
    if (id != product.Id)
    {
        return Results.BadRequest();
    }

    // Update the product properties
    productToUpdate.Title = product.Title;
    productToUpdate.Description = product.Description;
    productToUpdate.PricePerUnit = product.PricePerUnit;

    db.SaveChanges();

    return Results.Ok(productToUpdate);
});

app.MapDelete("/products/{id}", ([FromServices] BangazonDbContext db, int id) =>
{
    Product product = db.Product.FirstOrDefault(u => u.Id == id);

    db.Product.Remove(product);
    db.SaveChanges();

    return Results.Ok(product);
});

// // Categories
app.MapGet("/categories", ([FromServices] BangazonDbContext db) =>
{
    return Results.Ok(db.Category.ToList());
});

app.Run();
