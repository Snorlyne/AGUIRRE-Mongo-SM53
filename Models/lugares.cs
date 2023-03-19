using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AGUIRRE_Mongo_SM53.Models
{
    public class lugares
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nombre")]
        public string? nombre { get; set; }
        [BsonElement("personajes")]
        public string[]? personajes { get; set; }

    }
}
