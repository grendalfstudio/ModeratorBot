using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Models
{
    public class MessageDto
    {
        public string Id { get; set; }
        public long UserId { get; set; }
        public long ChatId { get; set; }
        public long Date { get; set; }
        public string Text { get; set; }
        public bool ContainsAudio { get; set; }
        public long Photo { get; set; }
        public long Sticker { get; set; }
        public long Animation { get; set; }
        public string Caption { get; set; }
    }
}
