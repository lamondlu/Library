using System;
using System.Collections.Generic;

namespace BookLibrary.Domain.Core
{
    public interface IEventProvider
    {
        void LoadsFromHistory(IEnumerable<DomainEvent> history);

        IEnumerable<DomainEvent> GetUncommittedChanges();
    }
}
