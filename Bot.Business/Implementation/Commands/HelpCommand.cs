using System.Linq;
using System.Threading.Tasks;
using Bot.Business.Abstractions.ServicesAbstractions;
using Telegram.Bot.Types;

namespace Bot.Business.Implementation.Commands
{
    public class HelpCommand : ICommand
    {
        private readonly IBotService _botService;
        private readonly ChatId _chatId;

        public HelpCommand(IBotService botService, ChatId chatId)
        {
            _botService = botService;
            _chatId = chatId;
        }


        public async Task ExecuteAsync()
        {
            var commands = await _botService.Client.GetMyCommandsAsync();
            var helpMsg = commands.Aggregate(
                    "Available commands:\n", 
                    (current, command) => current + $"{command.Command} - {command.Description}\n");
            await _botService.Client.SendTextMessageAsync(_chatId, helpMsg);
        }
    }
}