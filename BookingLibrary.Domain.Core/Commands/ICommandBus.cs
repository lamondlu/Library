using System.Threading.Tasks;

namespace BookingLibrary.Domain.Core.Commands
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : ICommand;

        Task SendAsync<T>(T command) where T : ICommand;
    }
}
