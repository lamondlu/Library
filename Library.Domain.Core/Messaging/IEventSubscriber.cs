using System;

namespace Library.Domain.Core.Messaging
{
	public interface IEventSubscriber : IDisposable
	{
		void Subscribe<T>(T domainEvent) where T : DomainEvent;
	}
}