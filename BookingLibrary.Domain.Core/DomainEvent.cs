using System;

namespace BookingLibrary.Domain.Core
{
    public class DomainEvent : IDomainEvent
    {
        private DateTime _occurredOn;
        private Entity _eventSource;

        public DomainEvent()
        {
            _occurredOn = DateTime.Now;
        }
        public int Version
        {
            get;
            set;
        }
        
        public Guid AggregateId
        {
            get;
            set;
        }

        public Entity EventSource
        {
            get
            {
                return _eventSource;
            }
        }

        public DateTime OccurredOn
        {
            get
            {
                return _occurredOn;
            }
        }
    }
}