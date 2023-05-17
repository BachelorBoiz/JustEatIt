using JustEatIt.OrderAPI.Models;

namespace JustEatIt.OrderAPI.Infrastructure;

public interface IOrderRepository
{
    Task<List<Order>> GetAllOrders();
    Task<Order> GetOrderById(string id);
    Task UpdateOrder(Order order);
    Task DeleteOrder(string id);
    Task<Order> CreateOrder(Order order);
}