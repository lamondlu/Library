using System;

namespace BookLibrary.Domain.Core
{
    public interface IHandler<TEvent> where TEvent : IDomainEvent
    {
        void Handle(TEvent evt);
    }
}