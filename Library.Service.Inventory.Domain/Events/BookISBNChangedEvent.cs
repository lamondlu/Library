using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;

namespace Library.Service.Inventory.Domain.Events
{
    [EventLog(Code = Code_BOOKISBN_CHANGED, Message = "Event finished.", Type = LogType.Info)]
    [EventLog(Code = Code_SERVER_ERROR, Type = LogType.Error)]
    public class BookISBNChangedEvent : DomainEvent
    {
        public readonly static string Event_BookISBNChanged = "Event_BookISBNChanged";
        public const string Code_BOOKISBN_CHANGED = "BOOKISBN_CHANGED";

        public BookISBNChangedEvent() : base(Event_BookISBNChanged)
        {
        }

        public string NewBookISBN { get; set; }
    }
}