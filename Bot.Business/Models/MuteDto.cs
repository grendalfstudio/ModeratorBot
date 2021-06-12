using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Models
{
    public class MuteDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public int MuteDuration { get; set; }
        public int MuteTime { get; set; }
        public int MessageId { get; set; }
    }
}
