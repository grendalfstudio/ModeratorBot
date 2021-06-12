using Bot.Data.Abstractions;
using Bot.Data.Models;

namespace Bot.Data.DbContexts
{
    public class SettingDbContext
    {
        public SettingDbContext(IRepository<WordModel> words, IRepository<Link> links, IRepository<Settings> settings)
        {
            Words = words;
            Links = links;
            Settings = settings;
        }

        public IRepository<WordModel> Words { get; }
        public IRepository<Link> Links { get; }
        public IRepository<Settings> Settings { get; }
    }
}