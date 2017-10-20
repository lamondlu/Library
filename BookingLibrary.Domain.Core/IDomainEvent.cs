using System;

namespace BookingLibrary.Domain.Core
{
    public interface IDomainEvent
    {
        string EventKey { get; }

        DateTime OccurredOn { get; }

        Entity EventSource { get; }
    }
}
