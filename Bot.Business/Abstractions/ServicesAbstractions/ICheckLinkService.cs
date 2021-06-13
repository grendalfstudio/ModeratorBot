using Bot.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Abstractions.ServicesAbstractions
{
    public interface ICheckLinkService
    {
        Task<CheckResult> Check(string url, long chatId);
    }
}
