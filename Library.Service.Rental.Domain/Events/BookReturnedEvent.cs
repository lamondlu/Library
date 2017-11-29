using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Rental.Domain.Events
{
    [EventLog(Code = "BOOK_RETURNED", Message = "Event finsihed.", Type = LogType.Info, SendFinish = true)]
    [EventLog(Code = "SERVER_ERROR", Type = LogType.Error)]
    public class BookReturnedEvent : DomainEvent
    {
        public readonly static string Event_BookReturned = "Event_BookReturned";

        public BookReturnedEvent() : base(Event_BookReturned)
        {
        }

        public Guid BookId { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}