using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Leasing.Domain
{
    public class CustomerAccountInitializedEvent : DomainEvent
    {
        private static string Event_CustomerAccountInitialized = "Event_CustomerAccountInitialized";

        public CustomerAccountInitializedEvent() : base(Event_CustomerAccountInitialized)
        {
            
        }

        public PersonName Name { get; set; }
    }
}