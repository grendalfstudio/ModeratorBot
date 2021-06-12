using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Bot.Business.Abstractions.ServicesAbstractions
{
    public interface IDeleteMessageService
    {
        void DeleteMessage(int messageId);
        List<Message> GetDeletedMessages(int? userId, int chatId);
    }
}
