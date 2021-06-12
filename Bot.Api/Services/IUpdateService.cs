using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Bot.Api.Services
{
    public interface IUpdateService
    {
        Task EchoAsync(Update update);
    }
}
