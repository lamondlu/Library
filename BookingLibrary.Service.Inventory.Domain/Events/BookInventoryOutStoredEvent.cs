using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Inventory.Domain.Events
{
    public class BookInventoryOutStoredEvent : DomainEvent
    {
        public readonly static string Event_BookInventoryOutStored = "Event_BookInventoryOutStored";

        public BookInventoryOutStoredEvent() : base(Event_BookInventoryOutStored)
        {

        }

        public Guid BookInventoryId { get; set; }

        public string Notes { get; set; }
    }
}