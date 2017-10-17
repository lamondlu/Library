

namespace BookingLibrary.Domain.Core.Commands
{
    public class CommonCommand : CommandBase<CommandExecuteResult>
    {
        public CommonCommand(string key) : base(key)
        {

        }
    }
}
