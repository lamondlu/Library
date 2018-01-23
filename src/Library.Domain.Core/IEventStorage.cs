using System;
using System.Collections.Generic;

namespace Library.Domain.Core
{
	public interface IEventStorage
	{
		IEnumerable<DomainEvent> GetEvents(Guid aggregateId);

		void Save(AggregateRoot aggregate, Guid commandUniqueId);
	}
}