using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookIssuedDateChangedEvent : DomainEvent
    {
        public readonly static string Event_BookIssuedDateChanged = "Event_BookIssuedDateChanged";

        public BookIssuedDateChangedEvent() : base(Event_BookIssuedDateChanged)
        {

        }

        public DateTime NewBookIssuedDate { get; set; }

        public Guid BookId { get; set; }
    }
}