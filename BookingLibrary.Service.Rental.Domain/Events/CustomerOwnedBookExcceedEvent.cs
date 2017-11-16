using BookingLibrary.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingLibrary.Service.Rental.Domain.Events
{
    public class CustomerOwnedBookExcceedEvent : DomainEvent
    {
        private static string EVENT_CustomerOwnedBookExcceed = "EVENT_CustomerOwnedBookExcceed";

        public CustomerOwnedBookExcceedEvent() : base(EVENT_CustomerOwnedBookExcceed)
        {

        }
    }
}
