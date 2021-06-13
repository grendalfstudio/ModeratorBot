using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bot.Business.Abstractions.ServicesAbstractions;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Bot.Business.Implementation.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IBotService _botService;
        private readonly ILogger<UpdateService> _logger;
        private readonly ICheckMessageService _checkMessageService;

        public UpdateService(IBotService botService, ILogger<UpdateService> logger, ICheckMessageService checkMessageService)
        {
            _botService = botService;
            _logger = logger;
            _checkMessageService = checkMessageService;
        }

        public async Task HandleUpdateAsync(Update update)
        {
            if (update.Type != UpdateType.Message)
                return;

            var message = update.Message;

            _logger.LogInformation("Received Message from {0}", message.Chat.Id);

            await _checkMessageService.CheckMessageContent(message);
        }
    }
}
