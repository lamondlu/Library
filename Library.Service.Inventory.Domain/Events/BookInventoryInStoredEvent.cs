using System;
using  Library.Domain.Core;

namespace  Library.Service.Inventory.Domain.Events
{
    public class BookInventoryInStoredEvent : DomainEvent
    {
        public readonly static string Event_BookInventoryInStored = "Event_BookInventoryInStored";

        public BookInventoryInStoredEvent() : base(Event_BookInventoryInStored)
        {

        }

        public string Notes { get; set; }
    }
}