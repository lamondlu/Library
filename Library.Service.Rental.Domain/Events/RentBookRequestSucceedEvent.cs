using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Rental.Domain.Events
{
    [EventLog(Code = "RENTBOOKREQUEST_SUCCEED", Message = "Event Finished.", Type = LogType.Info)]
    [EventLog(Code = "SERVER_ERROR", Type = LogType.Error)]
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