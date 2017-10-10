using System;

namespace BookingLibrary.Domain.Core.Messaging
{
    public interface IEventPublisher : IDisposable
    {
        void Publish<DomainEvent>(DomainEvent domainEvent);
    }
}