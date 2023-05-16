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

        public async Task<Drink> GetDrinkById(string id)
        {
            return await _repository.GetDrinkById(id);
        }

        public async Task UpdateDrink(Drink drink)
        {
            await _repository.UpdateDrink(drink);
        }

        public async Task DeleteDrink(string id)
        {
            await _repository.DeleteDrink(id);
        }

        public async Task<Drink> CreateDrink(Drink drink)
        {
            return await _repository.CreateDrink(drink);
        }
    }
}
