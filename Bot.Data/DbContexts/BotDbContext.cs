using Bot.Data.Abstractions;
using Bot.Data.Models;

namespace Bot.Data.DbContexts
{
    public class BotDbContext
    {
        public BotDbContext(IRepository<Message> messages, IRepository<Report> reports, IRepository<Mute> mutes)
        {
            Messages = messages;
            Reports = reports;
            Mutes = mutes;
        }

        public IRepository<Message> Messages { get; }
        public IRepository<Report> Reports { get; }
        public IRepository<Mute> Mutes { get; }
    }
}