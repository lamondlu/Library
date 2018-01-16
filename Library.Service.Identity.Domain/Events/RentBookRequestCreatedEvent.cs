using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Identity.Domain.Events
{
    [EventLog(Code = Code_RENTBOOKREQUEST_CREATED, Message = "Event Finished.", Type = LogType.Info)]
    [EventLog(Code = Code_OWNED_BOOK_EXCCEED, Message = "One customer can only have 3 book at most.", Type = LogType.Warning)]
    [EventLog(Code = Code_SERVER_ERROR, Type = LogType.Error)]
    public class RentBookRequestCreatedEvent : DomainEvent
    {
        public readonly static string Event_RentBookRequestCreatedEvent = "Event_RentBookRequestCreated";
        public const string Code_RENTBOOKREQUEST_CREATED = "RENTBOOKREQUEST_CREATED";
        public const string Code_OWNED_BOOK_EXCCEED = "OWNED_BOOK_EXCCEED";

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