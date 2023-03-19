using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AGUIRRE_Mongo_SM53.Models
{
    public class personajes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("nombre")]
        public string? nombre { get; set; }
        [BsonElement("edad")]
        public int? edad { get; set; }
        [BsonElement("poderes")]
        public string[]? poderes { get; set; }
        [BsonElement("bando")]
        public string? bando { get; set; }
    }
}
