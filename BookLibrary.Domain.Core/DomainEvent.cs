using System;

namespace BookLibrary.Domain.Core
{
    public abstract class DomainEvent : IDomainEvent
    {
        private string _eventKey = string.Empty;

        private DateTime _occurredOn;

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

        public Guid CommandUniqueId
        {
            get;
            set;
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