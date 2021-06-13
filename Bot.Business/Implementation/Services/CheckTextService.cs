using Bot.Business.Abstractions.ServicesAbstractions;
using Bot.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Data.DbContexts;

namespace Bot.Business.Implementation.Services
{
    public class CheckTextService : ICheckTextService
    {
        private readonly ISettingsService _settingsService;
        private readonly SettingDbContext _settingDbContext;

        public CheckTextService(ISettingsService settingsService, SettingDbContext settingDbContext)
        {
            _settingsService = settingsService;
            _settingDbContext = settingDbContext;
        }

        public async Task<CheckResult> Check(string text, long chatId)
        {
            var settings = await _settingsService.GetSettings(chatId);
            var restrictedWords = (await _settingDbContext.Words.GetFiltered(w => settings.RestrictedWords.Contains(w.Id))).Select(w => w.Word);
            var excludedWords = (await _settingDbContext.Words.GetFiltered(w => settings.ExcludedWords.Contains(w.Id))).Select(w => w.Word);
            if (restrictedWords.Any(w => text.Contains(w, StringComparison.OrdinalIgnoreCase)))
            {
                if (excludedWords.Any(w => text.Contains(w, StringComparison.OrdinalIgnoreCase)))
                {
                    return CheckResult.Ok;
                }
                return CheckResult.NeedBan;
            }
            return CheckResult.Ok;
        }
    }
}
