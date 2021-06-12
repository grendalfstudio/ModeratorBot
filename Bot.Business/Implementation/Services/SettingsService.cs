using Bot.Business.Abstractions.ServicesAbstractions;
using Bot.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Implementation.Services
{
    public class SettingsService : ISettingsService
    {
        //Here must be UnitOfWork
        public SettingsService()
        {
            //Here must be UnitOfWork
        }

        public void AddExcludedWords(List<string> words)
        {
            throw new NotImplementedException();
        }

        public void AddRestrictedWords(List<string> words)
        {
            throw new NotImplementedException();
        }

        public SettingsDto GetSettings(int chatId)
        {
            throw new NotImplementedException();
        }

        public void SetMaxReportCount(int count)
        {
            throw new NotImplementedException();
        }

        public void SetMuteTime(int time)
        {
            throw new NotImplementedException();
        }
    }
}
