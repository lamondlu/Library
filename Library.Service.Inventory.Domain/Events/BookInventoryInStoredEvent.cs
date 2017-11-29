using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;

namespace Library.Service.Inventory.Domain.Events
{
    [EventLog(Code = "BOOKINVENTORY_INSTORED", SendFinish = true, Message = "Event Finished.", Type = LogType.Info)]
    [EventLog(Code = "SERVER_ERROR", Message = "Event Finished.", Type = LogType.Error)]
    public class BookInventoryInStoredEvent : DomainEvent
    {
        public readonly static string Event_BookInventoryInStored = "Event_BookInventoryInStored";

        public BookInventoryInStoredEvent() : base(Event_BookInventoryInStored)
        {
        }

        public string Notes { get; set; }
    }
}