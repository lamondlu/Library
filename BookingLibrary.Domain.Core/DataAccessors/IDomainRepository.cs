
using System;

namespace BookingLibrary.Domain.Core.DataAccessor
{
    public interface IDomainRepository
    {
        T GetById<T>(Guid id) where T : AggregateRoot, new();

        void Save<T>(T aggregateRoot, int expectedVersion) where T : AggregateRoot, new();
    }
}
