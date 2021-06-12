using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Models
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public int Date { get; set; }
        public string Text { get; set; }
        public bool ContainsAudio { get; set; }
        public int Photo { get; set; }
        public int Sticker { get; set; }
        public int Animation { get; set; }
        public string Caption { get; set; }
    }
}
