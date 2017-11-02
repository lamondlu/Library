using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingLibrary.Domain.Core
{
    public abstract class AggregateRoot : Entity, IEventProvider
    {
        private readonly List<DomainEvent> _changes;

        public int Version { get; set; }
        public int EventVersion { get; protected set; }

        protected AggregateRoot()
        {
            _changes = new List<DomainEvent>();
        }

        public IEnumerable<DomainEvent> GetUncommittedChanges()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        public void LoadsFromHistory(IEnumerable<DomainEvent> history)
        {
            foreach (var e in history) ApplyChange(e, false);
            Version = history.Last().Version;
            EventVersion = Version;
        }

        protected void ApplyChange(DomainEvent @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(DomainEvent @event, bool isNew)
        {
            dynamic d = this;

            d.Handle(Converter.ChangeTo(@event, @event.GetType()));
            if (isNew)
            {
                _changes.Add(@event);
            }
        }
    }
}