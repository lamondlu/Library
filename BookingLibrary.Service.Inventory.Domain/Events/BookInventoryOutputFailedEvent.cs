using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Inventory.Domain.Events
{
    public class BookInventoryOutputFailedEvent : DomainEvent
    {
        public readonly static string Event_BookInventoryOutputFailed = "Event_BookInventoryOutputFailed";

        public BookInventoryOutputFailedEvent() : base(Event_BookInventoryOutputFailed)
        {

        }
    }
}