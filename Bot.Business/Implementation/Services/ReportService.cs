using Bot.Business.Abstractions.ServicesAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Implementation.Services
{
    public class ReportService : IReportService
    {
        private readonly ISettingsService _settingsService;
        private readonly IMuteService _muteService;
        private readonly IDeleteMessageService _deleteMessageService;

        public ReportService(ISettingsService settingsService, IMuteService muteService,
            IDeleteMessageService deleteMessageService)
        {
            _settingsService = settingsService;
            _muteService = muteService;
            _deleteMessageService = deleteMessageService;
        }

        public void AddNewReport(int reportedMessage)
        {
            throw new NotImplementedException();
        }

        public int CountReports(int userId, int chatId)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(int messageId)
        {
            throw new NotImplementedException();
        }

        public void MuteUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
