using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Identity.Domain
{
    public class AdministratorCreatedEvent : DomainEvent
    {
        private readonly static string Event_AdministratorCreated = "Event_UsEvent_AdministratorCreatederCreated";

        public AdministratorCreatedEvent() : base(Event_AdministratorCreated)
        {

        }

        public UserPrincipal Principal { get; set; }

        public PersonName PersonName { get; set; }
    }
}