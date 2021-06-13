using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bot.Data.Models
{
    public class WordModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public long Id { get; set; }
        public string Word { get; set; }
    }
}
