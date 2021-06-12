namespace Bot.Data.Abstractions
{
    public interface ISettingDatabaseSettings
    {
        public string WordCollectionName { get; set; }
        public string LinkCollectionName { get; set; }
        public string SettingCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}