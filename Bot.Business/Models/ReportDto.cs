using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Models
{
    public class ReportDto
    {
        public string Id { get; set; }
        public long SourceUserId { get; set; }
        public long TargetUserId { get; set; }
        public long WarningMessage { get; set; }
        public long ReportedMessage { get; set; }

    }
}
