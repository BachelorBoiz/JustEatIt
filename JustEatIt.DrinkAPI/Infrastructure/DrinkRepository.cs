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


        public Task UpdateDrink(Drink drink)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDrink(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Drink> CreateDrink(Drink drink)
        {
            await _drinks.InsertOneAsync(drink);

            var newDrink = await GetDrinkById(drink.Id);
            return newDrink;
        }
        
    }
}
