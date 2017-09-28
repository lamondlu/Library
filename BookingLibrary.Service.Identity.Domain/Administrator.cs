using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Identity.Domain
{
    public class Administrator : Person
    {
        public Administrator(PersonName name, UserPrincipal principal) : base(name)
        {
            this.UserPrincipal = principal;
        }

        public Administrator(Guid personId, PersonName name, UserPrincipal principal) : base(personId, name)
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