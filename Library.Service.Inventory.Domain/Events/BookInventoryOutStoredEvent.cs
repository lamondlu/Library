using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Events
{
    [EventLog(Code = Code_BOOKINVENTORY_OUTSTORED, SendFinish = true, Message = "Event Finished.", Type = LogType.Info)]
    [EventLog(Code = Code_SERVER_ERROR, Type = LogType.Error)]
    public class BookInventoryOutStoredEvent : DomainEvent
    {
        public readonly static string Event_BookInventoryOutStored = "Event_BookInventoryOutStored";
        public const string Code_BOOKINVENTORY_OUTSTORED = "BOOKINVENTORY_OUTSTORED";

        public BookInventoryOutStoredEvent() : base(Event_BookInventoryOutStored)
        {
        }

        public string Notes { get; set; }

        public DateTime OutStoreDate { get; set; }
    }
}