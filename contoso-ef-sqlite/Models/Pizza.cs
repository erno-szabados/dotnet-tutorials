using Microsoft.EntityFrameworkCore;

namespace Contoso.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }


    class PizzaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=Pizzas.db;");
        }

        public DbSet<Pizza> Pizzas { get; set; } = null!;
    }
}