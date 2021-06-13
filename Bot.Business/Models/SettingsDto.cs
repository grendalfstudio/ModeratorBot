using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Models
{
    public class SettingsDto
    {
        public string Id { get; set; }
        public long ChatId { get; set; }
        public List<string> RestrictedWords { get; set; }
        public List<string> ExcludedWords { get; set; }
        public List<string> RestrictedLinks { get; set; }
        public int MuteTime { get; set; }
        public short MaxReportCount { get; set; }
    }
}
