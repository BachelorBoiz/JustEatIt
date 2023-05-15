using JustEatIt.FoodAPI.Models;
using JustEatIt.FoodAPI.Services;

namespace JustEatIt.FoodAPI.Queries;

public class Query
{
    public async Task<List<Food>> GetFoods([Service] IFoodService service)
    {
        return await service.GetAllFoods();
    }
}