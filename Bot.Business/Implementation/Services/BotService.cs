using Bot.Business.Abstractions.ServicesAbstractions;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace Bot.Business.Implementation.Services
{
    public class BotService : IBotService
    {
        private readonly BotConfiguration _config;

        public BotService(IOptions<BotConfiguration> config)
        {
            _config = config.Value;
            Client = new TelegramBotClient(_config.BotToken);
        }

        public TelegramBotClient Client { get; }
    }
}
