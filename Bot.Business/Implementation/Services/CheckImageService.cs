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
    public class CheckImageService : ICheckImageService
    {
        private readonly ISettingsService _settingsService;

        public CheckImageService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public CheckResult Check(PhotoSize photo, int chatId)
        {
            throw new NotImplementedException();
        }
    }
}
