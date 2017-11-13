using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Inventory.Domain.Events
{
    public class BookInventoryInStoredEvent : DomainEvent
    {
        public readonly static string Event_BookInventoryInStored = "Event_BookInventoryInStored";

        public BookInventoryInStoredEvent() : base(Event_BookInventoryInStored)
        {

        }

        public Guid BookInventoryId { get; set; }

        public string Notes { get; set; }
    }
}