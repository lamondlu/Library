using BookingLibrary.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingLibrary.Service.Rental.Domain.Events
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
