using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bot.Data.Models
{
    public class Report
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public long SourceUserId { get; set; }
        public long TargetUserId { get; set; }
        public long WarningMessage { get; set; }
        public long ReportedMessage { get; set; }

    }
}
