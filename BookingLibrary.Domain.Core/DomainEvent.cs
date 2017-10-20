using System;

namespace BookingLibrary.Domain.Core
{
    public abstract class DomainEvent : IDomainEvent
    {
        private string _eventKey = string.Empty;

        private DateTime _occurredOn;
        private Entity _eventSource;

        public DomainEvent(string eventKey)
        {
            _occurredOn = DateTime.Now;
            _eventKey = eventKey;
        }

        public string EventKey
        {
            get
            {
                return _eventKey;
            }
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