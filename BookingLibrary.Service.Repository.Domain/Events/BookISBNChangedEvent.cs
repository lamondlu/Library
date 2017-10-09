using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookISBNChangedEvent : DomainEvent
    {
        public string NewBookISBN { get; set; }

        public Guid BookId { get; set; }
    }
}