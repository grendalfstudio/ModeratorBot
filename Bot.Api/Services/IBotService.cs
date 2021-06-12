using Telegram.Bot;

namespace Bot.Api.Services
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
    }
}