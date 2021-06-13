using Bot.Business.Abstractions.ServicesAbstractions;
using Bot.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Bot.Business.Implementation.Services
{
    public class CheckMessageService : ICheckMessageService
    {
        private readonly ICheckTextService _checkTextService;
        private readonly ICheckVoiceService _checkVoiceService;
        private readonly ICheckLinkService _checkLinkService;
        private readonly ICheckImageService _checkImageService;

        public CheckMessageService(ICheckTextService checkTextService, ICheckVoiceService checkVoiceService,
            ICheckLinkService checkLinkService, ICheckImageService checkImageService)
        {
            _checkTextService = checkTextService;
            _checkVoiceService = checkVoiceService;
            _checkLinkService = checkLinkService;
            _checkImageService = checkImageService;
        }

        public async Task<CheckResult> CheckMessageContent(Message message)
        {
            var result = CheckResult.Ok;
            switch (message.Type)
            {
                case Telegram.Bot.Types.Enums.MessageType.Text:
                    result = await CheckTextMessage(message);
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Voice:
                    result = await _checkVoiceService.Check(message.Voice, message.Chat.Id);
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Photo:
                    result = await _checkImageService.Check(message.Photo.LastOrDefault(), message.Chat.Id);
                    break;
                default:
                    break;
            }
            return result;
        }

        private async Task<CheckResult> CheckTextMessage(Message message)
        {
            var result = CheckResult.Ok;
            if (message.Entities is not null && message.Entities.Where(e => e.Type.Equals("url")).Any())
            {
                var url = message.Entities.Where(e => e.Type.Equals("url")).FirstOrDefault();
                var urlText = message.Text.Substring(url.Offset, url.Length);
                result = await _checkLinkService.Check(urlText, message.Chat.Id);
            }
            if (result == CheckResult.NeedBan)
            {
                return result;
            }
            result = await _checkTextService.Check(message.Text, message.Chat.Id);
            return result;
        }
    }
}
