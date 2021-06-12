using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bot.Data.Models
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public int Date { get; set; }
        public string Text { get; set; }
        public bool ContainsAudio { get; set; }
        public int Photo { get; set; }
        public int Sticker { get; set; }
        public int Animation { get; set; }
        public string Caption { get; set; }
    }
}
