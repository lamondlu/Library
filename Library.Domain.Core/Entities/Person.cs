using System;

namespace Library.Domain.Core
{
	public class Person : AggregateRoot
	{
		public Person()
		{
		}

		public Person(Guid personId, PersonName name)
		{
			this.Id = personId;
			this.Name = name;
		}

		public PersonName Name { get; set; }
	}
}