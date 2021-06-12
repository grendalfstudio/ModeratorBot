using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bot.Data.Models
{
    public class Settings
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public int ChatId { get; set; }
        public IList<int> RestrictedWords { get; set; }
        public IList<int> ExcludedWords { get; set; }
        public IList<int> RestrictedLinks { get; set; }
        public int MuteTime { get; set; }
        public int MaxReportCount { get; set; }
    }
}
