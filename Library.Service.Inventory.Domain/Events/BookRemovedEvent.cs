using Library.Domain.Core;

namespace Library.Service.Inventory.Domain.Events
{
    public class BookRemovedEvent : DomainEvent
    {
        public readonly static string Event_BookRemoved = "Event_BookRemoved";

        public BookRemovedEvent() : base(Event_BookRemoved)
        {
        }
    }
}