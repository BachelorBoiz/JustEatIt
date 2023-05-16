using JustEatIt.FoodAPI.Models;

namespace JustEatIt.FoodAPI.Infrastructure;

public interface IFoodRepository
{
    Task<List<Food>> GetAllFoods();
    Task<Food> GetFoodById(string id);
    Task UpdateFood(Food food);
    Task DeleteFood(string id);
    Task<Food> CreateFood(Food food);
}