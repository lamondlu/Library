using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Inventory.Domain.Events
{
    public class BookRemovedEvent : DomainEvent
    {
        public readonly static string Event_BookRemoved = "Event_BookRemoved";

        public BookRemovedEvent() : base(Event_BookRemoved)
        {
            
        }
    }
}
