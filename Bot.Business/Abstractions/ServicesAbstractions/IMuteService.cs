using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Abstractions.ServicesAbstractions
{
    public interface IMuteService
    {
        Task AddMute(int userId, long chatId);
        Task<List<int>> GetMutedUsers(long chatId);
    }
}
