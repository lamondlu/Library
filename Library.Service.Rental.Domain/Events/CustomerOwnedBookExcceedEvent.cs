using  Library.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace  Library.Service.Rental.Domain.Events
{
    public class CustomerOwnedBookExcceedEvent : DomainEvent
    {
        private static string EVENT_CustomerOwnedBookExcceed = "Event_CustomerOwnedBookExcceed";

        public CustomerOwnedBookExcceedEvent() : base(EVENT_CustomerOwnedBookExcceed)
        {

        }
    }
}
