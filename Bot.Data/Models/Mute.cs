using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bot.Data.Models
{
    public class Mute
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ChatId { get; set; }
        public int MuteDuration { get; set; }
        public int MuteTime { get; set; }
        public long MessageId { get; set; }
    }
}
