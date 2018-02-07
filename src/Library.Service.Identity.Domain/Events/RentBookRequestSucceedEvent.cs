using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Identity.Domain.Events
{
    [EventLog(Code = Code_RENTBOOKREQUEST_SUCCEED, Message = "Event Finished.", Type = LogType.Info, SendFinish = true)]
    [EventLog(Code = Code_SERVER_ERROR, Type = LogType.Error)]
    public class RentBookRequestSucceedEvent : DomainEvent
    {
        private static string Event_RentBookRequestSucceed = "Event_RentBookRequestSucceed";
        public const string Code_RENTBOOKREQUEST_SUCCEED = "RENTBOOKREQUEST_SUCCEED";

        public RentBookRequestSucceedEvent() : base(Event_RentBookRequestSucceed)
        {
        }

        public Guid BookInventoryId { get; set; }

        public Guid CustomerId { get; set; }
    }
}