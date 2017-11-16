using System;

namespace BookLibrary.Domain.Core
{
    public interface IDomainEvent
    {
        string EventKey { get; }

        DateTime OccurredOn { get; }

        Guid CommandUniqueId { get; set;}
    }
}
