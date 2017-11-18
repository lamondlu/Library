using Library.Domain.Core;
using System;

namespace Library.Service.Rental.Domain.Events
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