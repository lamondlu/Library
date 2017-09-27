using System;
using System.Collections.Generic;

namespace BookingLibrary.Domain.Core
{
    public interface IEventProvider
    {
        void LoadsFromHistory(IEnumerable<DomainEvent> history);

        IEnumerable<DomainEvent> GetUncommittedChanges();
    }
}
