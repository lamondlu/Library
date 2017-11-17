using System;
using  Library.Domain.Core.Commands;

namespace  Library.Domain.Core.Messaging
{
    public interface ICommandSubscriber : IDisposable
    {
        void Subscribe<T>(T command) where T: ICommand;
    }
}