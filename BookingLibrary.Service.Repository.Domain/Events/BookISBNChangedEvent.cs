using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookISBNChangedEvent : DomainEvent
    {
        public readonly static string Event_BookISBNChanged = "Event_BookISBNChanged";

        public BookISBNChangedEvent() : base(Event_BookISBNChanged)
        {

        }

        public string NewBookISBN { get; set; }

        public Guid BookId { get; set; }
    }
}