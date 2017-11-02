using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookRepositoryOutStoredEvent : DomainEvent
    {
        public readonly static string Event_BookRepositoryOutStored = "Event_BookRepositoryOutStored";

        public BookRepositoryOutStoredEvent() : base(Event_BookRepositoryOutStored)
        {

        }

        public Guid BookRepositoryId { get; set; }

        public string Notes { get; set; }
    }
}