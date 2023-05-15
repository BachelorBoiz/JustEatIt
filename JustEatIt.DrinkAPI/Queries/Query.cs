using JustEatIt.DrinkAPI.Models;
using JustEatIt.DrinkAPI.Services;

namespace JustEatIt.DrinkAPI.Queries
{
    public class Query
    {
        public async Task<List<Drink>> GetDrinks([Service] IDrinkService service)
        {
            return await service.GetAllDrinks();
        }
    }
}
