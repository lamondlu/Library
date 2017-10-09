using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookIssuedDateChangedEvent : DomainEvent
    {
        public DateTime NewBookIssuedDate { get; set; }

        public Guid BookId { get; set; }
    }
}