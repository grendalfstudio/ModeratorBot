using Bot.Business.Abstractions.ServicesAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Data.DbContexts;
using Telegram.Bot.Types;
using Bot.Business.Models;
using Mapster;
using Bot.Data.Models;

namespace Bot.Business.Implementation.Services
{
    public class MuteService : IMuteService
    {
        private readonly ISettingsService _settingsService;
        private readonly BotDbContext _botDbContext;
        private readonly BotService _botService;

        public MuteService(ISettingsService settingsService, BotDbContext botDbContext, BotService botService)
        {
            _settingsService = settingsService;
            _botDbContext = botDbContext;
            _botService = botService;
        }

        public async Task AddMute(int userId, long chatId)
        {
            var permissions = new ChatPermissions
            {
                CanSendMediaMessages = false,
                CanSendMessages = false,
                CanSendOtherMessages = false,
                CanSendPolls = false
            };
            var muteDuration = (await _settingsService.GetSettings(chatId)).MuteTime;
            await _botService.Client.RestrictChatMemberAsync(chatId, userId, permissions, DateTime.Now.AddSeconds(muteDuration));
            var mute = new MuteDto
            {
                UserId = userId,
                ChatId = chatId,
                MuteDuration = muteDuration,
                MuteTime = (new DateTimeOffset(DateTime.Now)).ToUnixTimeSeconds()
            };
            await _botDbContext.Mutes.Create(mute.Adapt<Mute>());
            var createdMute = (await _botDbContext.Mutes.GetFiltered(m => m.UserId == userId)).FirstOrDefault();
            await Task.Delay(muteDuration * 1000);
            await _botDbContext.Mutes.DeleteById(createdMute.Id);
        }

        public async Task<List<int>> GetMutedUsers(long chatId)
        {
            var mutes = await _botDbContext.Mutes.GetFiltered(m => m.ChatId == chatId);
            var muteUsers = mutes.Select(m => m.UserId).ToList();
            return muteUsers;
        }
    }
}
