using HotChocolate;
using HotChocolate.Data;
using JustEatIt.OrderAPI.Models;
using JustEatIt.OrderAPI.Services;

namespace JustEatIt.OrderAPI.Queries;

public class Query
{
    [UseFiltering]
    public async Task<List<Order>> GetOrders([Service] IOrderService service)
    {
        return await service.GetAllOrders();
    }
}