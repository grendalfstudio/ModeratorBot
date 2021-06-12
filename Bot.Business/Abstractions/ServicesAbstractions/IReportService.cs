using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Abstractions.ServicesAbstractions
{
    public interface IReportService
    {
        int CountReports(int userId, int chatId);
        void AddNewReport(int reportedMessage);
        void MuteUser(int userId);
        void DeleteMessage(int messageId);
    }
}
