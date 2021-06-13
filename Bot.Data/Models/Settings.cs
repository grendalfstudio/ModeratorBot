using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bot.Data.Models
{
    public class Settings
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public long Id { get; set; }
        public long ChatId { get; set; }
        public IList<long> RestrictedWords { get; set; }
        public IList<long> ExcludedWords { get; set; }
        public IList<long> RestrictedLinks { get; set; }
        public int MuteTime { get; set; }
        public short MaxReportCount { get; set; }
    }
}
