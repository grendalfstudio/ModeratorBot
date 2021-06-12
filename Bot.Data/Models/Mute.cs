using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bot.Data.Models
{
    public class Mute
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public int MuteDuration { get; set; }
        public int MuteTime { get; set; }
        public int MessageId { get; set; }
    }
}
