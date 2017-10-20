using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookDescriptionChangedEvent : DomainEvent
    {
        public readonly static string Event_BookDescriptionChanged = "Event_BookDescriptionChanged";

        public BookDescriptionChangedEvent() : base(Event_BookDescriptionChanged)
        {

        }

        public string Description { get; set; }
    }
}