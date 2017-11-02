using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookAddedEvent : DomainEvent
    {
        public readonly static string Event_BookAdded = "Event_BookAdded";

        public BookAddedEvent() : base(Event_BookAdded)
        {

        }

        public string ISBN { get; set; }

        public string BookName { get; set; }

        public string Description { get; set; }

        public DateTime DateIssued { get; set; }
    }
}
