using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Events
{
    [EventLog(Code = "BOOKINVENTORY_CREATED", SendFinish = true, Message = "Event Finished.", Type = LogType.Info)]
    [EventLog(Code = "SERVER_ERROR", Type = LogType.Error)]
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