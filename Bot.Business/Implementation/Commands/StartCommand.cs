using System.Threading.Tasks;
using Bot.Business.Abstractions.ServicesAbstractions;
using Telegram.Bot.Types;

namespace Bot.Business.Implementation.Commands
{
    public class StartCommand : ICommand
    {
        private readonly IBotService _botService;
        private readonly ChatId _chatId;
        private readonly int _messageId;
        private readonly bool _isGroup;

        public StartCommand(IBotService botService, ChatId chatId, int messageId, bool isGroup)
        {
            _botService = botService;
            _chatId = chatId;
            _messageId = messageId;
            _isGroup = isGroup;
        }
        
        public async Task ExecuteAsync()
        {
            var text = _isGroup ? 
                "Hello! Use commands to set up bot" : 
                "Hello! For now bot works only as group member, so add it to group and set up";
            await _botService.Client.SendTextMessageAsync(_chatId, text, replyToMessageId: _messageId);
        }
    }
}