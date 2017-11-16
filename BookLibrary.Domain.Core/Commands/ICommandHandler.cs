using System;

namespace BookLibrary.Domain.Core.Commands
{
    public interface ICommandHandler<TCommand> : IDisposable where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
