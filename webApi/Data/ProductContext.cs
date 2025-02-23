using Microsoft.EntityFrameworkCore;
using webApi.Models;

namespace webApi.Data;

public class ProductContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; } = null!;
}
