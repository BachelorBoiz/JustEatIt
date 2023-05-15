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

    public Task<Food> GetFoodById(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateFood(Food food)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDrink(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Food> CreateFood(Food food)
    {
        throw new NotImplementedException();
    }
}