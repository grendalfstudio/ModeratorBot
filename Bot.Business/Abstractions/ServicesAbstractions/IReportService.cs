using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Abstractions.ServicesAbstractions
{
    public interface IReportService
    {
        Task<long> CountReports(int userId, long chatId);
        Task AddNewReport(long reportedMessage);
        Task MuteUser(int userId);
        Task DeleteMessage(long messageId);
    }
}
