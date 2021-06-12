using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bot.Data.Models
{
    public class Report
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public int SourceUserId { get; set; }
        public int TargetUserId { get; set; }
        public int WarningMessage { get; set; }
        public int ReportedMessage { get; set; }

    }
}
