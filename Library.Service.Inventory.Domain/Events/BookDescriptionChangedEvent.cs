using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;

namespace Library.Service.Inventory.Domain.Events
{
    [EventLog(Code = "BOOKDESCRIPTION_UPDATED", Message = "Event Finished.", Type = LogType.Info)]
    [EventLog(Code = "SERVER_ERROR", Type = LogType.Error)]
    public class BookDescriptionChangedEvent : DomainEvent
    {
        public readonly static string Event_BookDescriptionChanged = "Event_BookDescriptionChanged";

        public BookDescriptionChangedEvent() : base(Event_BookDescriptionChanged)
        {
        }

        public string Description { get; set; }
    }
}