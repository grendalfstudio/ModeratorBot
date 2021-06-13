﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Models
{
    public class MuteDto
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public long ChatId { get; set; }
        public int MuteDuration { get; set; }
        public long MuteTime { get; set; }
        public long MessageId { get; set; }
    }
}
