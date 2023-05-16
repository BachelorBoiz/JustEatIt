using JustEatIt.DrinkAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JustEatIt.DrinkAPI.Infrastructure
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly IMongoCollection<Drink> _drinks;

        public DrinkRepository(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(
                options.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                options.Value.DatabaseName);

            _drinks = mongoDatabase.GetCollection<Drink>(
                options.Value.DrinksCollectionName);
        }
        public async Task<List<Drink>> GetAllDrinks() =>
            await _drinks.Find(_ => true).ToListAsync();

        public async Task<Drink> GetDrinkById(string id) =>
            await _drinks.Find(x => x.Id == id).FirstOrDefaultAsync();


        public async Task UpdateDrink(Drink drink)
        {
            //The Eq method is used to create an equality filter based on the food's ID.
            var filter = Builders<Drink>.Filter.Eq(x => x.Id, drink.Id);
            var update = Builders<Drink>.Update
                .Set(x => x.Name, drink.Name)
                .Set(x => x.Description, drink.Description)
                .Set(x => x.Price, drink.Price)
                .Set(x => x.Ml, drink.Ml)
                .Set(x => x.Type, drink.Type);

            await _drinks.UpdateOneAsync(filter, update);
        }

        public async Task DeleteDrink(string id)
        {
            var filter = Builders<Drink>.Filter.Eq(x => x.Id, id);
            await _drinks.DeleteOneAsync(filter);
        }

        public async Task<Drink> CreateDrink(Drink drink)
        {
            await _drinks.InsertOneAsync(drink);

            var newDrink = await GetDrinkById(drink.Id);
            return newDrink;
        }
        
    }
}
