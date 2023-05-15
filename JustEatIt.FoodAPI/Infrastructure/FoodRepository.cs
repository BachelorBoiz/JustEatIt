using JustEatIt.FoodAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JustEatIt.FoodAPI.Infrastructure;

public class FoodRepository : IFoodRepository
{
    private readonly IMongoCollection<Food> _foods;

    public FoodRepository(IOptions<DatabaseSettings> options)
    {
        var mongoClient = new MongoClient(
            options.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            options.Value.DatabaseName);

        _foods = mongoDatabase.GetCollection<Food>(
            options.Value.FoodsCollectionName);

    }
    public async Task<List<Food>> GetAllFoods()
    {
        return await _foods.Find(_ => true).ToListAsync();
    }

    public Task<Food> GetFoodById(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateFood(Food food)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFood(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Food> CreateFood(Food food)
    {
        throw new NotImplementedException();
    }
}