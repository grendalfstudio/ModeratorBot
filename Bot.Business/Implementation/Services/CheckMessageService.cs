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

        public CheckResult CheckMessageContent(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
