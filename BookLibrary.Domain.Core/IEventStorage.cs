using BookLibrary.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Core
{
    public interface IEventStorage
    {
        IEnumerable<DomainEvent> GetEvents(Guid aggregateId);

        void Save(AggregateRoot aggregate, Guid commandUniqueId);
    }
}
