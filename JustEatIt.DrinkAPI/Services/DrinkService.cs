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

        public Task<Drink> GetDrinkById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDrink(Drink drink)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDrink(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Drink> CreateDrink(Drink drink)
        {
            throw new NotImplementedException();
        }
    }
}
