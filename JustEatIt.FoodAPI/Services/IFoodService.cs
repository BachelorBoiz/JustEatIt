using JustEatIt.FoodAPI.Models;

namespace JustEatIt.FoodAPI.Services;

public interface IFoodService
{
    Task<List<Food>> GetAllFoods();
    Task<Food> GetFoodById(string id);
    Task UpdateFood(Food food);
    Task DeleteFood(string id);
    Task<Food> CreateFood(Food food);
}