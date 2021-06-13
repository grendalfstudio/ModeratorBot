using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Business.Abstractions.ServicesAbstractions;
using Telegram.Bot.Types;

namespace Bot.Business.Implementation.Services
{
    public class DeleteMessageService : IDeleteMessageService
    {
        //UnitOfWork here
        private readonly ISettingsService _settingsService;

        public DeleteMessageService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
            //UnitOfWork here
        }

        public void DeleteMessage(long messageId)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetDeletedMessages(long? userId, long chatId)
        {
            throw new NotImplementedException();
        }
    }
}
