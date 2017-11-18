using System;

namespace Library.Domain.Core.Messaging
{
    public interface IEventPublisher : IDisposable
    {
        void Publish<T>(T domainEvent) where T : DomainEvent;
    }
}