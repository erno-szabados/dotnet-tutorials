using MongoDB.Driver;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.Conventions;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
                     .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();

        var connectionString = configuration["MongoDb:ConnectionString"];

        if (connectionString is null)
        {
            Console.WriteLine("You must set your MongoDb:ConnectionString in user secrets: dotnet user-secrets set \"MongoDb:ConnectionString\" \"<connectionstring>\".");
            Environment.Exit(0);
        }

        var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
        ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);

        var client = new MongoClient(connectionString);

        var pizzaPlaces = await GetRestaurants(client, "Pizza");
        foreach (var r in pizzaPlaces) {
            Console.WriteLine($"{r.Name}");
        }

    }

    private static async Task<List<Restaurant>> GetRestaurants(MongoClient client, string cuisine)
    {
        var restaurantsDatabase = client.GetDatabase("sample_restaurants");
        var _restaurantsCollection = restaurantsDatabase.GetCollection<Restaurant>("restaurants");
        var filter = Builders<Restaurant>.Filter.Eq(restaurant => restaurant.Cuisine, cuisine);
        var restaurants = await _restaurantsCollection.FindAsync(filter);
        return restaurants.ToList();
    }
}