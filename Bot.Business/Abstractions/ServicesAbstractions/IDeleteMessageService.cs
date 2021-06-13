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
        Task DeleteMessage(long messageId);
        Task<List<Message>> GetDeletedMessages(long? userId, long chatId);
    }
}
