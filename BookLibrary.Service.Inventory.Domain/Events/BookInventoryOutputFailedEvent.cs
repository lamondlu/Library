using System;
using BookLibrary.Domain.Core;

namespace BookLibrary.Service.Inventory.Domain.Events
{
    public class BookInventoryOutputFailedEvent : DomainEvent
    {
        public readonly static string Event_BookInventoryOutputFailed = "Event_BookInventoryOutputFailed";

        public BookInventoryOutputFailedEvent() : base(Event_BookInventoryOutputFailed)
        {

        }
    }
}