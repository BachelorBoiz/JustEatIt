using JustEatIt.DrinkAPI.Infrastructure;
using JustEatIt.DrinkAPI.Models;

namespace JustEatIt.DrinkAPI.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IDrinkRepository _repository;

        public DrinkService(IDrinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Drink>> GetAllDrinks()
        {
            return await _repository.GetAllDrinks();
        }

        public Task<Drink> GetDrinkById(string id)
        {
            throw new NotImplementedException();
        }

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
            return await _repository.CreateDrink(drink);
        }
    }
}
