using System;

namespace BookingLibrary.Domain.Core.Messaging
{
    public interface ICommandPublisher : IDisposable
    {
        void Publish<ICommand>(ICommand command);
    }
}