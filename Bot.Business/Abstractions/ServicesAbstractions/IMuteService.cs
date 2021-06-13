using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Abstractions.ServicesAbstractions
{
    public interface IMuteService
    {
        Task AddMute(long muteDuration, long userId, long chatId);
        Task<List<long>> GetMutedUsers(long chatId);
    }
}
