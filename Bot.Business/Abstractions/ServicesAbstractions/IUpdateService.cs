using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Bot.Business.Abstractions.ServicesAbstractions
{
    public interface IUpdateService
    {
        Task HandleUpdateAsync(Update update);
    }
}
