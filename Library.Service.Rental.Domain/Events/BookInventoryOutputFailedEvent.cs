using System;
using  Library.Domain.Core;

namespace  Library.Service.Rental.Domain.Events
{
    public class BookInventoryOutputFailedEvent : DomainEvent
    {
        public readonly static string Event_BookInventoryOutputFailed = "Event_BookInventoryOutputFailed";

        public BookInventoryOutputFailedEvent() : base(Event_BookInventoryOutputFailed)
        {

        }
    }
}
