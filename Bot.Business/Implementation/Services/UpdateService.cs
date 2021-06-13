using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bot.Business.Abstractions.ServicesAbstractions;
using Bot.Business.Implementation.Commands;
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

            if (message.Entities is not null && message.Entities.Any(e => e.Type == MessageEntityType.BotCommand))
                await HandleCommand(message);
            else
                await _checkMessageService.CheckMessageContent(message);
        }

        private async Task HandleCommand(Message message)
        {
            var commandEntity = message.Entities.FirstOrDefault(e => e.Type == MessageEntityType.BotCommand);
            var command = message.EntityValues.ElementAt(Array.IndexOf(message.Entities, commandEntity));
            var isGroup = message.Chat.Type is not ChatType.Private or ChatType.Channel;
            switch (command)
            {
                case BotCommands.StartCommand:
                    await (new StartCommand(
                        _botService,
                        message.Chat.Id,
                        message.MessageId,
                        isGroup))
                        .ExecuteAsync();
                    break;
                case BotCommands.HelpCommand:
                    break;
                case BotCommands.AddExcludedWordsCommand:
                    break;
                case BotCommands.AddRestrictedWordsCommand:
                    break;
                case BotCommands.GetExcludedWordsCommand:
                    break;
                case BotCommands.GetMuteTimeCommand:
                    break;
                case BotCommands.GetRestrictedWordsCommand:
                    break;
                case BotCommands.RemoveExcludedWordCommand:
                    break;
                case BotCommands.RemoveRestrictedWordCommand:
                    break;
                case BotCommands.SetMuteTimeCommand:
                    break;
                case BotCommands.GetMaxReportCountCommand:
                    break;
                case BotCommands.SetMaxReportCountCommand:
                    break;
                case BotCommands.ReportCommand:
                    break;
                case BotCommands.MuteCommand:
                    break;
                default:
                    await _botService.Client.SendTextMessageAsync(message.Chat.Id,
                        "Unsupported command. Use /help to get list of available commands");
                    break;
            }
        }
    }
}
