using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Events
{
    [EventLog(Code = Code_BOOK_ADDED, Message = "Event Finished.", Type = LogType.Info, SendFinish = true)]
    [EventLog(Code = Code_SERVER_ERROR, Type = LogType.Info, SendError = true)]
    public class BookAddedEvent : DomainEvent
    {
        public readonly static string Event_BookAdded = "Event_BookAdded";
        public const string Code_BOOK_ADDED = "BOOK_ADDED";

        public BookAddedEvent() : base(Event_BookAdded)
        {
        }

        public string ISBN { get; set; }

        public string BookName { get; set; }

        public string Description { get; set; }

        public DateTime DateIssued { get; set; }
    }
}