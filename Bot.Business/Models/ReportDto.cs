using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Models
{
    public class ReportDto
    {
        public int Id { get; set; }
        public int SourceUserId { get; set; }
        public int TargetUserId { get; set; }
        public int WarningMessage { get; set; }
        public int ReportedMessage { get; set; }

    }
}
