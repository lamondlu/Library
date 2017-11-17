using System;
using  Library.Domain.Core.Commands;

namespace  Library.Domain.Core.Messaging
{
    public interface ICommandPublisher : IDisposable
    {
        void Publish<T>(T command) where T: ICommand;
    }
}