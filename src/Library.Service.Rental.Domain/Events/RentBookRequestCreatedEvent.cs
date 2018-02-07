using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Rental.Domain.Events
{
    [EventLog(Code = Code_RENTBOOKREQUEST_CREATED, Message = "Event Finished.", Type = LogType.Info)]
    [EventLog(Code = Code_SERVER_ERROR, Type = LogType.Error)]
    public class RentBookRequestCreatedEvent : DomainEvent
    {
        public readonly static string Event_RentBookRequestCreatedEvent = "Event_RentBookRequestCreated";
        public const string Code_RENTBOOKREQUEST_CREATED = "RENTBOOKREQUEST_CREATED";

        public RentBookRequestCreatedEvent() : base(Event_RentBookRequestCreatedEvent)
        {
        }

        public Guid BookInventoryId { get; set; }

        public string BookName { get; set; }

        public string ISBN { get; set; }

        public PersonName Name { get; set; }

        public DateTime RentDate { get; set; }
    }
}