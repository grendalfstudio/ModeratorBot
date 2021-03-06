using Bot.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Bot.Business.Abstractions.ServicesAbstractions
{
    public interface ICheckVoiceService
    {
        Task<CheckResult> Check(Voice voice, long chatId);
    }
}
