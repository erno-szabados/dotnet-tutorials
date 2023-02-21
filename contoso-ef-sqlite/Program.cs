using Contoso.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Contoso Pizza (Powered by SQLite)",
        Description = "Delicious data-driven delivery",
        Version = "v1"
    });
});

builder.Services.AddDbContext<PizzaContext>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
});


app.MapGet("/", () => "Contoso Pizza");
app.MapGet("/pizzas", async (PizzaContext ctx) => await ctx.Pizzas.ToListAsync());
app.MapPost("/pizza", async (PizzaContext ctx, Pizza pizza) =>
{
    await ctx.Pizzas.AddAsync(pizza);
    await ctx.SaveChangesAsync();
    return Results.Created($"/pizza/{pizza.Id}", pizza);
});
app.MapGet("/pizza/{id}", async (PizzaContext ctx, int id) => await ctx.Pizzas.FindAsync(id));

app.MapPut("/pizza/{id}", async (PizzaContext ctx, Pizza updatepizza, int id) =>
{
    var pizza = await ctx.Pizzas.FindAsync(id);
    if (pizza is null) return Results.NotFound();
    pizza.Name = updatepizza.Name;
    pizza.Description = updatepizza.Description;
    await ctx.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/pizza/{id}", async (PizzaContext ctx, int id) =>
{
    var pizza = await ctx.Pizzas.FindAsync(id);
    if (pizza is null)
    {
        return Results.NotFound();
    }
    ctx.Pizzas.Remove(pizza);
    await ctx.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
