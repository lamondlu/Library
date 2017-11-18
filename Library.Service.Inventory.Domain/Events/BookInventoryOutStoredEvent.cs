using Library.Domain.Core;

namespace Library.Service.Inventory.Domain.Events
{
    public class BookInventoryOutStoredEvent : DomainEvent
    {
        public readonly static string Event_BookInventoryOutStored = "Event_BookInventoryOutStored";

        public BookInventoryOutStoredEvent() : base(Event_BookInventoryOutStored)
        {
        }

        public string Notes { get; set; }
    }
}