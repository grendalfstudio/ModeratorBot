using Bot.Business.Abstractions.ServicesAbstractions;
using Bot.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Implementation.Services
{
    public class CheckTextService : ICheckTextService
    {
        private readonly ISettingsService _settingsService;

        public CheckTextService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public CheckResult Check(string text, int chatId)
        {
            throw new NotImplementedException();
        }
    }
}
