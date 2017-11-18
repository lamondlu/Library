using Library.Domain.Core;
using System;

namespace Library.Service.Inventory.Domain.Events
{
    public class RentedBookOutStoredEvent : DomainEvent
    {
        public readonly static string Event_RentedBookOutStored = "Event_RentedBookOutStored";

        public RentedBookOutStoredEvent() : base(Event_RentedBookOutStored)
        {
        }

        public string Notes { get; set; }

        public Guid CustomerId { get; set; }
    }
}