using Library.Domain.Core;
using System;
using System.Collections.Generic;

namespace Library.Service.Identity.Domain
{
	public class User : Person,
		IHandler<UserCreatedEvent>
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
	}
}