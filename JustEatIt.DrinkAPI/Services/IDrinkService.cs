using JustEatIt.DrinkAPI.Models;

namespace JustEatIt.DrinkAPI.Services
{
    public interface IDrinkService
    {
        Task<List<Drink>> GetAllDrinks();
        Task<Drink> GetDrinkById(string id);
        Task UpdateDrink(Drink drink);
        Task DeleteDrink(string id);
        Task<Drink> CreateDrink(Drink drink);
    }
}
