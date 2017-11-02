using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookRepositoryInStoredEvent : DomainEvent
    {
        public readonly static string Event_BookRepositoryInStored = "Event_BookRepositoryInStored";

        public BookRepositoryInStoredEvent() : base(Event_BookRepositoryInStored)
        {

        }

        public Guid BookRepositoryId { get; set; }

        public string Notes { get; set; }
    }
}