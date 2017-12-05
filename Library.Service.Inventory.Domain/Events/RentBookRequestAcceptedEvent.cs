using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Events
{
    [EventLog(Code = Code_RENTBOOKREQUEST_ACCEPTED, Message = "Event Finished.", Type = LogType.Info)]
    [EventLog(Code = Code_SERVER_ERROR, Type = LogType.Error)]
    public class RentBookRequestAcceptedEvent : DomainEvent
    {
        private static string Event_RentBookRequestAccepted = "Event_RentBookRequestAccepted";
        public const string Code_RENTBOOKREQUEST_ACCEPTED = "RENTBOOKREQUEST_ACCEPTED";

        public RentBookRequestAcceptedEvent() : base(Event_RentBookRequestAccepted)
        {
        }

        public Guid BookInventoryId { get; set; }

        public string Notes { get; set; }

        public Guid CustomerId { get; set; }
    }
}