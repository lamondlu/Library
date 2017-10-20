using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookNameChangedEvent : DomainEvent
    {
        public readonly static string Event_BookNameChanged = "Event_BookNameChanged";

        public BookNameChangedEvent() : base(Event_BookNameChanged)
        {

        }

        public string NewBookName { get; set; }

        public Guid BookId { get; set; }
    }
}