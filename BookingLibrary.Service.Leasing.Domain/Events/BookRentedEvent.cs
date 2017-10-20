using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Leasing.Domain.Events
{
    public class BookRentedEvent : DomainEvent
    {
        public readonly static string Event_BookRented = "Event_BookRented";

        public BookRentedEvent() : base(Event_BookRented)
        {

        }

        public Guid BookId { get; set; }

        public Guid CustomerId { get; set; }
    }
}
