using Library.Domain.Core;

namespace Library.Service.Rental.Domain
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