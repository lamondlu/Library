using System;
using BookLibrary.Domain.Core;

namespace BookLibrary.Service.Identity.Domain
{
    public class UserCreatedEvent : DomainEvent
    {
        private readonly static string Event_UserCreated = "Event_UserCreated";

        public UserCreatedEvent() : base(Event_UserCreated)
        {

        }

        public UserPrincipal Principal { get; set; }

        public PersonName PersonName { get; set; }
    }
}