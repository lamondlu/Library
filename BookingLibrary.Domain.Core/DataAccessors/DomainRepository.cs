using BookingLibrary.Domain.Core;
using BookingLibrary.Domain.Core.EventStorage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.Domain.Core.DataAccessor
{
    public class DomainRepository : IDomainRepository
    {
        private IEventStorage _eventStorage = null;
        private static object _lockStorage = new object();

        public DomainRepository(IEventStorage eventStorage)
        {
            _eventStorage = eventStorage;
        }

        public T GetById<T>(Guid id) where T : AggregateRoot, new()
        {
            IEnumerable<DomainEvent> events;
            events = _eventStorage.GetEvents(id);
            var obj = new T();

            if (events.Count() > 0)
            {
                obj.LoadsFromHistory(events);
            }

            return obj;
        }

        public void Save<T>(T aggregateRoot, int expectedVersion) where T : AggregateRoot, new()
        {
            if (aggregateRoot.GetUncommittedChanges().Any())
            {
                lock (_lockStorage)
                {
                    var item = new T();

                    if (expectedVersion != -1)
                    {
                        item = GetById<T>(aggregateRoot.Id);
                        if (item.Version != expectedVersion)
                        {
                            throw new DBConcurrencyException(string.Format("Aggregate {0} has been previously modified", item.Id));
                        }
                    }

                    _eventStorage.Save(aggregateRoot);
                }
            }
        }
    }
}
