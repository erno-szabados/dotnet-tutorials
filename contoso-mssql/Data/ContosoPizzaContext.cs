
using Microsoft.EntityFrameworkCore;
using Contoso.Models;

namespace Contoso.Data;

public class ContosoPizzaContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var appDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Contoso");
        Directory.CreateDirectory(appDirectory);
        var dbFileName = Path.Combine(appDirectory, "ContosoPizza.mdf");

        optionsBuilder.UseSqlServer(@$"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=ContosoPizza;AttachDBFilename={dbFileName}");
    }
}