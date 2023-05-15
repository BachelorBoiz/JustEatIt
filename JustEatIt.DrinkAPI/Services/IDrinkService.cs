using JustEatIt.DrinkAPI.Models;

namespace JustEatIt.DrinkAPI.Services
{
    public interface IDrinkService
    {
        Task<List<Drink>> GetAllDrinks();
        Task<Drink> GetDrinkById(int id);
        Task UpdateDrink(Drink drink);
        Task DeleteDrink(int id);
        Task<Drink> CreateDrink(Drink drink);
    }
}
