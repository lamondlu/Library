using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Events
{
    [EventLog(Code = "BOOKNAME_CHANGED", Message = "Event finished.", Type = LogType.Info)]
    [EventLog(Code = "SERVER_ERROR", Type = LogType.Error)]
    public class BookNameChangedEvent : DomainEvent
    {
        public readonly static string Event_BookNameChanged = "Event_BookNameChanged";

        public BookNameChangedEvent() : base(Event_BookNameChanged)
        {
        }

        public string NewBookName { get; set; }

        public Guid BookId { get; set; }
    }
}