using JustEatIt.OrderAPI.Models;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JustEatIt.OrderAPI.Infrastructure;

public class OrderRepository : IOrderRepository
{
    private readonly IMongoCollection<Order> _orders;

    public OrderRepository(IOptions<DatabaseSettings> options)
    {
        var mongoClient = new MongoClient(
            options.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(
            options.Value.DatabaseName);
        _orders = mongoDatabase.GetCollection<Order>(
            options.Value.OrdersCollectionName);
    }
    
    public async Task<List<Order>> GetAllOrders()
    {
        return await _orders.Find(_ => true).ToListAsync();
    }

    public async Task<Order> GetOrderById(string id)
    {
        return await _orders.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task UpdateOrder(Order order)
    {
        var filter = Builders<Order>.Filter.Eq(x => x.Id, order.Id);
        var update = Builders<Order>.Update
            .Set(x => x.Drinks, order.Drinks)
            .Set(x => x.Foods, order.Foods)
            .Set(x => x.CustomerName, order.CustomerName);

        await _orders.UpdateOneAsync(filter, update);
    }

    public async Task DeleteOrder(string id)
    {
        await _orders.DeleteOneAsync(order => order.Id == id);
    }

    public async Task<Order> CreateOrder(Order order)
    {
        await _orders.InsertOneAsync(order);
        return order;
    }
}