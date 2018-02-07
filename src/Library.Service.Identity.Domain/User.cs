using Library.Domain.Core;
using System;
using System.Collections.Generic;
using Library.Service.Identity.Domain.Events;

namespace Library.Service.Identity.Domain
{
    public class User : Person,
        IHandler<UserCreatedEvent>,
        IHandler<BookOwnedEvent>
    {
        public User()
        {
        }

        public User(PersonName name, UserPrincipal principal)
        {
            ApplyChange(new UserCreatedEvent
            {
                AggregateId = Guid.NewGuid(),
                PersonName = name,
                Principal = principal
            });
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

        public List<Guid> Books
        {
            get;
            internal set;
        }

        public void Handle(UserCreatedEvent evt)
        {
            Id = evt.AggregateId;
            Name = evt.PersonName;
            UserPrincipal = evt.Principal;
            Books = new List<Guid>();
        }

        public void OwnBook(Guid bookInventoryId)
        {
            ApplyChange(new BookOwnedEvent
            {
                BookInventoryId = bookInventoryId,
                AggregateId = this.Id
            });
        }

        public void Handle(BookOwnedEvent evt)
        {
            if (Books == null)
            {
                Books = new List<Guid>();
            }

            Books.Add(evt.BookInventoryId);
        }
    }
}