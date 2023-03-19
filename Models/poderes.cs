using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AGUIRRE_Mongo_SM53.Models
{
    public class poderes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nombre")]
        public string? nombre { get; set; }
        [BsonElement("damage")]
        public int? damage { get; set; }
        [BsonElement("clase")]
        public string? clase { get; set; }
    }
}
