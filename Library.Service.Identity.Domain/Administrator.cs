using System;
using  Library.Domain.Core;

namespace  Library.Service.Identity.Domain
{
    public class Administrator : Person,
    IHandler<AdministratorCreatedEvent>
    {
        public Administrator() : base()
        {
            
        }

        public Administrator(Guid personId, PersonName name, UserPrincipal principal) : base(personId, name)
        {
            this.UserPrincipal = principal;

            ApplyChange(new AdministratorCreatedEvent
            {
                AggregateId = personId,
                PersonName = name,
                Principal = principal
            });
        }

        public UserPrincipal UserPrincipal
        {
            get;
            internal set;
        }

        public void Handle(AdministratorCreatedEvent evt)
        {
            this.Id = evt.AggregateId;
            this.Name = evt.PersonName;
            this.UserPrincipal = evt.Principal;
        }
    }
}