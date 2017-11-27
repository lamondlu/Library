using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;

namespace Library.Service.Inventory.Domain.Events
{
    [EventLog(Code = "BOOKINVENTORY_OUTSTORED", DirectFinish = true, Message = "Event Finished.", Type = LogType.Info)]
    [EventLog(Code = "SERVER_ERROR", Message = "Event Finished.", Type = LogType.Error)]
    public class BookInventoryOutStoredEvent : DomainEvent
    {
        public readonly static string Event_BookInventoryOutStored = "Event_BookInventoryOutStored";

        public BookInventoryOutStoredEvent() : base(Event_BookInventoryOutStored)
        {
        }

        public string Notes { get; set; }
    }
}