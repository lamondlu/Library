using System;

namespace BookingLibrary.Domain.Core.Messaging
{
    public interface IEventSubscriber : IDisposable
    {
        void Subscribe<T>(T domainEvent) where T: DomainEvent;
    }
}