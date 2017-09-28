using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Identity.Domain
{
    public class UserCreatedEvent : DomainEvent
    {
        public UserPrincipal Principal { get; set; }

        public PersonName PersonName { get; set; }
    }
}