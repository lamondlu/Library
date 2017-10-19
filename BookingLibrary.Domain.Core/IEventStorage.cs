using BookingLibrary.Domain.Core;
using BookingLibrary.Domain.Core.EventStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.Domain.Core
{
    public interface IEventStorage
    {
        IEnumerable<DomainEvent> GetEvents(Guid aggregateId);

        void Save(AggregateRoot aggregate);
    }
}
