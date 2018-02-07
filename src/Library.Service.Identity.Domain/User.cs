using Library.Domain.Core;
using System;

namespace Library.Service.Identity.Domain
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