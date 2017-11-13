using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Inventory.Domain.Events
{
    public class BookInventoryImportedEvent : DomainEvent
    {
        public readonly static string Event_BookInventoryImported = "Event_BookInventoryImported";

        public BookInventoryImportedEvent() : base(Event_BookInventoryImported)
        {

        }

        public List<Guid> BookInventoryIds { get; set; }
    }
}