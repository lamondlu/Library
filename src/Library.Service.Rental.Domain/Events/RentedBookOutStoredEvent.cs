using Library.Domain.Core;
using System;

namespace Library.Service.Rental.Domain.Events
{
    public class RentBookRequestAcceptedEvent : DomainEvent
    {
        public readonly static string Event_RentBookRequestAccepted = "Event_RentBookRequestAccepted";

        public RentBookRequestAcceptedEvent() : base(Event_RentBookRequestAccepted)
        {
        }

        public string Notes { get; set; }

        public Guid CustomerId { get; set; }
    }
}