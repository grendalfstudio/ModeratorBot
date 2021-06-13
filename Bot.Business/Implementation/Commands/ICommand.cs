using System.Threading.Tasks;

namespace Bot.Business.Implementation.Commands
{
    public interface ICommand
    {
        public Task ExecuteAsync();
    }
}