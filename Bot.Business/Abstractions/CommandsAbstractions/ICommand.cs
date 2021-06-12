using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Bot.Business.Abstractions.CommandsAbstractions
{
    public interface ICommand
    {
        BotCommand BotCommand { get; set; }
        void Execute();
    }
}
