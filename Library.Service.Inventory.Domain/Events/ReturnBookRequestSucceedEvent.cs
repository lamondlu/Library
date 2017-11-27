using Library.Domain.Core;
using System;

namespace Library.Service.Inventory.Domain.Events
{
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