using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookOutStoredEvent : DomainEvent
    {
        public readonly static string Event_BookOutStored = "Event_BookOutStored";

        public BookOutStoredEvent() : base(Event_BookOutStored)
        {
            
        }
    }
}