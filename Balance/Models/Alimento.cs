using MongoDB.Bson.Serialization.Attributes;

namespace Balance.Models
{
    public class Alimento
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Id { get; set; }
        [BsonElement("nome"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Nome { get; set; }
        [BsonElement("kcal"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int KCAL { get; set; }
    }
}
