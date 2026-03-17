using ServerApp.Models;
var builder = WebApplication.CreateBuilder(args);


// Copilot suggested this CORS configuration to allow the Blazor client to call the API from another origin.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});


builder.Services.AddControllers();

var app = builder.Build();

// Use CORS in pipeline
app.UseCors();

app.MapControllers();



app.MapGet("/api/productlist", () =>
{
    return new List<Product>
    {
        new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 1200.50,
            Stock = 25,
            Category = new Category { Id = 101, Name = "Electronics" }
        },
        new Product
        {
            Id = 2,
            Name = "Headphones",
            Price = 50.00,
            Stock = 100,
            Category = new Category { Id = 102, Name = "Accessories" }
        }
    };
});


app.Run();