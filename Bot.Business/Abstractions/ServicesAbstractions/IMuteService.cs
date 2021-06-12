using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Abstractions.ServicesAbstractions
{
    public interface IMuteService
    {
        void AddMute(int muteDuration, int userId, int chatId);
        List<int> GetMutedUsers(int chatId);
    }
}
