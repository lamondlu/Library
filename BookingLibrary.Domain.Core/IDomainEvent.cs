using System;

namespace BookingLibrary.Domain.Core
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }

        Entity Entity { get; }
    }
}
