using  Library.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace  Library.Service.Inventory.Domain.Events
{
    public class RentBookRequestAcceptedEvent : DomainEvent
    {
        private static string Event_RentBookRequestAccepted = "Event_RentBookRequestAccepted";

        public RentBookRequestAcceptedEvent() : base(Event_RentBookRequestAccepted)
        {

        }

        public Guid BookInventoryId { get; set; }

        public string Notes { get; set; }

        public Guid CustomerId { get; set; }
    }
}
