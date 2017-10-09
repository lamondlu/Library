using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookNameChangedEvent : DomainEvent
    {
        public string NewBookName { get; set; }

        public Guid BookId { get; set; }
    }
}