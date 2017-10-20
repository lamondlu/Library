using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookInStoredEvent : DomainEvent
    {
        public readonly static string Event_BookInStored = "Event_BookInStored";

        public BookInStoredEvent() : base(Event_BookInStored)
        {

        }
    }
}