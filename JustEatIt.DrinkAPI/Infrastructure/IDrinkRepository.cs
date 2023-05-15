using JustEatIt.DrinkAPI.Models;

namespace JustEatIt.DrinkAPI.Infrastructure
{
    public interface IDrinkRepository
    {
        Task<List<Drink>> GetAllDrinks();
        Task<Drink> GetDrinkById(string id);
        Task UpdateDrink(Drink drink);
        Task DeleteDrink(string id);
        Task<Drink> CreateDrink(Drink drink);
    }
}
