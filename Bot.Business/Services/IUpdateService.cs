using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Bot.Business.Services
{
    public interface IUpdateService
    {
        Task EchoAsync(Update update);
    }
}
