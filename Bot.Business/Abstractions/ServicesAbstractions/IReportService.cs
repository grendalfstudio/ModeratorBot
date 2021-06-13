using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Abstractions.ServicesAbstractions
{
    public interface IReportService
    {
        long CountReports(long userId, long chatId);
        void AddNewReport(long reportedMessage);
        void MuteUser(long userId);
        void DeleteMessage(long messageId);
    }
}
