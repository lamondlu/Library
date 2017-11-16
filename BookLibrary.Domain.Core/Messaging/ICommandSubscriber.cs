using System;
using BookLibrary.Domain.Core.Commands;

namespace BookLibrary.Domain.Core.Messaging
{
    public interface ICommandSubscriber : IDisposable
    {
        void Subscribe<T>(T command) where T: ICommand;
    }
}