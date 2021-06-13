using Bot.Business.Abstractions.ServicesAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Data.DbContexts;
using Telegram.Bot.Types;

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

        public async Task AddMute(long muteDuration, int userId, long chatId)
        {
            var permissions = new ChatPermissions
            {
                CanSendMediaMessages = false,
                CanSendMessages = false,
                CanSendOtherMessages = false,
                CanSendPolls = false
            };
            var result = await _botService.Client.RestrictChatMemberAsync(chatId, userId, permissions, DateTime.Now.AddSeconds(muteDuration));
        }

        public Task<List<long>> GetMutedUsers(long chatId)
        {
            throw new NotImplementedException();
        }
    }
}
