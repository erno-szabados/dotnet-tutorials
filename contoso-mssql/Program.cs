using Contoso;
using Contoso.Data;
using Contoso.Models;

Console.WriteLine("Contoso Pizza - Code First Example");

static void AddSomePizza(ContosoPizzaContext ctx)
{
    Product HawaiiPizza = new Product()
    {
        Name = "Hawaii Pizza",
        Price = 9.99M
    };

    Product FourSeasonsPizza = new Product()
    {
        Name = "Four Seasons",
        Price = 7.99M
    };

    ctx.Products.Add(HawaiiPizza);
    ctx.Products.Add(FourSeasonsPizza);
    ctx.SaveChanges();
}

static void ReadProducts(ContosoPizzaContext ctx)
{
    var products = ctx.Products
        .Where(p => p.Price > 8.0M)
        .OrderBy(p => p.Name)
        .ToList();
    foreach (var product in products)
    {
        Console.WriteLine($@"
ID:   {product.Id}
NAME: {product.Name}
PRICE:{product.Price}
");
    }
}

static void DiscountHawaii(ContosoPizzaContext ctx)
{
    var hawaii = ctx.Products.Where(p => p.Name.Equals("hawaii")).FirstOrDefault();
    if (hawaii is not null)
    {
        hawaii.Price -= 0.5M;
    }
    ctx.SaveChanges();
}

static void DeleteAllPizzas(ContosoPizzaContext ctx)
{
    ctx.Products.Truncate();
    ctx.SaveChanges();
}

using ContosoPizzaContext ctx = new();
AddSomePizza(ctx);
Console.WriteLine("Before discount:");
ReadProducts(ctx);
DiscountHawaii(ctx);
Console.WriteLine("After discount:");
ReadProducts(ctx);
DeleteAllPizzas(ctx);
Console.WriteLine("After delete:");
ReadProducts(ctx);

