using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Identity.Domain
{
    public class AdministratorCreatedEvent : DomainEvent
    {
        public UserPrincipal Principal { get; set; }

        public PersonName PersonName { get; set; }
    }
}