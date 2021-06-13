using Bot.Business.Abstractions.ServicesAbstractions;
using Bot.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Data.DbContexts;
using Mapster;
using Bot.Data.Models;

namespace Bot.Business.Implementation.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly SettingDbContext _settingDbContext;
        public SettingsService(SettingDbContext settingDbContext)
        {
            _settingDbContext = settingDbContext;
        }

        public async Task AddExcludedWords(List<string> words, long chatId)
        {
            var settings = (await _settingDbContext.Settings.GetFiltered(s => s.ChatId == chatId)).FirstOrDefault();
            foreach (string word in words)
            {
                var existingWord = (await _settingDbContext.Words.GetFiltered(w => w.Word.Equals(word))).FirstOrDefault();
                if (existingWord is not null)
                {
                    await _settingDbContext.Words.Create(new WordDto { Word = word }.Adapt<WordModel>());
                    var model = await _settingDbContext.Words.GetFiltered(w => w.Word.Equals(word));
                    settings.ExcludedWords.Add(model.FirstOrDefault().Id);
                }
            }
        }

        public async Task AddRestrictedWords(List<string> words, long chatId)
        {
            var settings = (await _settingDbContext.Settings.GetFiltered(s => s.ChatId == chatId)).FirstOrDefault();
            foreach (string word in words)
            {
                var existingWord = (await _settingDbContext.Words.GetFiltered(w => w.Word.Equals(word))).FirstOrDefault();
                if (existingWord is not null)
                {
                    await _settingDbContext.Words.Create(new WordDto { Word = word }.Adapt<WordModel>());
                    var model = await _settingDbContext.Words.GetFiltered(w => w.Word.Equals(word));
                    settings.RestrictedWords.Add(model.FirstOrDefault().Id);
                }
            }
        }

        public async Task AddRestrictedLinks(List<string> links, long chatId)
        {
            var settings = (await _settingDbContext.Settings.GetFiltered(s => s.ChatId == chatId)).FirstOrDefault();
            foreach (string url in links)
            {
                var existingLink = (await _settingDbContext.Links.GetFiltered(w => w.Url.Equals(url))).FirstOrDefault();
                if (existingLink is not null)
                {
                    await _settingDbContext.Links.Create(new LinkDto { Url = url }.Adapt<Link>());
                    var model = await _settingDbContext.Links.GetFiltered(w => w.Url.Equals(url));
                    settings.RestrictedLinks.Add(model.FirstOrDefault().Id);
                }
            }
        }

        public async Task<SettingsDto> GetSettings(long chatId)
        {
            var settings = (await _settingDbContext.Settings.GetFiltered(s => s.ChatId == chatId)).FirstOrDefault();
            return settings.Adapt<SettingsDto>();
        }

        public async Task SetMaxReportCount(short count, long chatId)
        {
            var settings = (await _settingDbContext.Settings.GetFiltered(s => s.ChatId == chatId)).FirstOrDefault();
            settings.MaxReportCount = count;
        }

        public async Task SetMuteTime(int time, long chatId)
        {
            var settings = (await _settingDbContext.Settings.GetFiltered(s => s.ChatId == chatId)).FirstOrDefault();
            settings.MuteTime = time;
        }
    }
}
