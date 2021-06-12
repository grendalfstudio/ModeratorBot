using Telegram.Bot;

namespace Bot.Business.Abstractions.ServicesAbstractions
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
    }
}