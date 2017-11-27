using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Rental.Domain.Events
{
    [EventLog(Code = "BOOK_RENTED", Message = "Event finished.", Type = LogType.Info, DirectFinish = true)]
    [EventLog(Code = "SERVER_ERROR", Type = LogType.Error)]
    public class BookRentedEvent : DomainEvent
    {
        public readonly static string Event_BookRented = "Event_BookRented";

        public BookRentedEvent() : base(Event_BookRented)
        {
        }

        public Guid BookInventoryId { get; set; }
    }
}