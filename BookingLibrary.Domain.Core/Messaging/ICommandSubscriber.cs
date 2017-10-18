using System;
using BookingLibrary.Domain.Core.Commands;

namespace BookingLibrary.Domain.Core.Messaging
{
    public interface ICommandSubscriber : IDisposable
    {
        void Subscribe<T>(T command) where T: ICommand;
    }
}