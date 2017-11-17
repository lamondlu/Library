using System;
using  Library.Domain.Core;

namespace  Library.Service.Inventory.Domain.Events
{
    public class BookDescriptionChangedEvent : DomainEvent
    {
        public readonly static string Event_BookDescriptionChanged = "Event_BookDescriptionChanged";

        public BookDescriptionChangedEvent() : base(Event_BookDescriptionChanged)
        {

        }

        public string Description { get; set; }
    }
}