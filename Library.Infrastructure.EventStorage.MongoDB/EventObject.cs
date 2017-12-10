using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.EventStorage.MongoDB
{
    public class AggregateRoot : Entity
    {
        public AggregateRoot()
        {
            Events = new List<EventObject>();
        }

        public Guid AggregateRootId { get; set; }

        public int Version { get; set; }

        public List<EventObject> Events { get; set; }
    }

    public class EventObject
    {
        public int Version { get; set; }

        public string EventName { get; set; }

        public string Content { get; set; }

        public DateTime OccurredOn { get; set; }

        public string AssemblyName { get; set; }
    }
}
