using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Leasing.Domain.Events
{
    public class BookReturnedEvent : DomainEvent
    {
        public readonly static string Event_BookReturned = "Event_BookReturned";

        public BookReturnedEvent() : base(Event_BookReturned)
        {

        }

        public Guid BookId { get; set; }
    }
}