using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using webApi.Data;
using webApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(
    Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")));

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<ProductContext>();
//    context.Database.Migrate();

//    if(!context.Products.Any())
//    {
//        context.Products.AddRange(
//            new Product { Name = "Water", Price=10},
//            new Product { Name = "Beer", Price=18},
//            new Product { Name = "Wine", Price=24 }
//            );

//        context.SaveChanges();
//    }
//}
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

app.MapGet("/", async (ProductContext db) => await db.Products.ToListAsync());

app.UseHttpsRedirection();

app.Run();
