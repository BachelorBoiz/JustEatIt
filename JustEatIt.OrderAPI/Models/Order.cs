using JustEatIt.DrinkAPI.Models;
using JustEatIt.FoodAPI.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JustEatIt.OrderAPI.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string CustomerName { get; set; }
        public List<Food> Foods { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}
