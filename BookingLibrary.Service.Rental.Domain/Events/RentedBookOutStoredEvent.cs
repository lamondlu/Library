using BookingLibrary.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingLibrary.Service.Rental.Domain.Events
{
    public class RentedBookOutStoredEvent : DomainEvent
    {
        public readonly static string Event_RentedBookOutStored = "Event_RentedBookOutStored";

        public RentedBookOutStoredEvent() : base(Event_RentedBookOutStored)
        {

        }

        public string Notes { get; set; }
    }
}
