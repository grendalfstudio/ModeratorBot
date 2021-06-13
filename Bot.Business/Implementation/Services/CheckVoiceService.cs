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
    public class CheckVoiceService : ICheckVoiceService
    {
        private readonly ISettingsService _settingsService;

        public CheckVoiceService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public async Task<CheckResult> Check(Voice voice, long chatId)
        {
            return CheckResult.NeedBan;
        }
    }
}
