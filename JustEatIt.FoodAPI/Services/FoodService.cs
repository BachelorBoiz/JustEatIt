using JustEatIt.FoodAPI.Infrastructure;
using JustEatIt.FoodAPI.Models;

namespace JustEatIt.FoodAPI.Services;

public class FoodService : IFoodService
{
    private readonly IFoodRepository _repository;

    public FoodService(IFoodRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Food>> GetAllFoods()
    {
        return await _repository.GetAllFoods();
    }

    public async Task<Food> GetFoodById(string id)
    {
        return await _repository.GetFoodById(id);
    }

    public async Task UpdateFood(Food food)
    {
        await _repository.UpdateFood(food);
    }

    public async Task DeleteFood(string id)
    {
        await _repository.DeleteFood(id);
    }

    public async Task<Food> CreateFood(Food food)
    {
        return await _repository.CreateFood(food);
    }
}