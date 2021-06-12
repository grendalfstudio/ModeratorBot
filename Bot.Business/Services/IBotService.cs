using Telegram.Bot;

namespace Bot.Business.Services
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
    }
}