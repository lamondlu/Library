using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;

namespace Library.Service.Rental.Domain
{
    [EventLog(Code = "CUSTOMERACCOUNT_INITIALIZED", Message = "Event finished.", Type = LogType.Info)]
    public class CustomerAccountInitializedEvent : DomainEvent
    {
        private static string Event_CustomerAccountInitialized = "Event_CustomerAccountInitialized";

        public CustomerAccountInitializedEvent() : base(Event_CustomerAccountInitialized)
        {
        }

        public PersonName Name { get; set; }
    }
}