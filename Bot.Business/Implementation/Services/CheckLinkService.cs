using Bot.Business.Abstractions.ServicesAbstractions;
using Bot.Business.Models.Enums;
using Bot.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Implementation.Services
{
    public class CheckLinkService : ICheckLinkService
    {
        private readonly ISettingsService _settingsService;
        private readonly SettingDbContext _settingDbContext;

        public CheckLinkService(ISettingsService settingsService, SettingDbContext settingDbContext)
        {
            _settingsService = settingsService;
            _settingDbContext = settingDbContext;
        }

        public async Task<CheckResult> Check(string url, long chatId)
        {
            var settings = await _settingsService.GetSettings(chatId);
            var restrictedLinks = (await _settingDbContext.Links.GetFiltered(l => settings.RestrictedLinks.Contains(l.Id))).Select(l => l.Url);
            if (restrictedLinks.Any(l => url.Contains(l)))
            {
                return CheckResult.NeedBan;
            }
            return CheckResult.Ok;
        }
    }
}
