using Library.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service.Rental.Domain.Events
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
