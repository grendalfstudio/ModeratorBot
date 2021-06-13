using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Models
{
    public class SettingsDto
    {
        public long Id { get; set; }
        public long ChatId { get; set; }
        public List<long> RestrictedWords { get; set; }
        public List<long> ExcludedWords { get; set; }
        public List<long> RestrictedLinks { get; set; }
        public int MuteTime { get; set; }
        public short MaxReportCount { get; set; }
    }
}
