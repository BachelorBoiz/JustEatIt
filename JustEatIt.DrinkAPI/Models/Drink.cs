using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JustEatIt.DrinkAPI.Models
{
    public class Drink
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Ml { get; set; }
        public string Type { get; set; }
    }
}
