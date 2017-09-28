using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Identity.Domain
{
    public class User : Person
    {
        public User(PersonName name, UserPrincipal principal) : base(Guid.NewGuid(), name)
        {
            this.UserPrincipal = principal;
        }

        public User(Guid personId, PersonName name, UserPrincipal principal) : base(personId, name)
        {
            this.UserPrincipal = principal;
        }

        public UserPrincipal UserPrincipal
        {
            get;
            internal set;
        }
    }
}
