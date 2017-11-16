
using System;

namespace BookLibrary.Domain.Core.DataAccessor
{
    public interface IDomainRepository
    {
        T GetById<T>(Guid id) where T : AggregateRoot, new();

        void Save<T>(T aggregateRoot, int expectedVersion, Guid commandUniqueId) where T : AggregateRoot, new();
    }
}
