using System;
using Library.Domain.Core;

namespace Library.Service.Identity.Domain
{
    public class BookOwnedEvent : DomainEvent
    {
        private readonly static string Event_BookOwned = "Event_Event_BookOwned";
        public BookOwnedEvent() : base(BookOwnedEvent.Event_BookOwned)
        {
            
        }

        public Guid BookInventoryId { get; set; }
    }
}