using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core;
using BookingLibrary.Domain.Core.EventStorage;

namespace BookingLibrary.Infrastructure.EventStorage.SQLServer
{
    public class SQLServerEventStorage : IEventStorage
    {
        public IEnumerable<DomainEvent> GetEvents(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        public BaseEventStorageModel GetMemento(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        public void Save(AggregateRoot aggregate)
        {
            throw new NotImplementedException();
        }

        public void SaveMemento(BaseEventStorageModel memento)
        {
            throw new NotImplementedException();
        }
    }
}
