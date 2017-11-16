using System;
using BookLibrary.Domain.Core;

namespace BookLibrary.Service.Rental.Domain.Events
{
    public class BookRentedEvent : DomainEvent
    {
        public readonly static string Event_BookRented = "Event_BookRented";

        public BookRentedEvent() : base(Event_BookRented)
        {

        }

        public Guid BookInventoryId { get; set; }
    }
}
