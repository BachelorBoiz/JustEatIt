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

    public async Task<Food> GetFoodById(string id)
    {
        return await _foods.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task UpdateFood(Food food)
    {
        //The Eq method is used to create an equality filter based on the food's ID.
        var filter = Builders<Food>.Filter.Eq(x => x.Id, food.Id);
        var update = Builders<Food>.Update
            .Set(x => x.Name, food.Name)
            .Set(x => x.Ingredients, food.Ingredients)
            .Set(x => x.Price, food.Price);

        await _foods.UpdateOneAsync(filter, update);
    }

    public async Task DeleteFood(string id)
    {
        var filter = Builders<Food>.Filter.Eq(x => x.Id, id);
        await _foods.DeleteOneAsync(filter);
    }

    public async Task<Food> CreateFood(Food food)
    {
        await _foods.InsertOneAsync(food);

        var newFood = await GetFoodById(food.Id);
        return newFood;
    }
}