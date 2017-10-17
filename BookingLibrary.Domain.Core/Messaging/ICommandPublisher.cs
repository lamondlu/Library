using System;
using BookingLibrary.Domain.Core.Commands;

namespace BookingLibrary.Domain.Core.Messaging
{
    public interface ICommandPublisher : IDisposable
    {
        void Publish<T>(T command) where T: ICommand;
    }
}