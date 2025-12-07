using Microsoft.EntityFrameworkCore;
using ProductsCrud.Models;

namespace ProductsCrud.Data;

public class AppDb : DbContext
{
  public DbSet<Product> Products { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=database.db");
}