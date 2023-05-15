using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JustEatIt.FoodAPI.Models;

public class Food
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; }
    public string Ingredients { get; set; }
    public double Price { get; set; }
}