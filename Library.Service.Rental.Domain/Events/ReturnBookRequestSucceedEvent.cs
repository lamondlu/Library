using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Rental.Domain.Events
{
    [EventLog(Code = "RETURNBOOKREQUEST_SUCCEED", Message = "Event Finished.", Type = LogType.Info)]
    [EventLog(Code = "SERVER_ERROR", Type = LogType.Error)]
    public class ReturnBookRequestSucceedEvent : DomainEvent
    {
        private static string EVENT_ReturnBookRequestSucceed = "EVENT_ReturnBookRequestSucceed";

        public ReturnBookRequestSucceedEvent() : base(EVENT_ReturnBookRequestSucceed)
        {
        }

        public Guid CustomerId { get; set; }

        public Guid BookInventoryId { get; set; }
    }
}