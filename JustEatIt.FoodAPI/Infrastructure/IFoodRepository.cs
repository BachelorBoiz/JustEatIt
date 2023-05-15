using JustEatIt.FoodAPI.Models;

namespace JustEatIt.FoodAPI.Infrastructure;

public interface IFoodRepository
{
    Task<List<Food>> GetAllFoods();
    Task<Food> GetFoodById(int id);
    Task UpdateFood(Food food);
    Task DeleteFood(int id);
    Task<Food> CreateFood(Food food);
}