using System;
using BookLibrary.Domain.Core.Commands;

namespace BookLibrary.Domain.Core.Messaging
{
    public interface ICommandPublisher : IDisposable
    {
        void Publish<T>(T command) where T: ICommand;
    }
}