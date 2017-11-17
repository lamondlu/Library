using System;
using System.Collections.Generic;

namespace  Library.Domain.Core
{
    public interface IEventProvider
    {
        void LoadsFromHistory(IEnumerable<DomainEvent> history);

        IEnumerable<DomainEvent> GetUncommittedChanges();
    }
}
