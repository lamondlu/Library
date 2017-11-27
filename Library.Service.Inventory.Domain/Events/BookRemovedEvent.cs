using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;

namespace Library.Service.Inventory.Domain.Events
{
    [EventLog(Code = "BOOK_REMOVED", Message = "Event finished.", Type = LogType.Info)]
    public class BookRemovedEvent : DomainEvent
    {
        public readonly static string Event_BookRemoved = "Event_BookRemoved";

        public BookRemovedEvent() : base(Event_BookRemoved)
        {
        }
    }
}