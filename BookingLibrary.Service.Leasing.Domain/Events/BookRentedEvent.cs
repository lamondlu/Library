using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Leasing.Domain.Events
{
    public class BookRentedEvent : DomainEvent
    {
        public Guid BookId { get; set; }

        public Guid CustomerId { get; set; }
    }
}
