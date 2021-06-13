using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Business.Abstractions.ServicesAbstractions;
using Bot.Data.DbContexts;
using Telegram.Bot.Types;

namespace Bot.Business.Implementation.Services
{
    public class DeleteMessageService : IDeleteMessageService
    {
        private readonly BotDbContext _botDbContext;
        private readonly ISettingsService _settingsService;

        public DeleteMessageService(ISettingsService settingsService, BotDbContext botDbContext)
        {
            _settingsService = settingsService;
            _botDbContext = botDbContext;
        }

        public async Task DeleteMessage(long messageId)
        {
            //Client delete message on chat
            await _botDbContext.Messages.DeleteById(messageId.ToString());
        }

        public Task<List<Message>> GetDeletedMessages(long? userId, long chatId)
        {
            throw new NotImplementedException();
        }
    }
}
