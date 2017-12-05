using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Events
{
    [EventLog(Code = Code_BOOKINVENTORY_CREATED, SendFinish = true, Message = "Event Finished.", Type = LogType.Info)]
    [EventLog(Code = Code_SERVER_ERROR, Type = LogType.Error)]
    public class BookInventoryCreatedEvent : DomainEvent
    {
        public readonly static string Event_BookInventoryCreated = "Event_BookInventoryCreated";
        public const string Code_BOOKINVENTORY_CREATED = "BOOKINVENTORY_CREATED";

        public BookInventoryCreatedEvent() : base(Event_BookInventoryCreated)
        {
        }

        public Guid BookId { get; set; }

        public string Notes { get; set; }
    }
}