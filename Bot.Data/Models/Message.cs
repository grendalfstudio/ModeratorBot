using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bot.Data.Models
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int UserId { get; set; }
        public long ChatId { get; set; }
        public long Date { get; set; }
        public string Text { get; set; }
        public bool ContainsAudio { get; set; }
        public long Photo { get; set; }
        public long Sticker { get; set; }
        public long Animation { get; set; }
        public string Caption { get; set; }
    }
}
