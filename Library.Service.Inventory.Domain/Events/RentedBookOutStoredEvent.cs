using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Events
{
    [EventLog(Code = "RENTEDBOOK_OUTSTORED", Message = "Event Finished.", Type = LogType.Info)]
    [EventLog(Code = "SERVER_ERROR", Type = LogType.Error)]
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