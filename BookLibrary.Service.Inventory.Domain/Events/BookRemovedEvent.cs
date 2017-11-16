using System;
using BookLibrary.Domain.Core;

namespace BookLibrary.Service.Inventory.Domain.Events
{
    public class BookRemovedEvent : DomainEvent
    {
        public readonly static string Event_BookRemoved = "Event_BookRemoved";

        public BookRemovedEvent() : base(Event_BookRemoved)
        {
            
        }
    }
}
