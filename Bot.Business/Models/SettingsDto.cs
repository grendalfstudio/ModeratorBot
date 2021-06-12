using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Models
{
    public class SettingsDto
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public List<int> RestrictedWords { get; set; }
        public List<int> ExcludedWords { get; set; }
        public List<int> RestrictedLinks { get; set; }
        public int MuteTime { get; set; }
        public int MaxReportCount { get; set; }
    }
}
