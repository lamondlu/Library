using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Rental.Domain.Events
{
    [EventLog(Code = Code_BOOK_RETURNED, Message = "Event finsihed.", Type = LogType.Info, SendFinish = true)]
    [EventLog(Code = Code_SERVER_ERROR, Type = LogType.Error)]
    public class BookReturnedEvent : DomainEvent
    {
        public readonly static string Event_BookReturned = "Event_BookReturned";
        public const string Code_BOOK_RETURNED = "BOOK_RETURNED";

        public BookReturnedEvent() : base(Event_BookReturned)
        {
        }

        public Guid BookId { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}