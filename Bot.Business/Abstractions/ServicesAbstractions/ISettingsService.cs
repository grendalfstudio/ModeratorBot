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
        void AddRestrictedWords(List<string> words);
        void AddExcludedWords(List<string> words);
        void SetMuteTime(int time);
        void SetMaxReportCount(int count);
        SettingsDto GetSettings(int chatId);
    }
}
