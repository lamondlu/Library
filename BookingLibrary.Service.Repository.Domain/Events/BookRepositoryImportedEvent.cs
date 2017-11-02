using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookRepositoryImportedEvent : DomainEvent
    {
        public readonly static string Event_BookRepositoryImported = "Event_BookRepositoryImported";

        public BookRepositoryImportedEvent() : base(Event_BookRepositoryImported)
        {

        }

        public List<Guid> BookRepositoryIds { get; set; }
    }
}