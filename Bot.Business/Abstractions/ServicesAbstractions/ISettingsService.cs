using Bot.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Abstractions.ServicesAbstractions
{
    public interface ISettingsService
    {
        Task AddRestrictedWords(List<string> words, long chatId);
        Task AddExcludedWords(List<string> words, long chatId);
        Task AddRestrictedLinks(List<string> links, long chatId);
        Task SetMuteTime(int time, long chatId);
        Task SetMaxReportCount(short count, long chatId);
        Task<SettingsDto> GetSettings(long chatId);
    }
}
