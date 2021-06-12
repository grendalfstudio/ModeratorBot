using Bot.Data.Abstractions;

namespace Bot.Data.Models
{
    public class SettingDatabaseSettings : ISettingDatabaseSettings
    {
        public string WordCollectionName { get; set; }
        public string LinkCollectionName { get; set; }
        public string SettingCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}