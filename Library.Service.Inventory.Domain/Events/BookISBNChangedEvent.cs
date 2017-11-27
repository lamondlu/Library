using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;

namespace Library.Service.Inventory.Domain.Events
{
    [EventLog(Code = "BOOKISBN_CHANGED", Message = "Event finished.", Type = LogType.Info)]
    [EventLog(Code = "SERVER_ERROR", Type = LogType.Error)]
    public class BookISBNChangedEvent : DomainEvent
    {
        public readonly static string Event_BookISBNChanged = "Event_BookISBNChanged";

        public BookISBNChangedEvent() : base(Event_BookISBNChanged)
        {
        }

        public string NewBookISBN { get; set; }
    }
}