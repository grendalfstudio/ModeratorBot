using Bot.Data.Abstractions;

namespace Bot.Data.Models
{
    public class BotDatabaseSettings : IBotDatabaseSettings
    {
        public string MessageCollectionName { get; set; }
        public string MuteCollectionName { get; set; }
        public string ReportCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}