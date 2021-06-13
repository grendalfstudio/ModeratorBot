using Bot.Business.Abstractions.ServicesAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Data.DbContexts;

namespace Bot.Business.Implementation.Services
{
    public class MuteService : IMuteService
    {
        private readonly ISettingsService _settingsService;
        private readonly BotDbContext _botDbContext;

        public MuteService(ISettingsService settingsService, BotDbContext botDbContext)
        {
            _settingsService = settingsService;
            _botDbContext = botDbContext;
        }

        public Task AddMute(long muteDuration, long userId, long chatId)
        {
            throw new NotImplementedException();
        }

        public Task<List<long>> GetMutedUsers(long chatId)
        {
            throw new NotImplementedException();
        }
    }
}
