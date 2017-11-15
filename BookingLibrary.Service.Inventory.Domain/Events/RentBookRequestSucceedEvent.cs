using BookingLibrary.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingLibrary.Service.Inventory.Domain.Events
{
    public class RentBookRequestSucceedEvent : DomainEvent
    {
        private static string Event_RentBookRequestSucceed = "Event_RentBookRequestSucceed";

        public RentBookRequestSucceedEvent() : base(Event_RentBookRequestSucceed)
        {

        }

        public Guid BookInventoryId { get; set; }

        public Guid CustomerId { get; set; }
    }
}
