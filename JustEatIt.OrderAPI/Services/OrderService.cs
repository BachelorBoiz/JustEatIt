using JustEatIt.OrderAPI.Infrastructure;
using JustEatIt.OrderAPI.Models;

namespace JustEatIt.OrderAPI.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Order>> GetAllOrders()
    {
        return await _repository.GetAllOrders();
    }

    public async Task<Order> GetOrderById(string id)
    {
        return await _repository.GetOrderById(id);
    }

    public async Task UpdateOrder(Order order)
    {
        await _repository.UpdateOrder(order);
    }

    public async Task DeleteOrder(string id)
    {
        await _repository.DeleteOrder(id);
    }

    public async Task<Order> CreateOrder(Order order)
    {
        return await _repository.CreateOrder(order);
    }
}