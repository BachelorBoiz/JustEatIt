using JustEatIt.FoodAPI.Models;

namespace JustEatIt.FoodAPI.Services;

public interface IFoodService
{
    Task<List<Food>> GetAllFoods();
    Task<Food> GetFoodById(int id);
    Task UpdateFood(Food food);
    Task DeleteDrink(int id);
    Task<Food> CreateFood(Food food);
}