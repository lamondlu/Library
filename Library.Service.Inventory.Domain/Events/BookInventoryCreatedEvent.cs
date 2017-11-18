using Library.Domain.Core;
using System;

namespace Library.Service.Inventory.Domain.Events
{
    public class BookInventoryCreatedEvent : DomainEvent
    {
        public readonly static string Event_BookInventoryCreated = "Event_BookInventoryCreated";

        public BookInventoryCreatedEvent() : base(Event_BookInventoryCreated)
        {
        }

        public Guid BookId { get; set; }

        public string Notes { get; set; }
    }
}