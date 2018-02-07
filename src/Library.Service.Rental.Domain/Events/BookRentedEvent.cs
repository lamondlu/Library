using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Rental.Domain.Events
{
    [EventLog(Code = Code_BOOK_RENTED, Message = "Event finished.", Type = LogType.Info, SendFinish = true)]
    [EventLog(Code = Code_SERVER_ERROR, Type = LogType.Error)]
    public class BookRentedEvent : DomainEvent
    {
        public readonly static string Event_BookRented = "Event_BookRented";
        public const string Code_BOOK_RENTED = "BOOK_RENTED";

        public BookRentedEvent() : base(Event_BookRented)
        {
        }

        public Guid BookInventoryId { get; set; }
    }
}