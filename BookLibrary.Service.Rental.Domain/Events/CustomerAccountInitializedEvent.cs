using System;
using BookLibrary.Domain.Core;

namespace BookLibrary.Service.Rental.Domain
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